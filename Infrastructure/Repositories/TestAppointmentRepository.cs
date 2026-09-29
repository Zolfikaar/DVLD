using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Infrastructure.DB;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public class TestAppointmentRepository : ITestAppointmentRepository
    {
        private const string AppointmentSelect = @"
            SELECT
                ta.TestAppointmentID,
                ta.TestTypeID,
                ta.LocalDrivingLicenseApplicationID,
                ta.AppointmentDate,
                ta.PaidFees,
                ta.CreatedByUserID,
                ta.IsLocked,
                ta.RetakeTestApplicationID,
                ISNULL(ra.PaidFees, 0) AS RetakeFees,
                t.TestID,
                t.TestResult
            FROM TestAppointments ta
            LEFT JOIN Applications ra ON ra.ApplicationID = ta.RetakeTestApplicationID
            LEFT JOIN Tests t ON t.TestAppointmentID = ta.TestAppointmentID";

        private const string TestResultsFilter = @"
            FROM Tests t
            INNER JOIN TestAppointments ta ON ta.TestAppointmentID = t.TestAppointmentID
            WHERE ta.LocalDrivingLicenseApplicationID = @LocalLicenseAppId AND ta.TestTypeID = @TestTypeId";

        public TestAppointmentRepository()
        {
            CreateConnection();
        }

        private SqlConnection CreateConnection()
        {
            return DbInitializer.Connection();
        }

        public async Task<IEnumerable<TestAppointment>> GetAppointmentsAsync(int localLicenseAppId, int testTypeId)
        {
            using (var connection = CreateConnection())
            {
                string sql = AppointmentSelect + @"
                    WHERE ta.LocalDrivingLicenseApplicationID = @LocalLicenseAppId AND ta.TestTypeID = @TestTypeId
                    ORDER BY ta.AppointmentDate DESC";

                return await connection.QueryAsync<TestAppointment>(sql, new { LocalLicenseAppId = localLicenseAppId, TestTypeId = testTypeId });
            }
        }

        public async Task<TestAppointment> GetAppointmentByIdAsync(int testAppointmentId)
        {
            using (var connection = CreateConnection())
            {
                string sql = AppointmentSelect + " WHERE ta.TestAppointmentID = @Id";
                return await connection.QueryFirstOrDefaultAsync<TestAppointment>(sql, new { Id = testAppointmentId });
            }
        }

        public async Task<bool> HasActiveAppointmentAsync(int localLicenseAppId, int testTypeId)
        {
            using (var connection = CreateConnection())
            {
                string sql = @"
                    SELECT CAST(CASE WHEN EXISTS (
                        SELECT 1 FROM TestAppointments
                        WHERE LocalDrivingLicenseApplicationID = @LocalLicenseAppId AND TestTypeID = @TestTypeId AND IsLocked = 0
                    ) THEN 1 ELSE 0 END AS bit)";

                return await connection.ExecuteScalarAsync<bool>(sql, new { LocalLicenseAppId = localLicenseAppId, TestTypeId = testTypeId });
            }
        }

        public async Task<bool> HasPassedTestAsync(int localLicenseAppId, int testTypeId)
        {
            using (var connection = CreateConnection())
            {
                string sql = "SELECT CAST(CASE WHEN EXISTS (SELECT 1 " + TestResultsFilter + " AND t.TestResult = 1) THEN 1 ELSE 0 END AS bit)";
                return await connection.ExecuteScalarAsync<bool>(sql, new { LocalLicenseAppId = localLicenseAppId, TestTypeId = testTypeId });
            }
        }

        public async Task<bool> HasAttendedTestAsync(int localLicenseAppId, int testTypeId)
        {
            using (var connection = CreateConnection())
            {
                string sql = "SELECT CAST(CASE WHEN EXISTS (SELECT 1 " + TestResultsFilter + ") THEN 1 ELSE 0 END AS bit)";
                return await connection.ExecuteScalarAsync<bool>(sql, new { LocalLicenseAppId = localLicenseAppId, TestTypeId = testTypeId });
            }
        }

        public async Task<int> AddAppointmentAsync(TestAppointment appointment, bool isRetake, int applicantPersonId)
        {
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int? retakeApplicationId = null;

                        if (isRetake)
                        {
                            string sqlRetakeApp = @"
                                INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                                VALUES (@ApplicantPersonID, GETDATE(), @ApplicationTypeID, @Status, GETDATE(),
                                        (SELECT ApplicationFees FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID),
                                        @CreatedByUserID);
                                SELECT CAST(SCOPE_IDENTITY() as int);";

                            retakeApplicationId = await connection.ExecuteScalarAsync<int>(sqlRetakeApp, new
                            {
                                ApplicantPersonID = applicantPersonId,
                                ApplicationTypeID = (int)ApplicationTypeId.RetakeTest,
                                Status = (int)ApplicationStatus.Completed,
                                appointment.CreatedByUserID
                            }, transaction);
                        }

                        string sqlAppointment = @"
                            INSERT INTO TestAppointments (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
                            VALUES (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate,
                                    (SELECT TestTypeFees FROM TestTypes WHERE TestTypeID = @TestTypeID),
                                    @CreatedByUserID, 0, @RetakeTestApplicationID);
                            SELECT CAST(SCOPE_IDENTITY() as int);";

                        int appointmentId = await connection.ExecuteScalarAsync<int>(sqlAppointment, new
                        {
                            appointment.TestTypeID,
                            appointment.LocalDrivingLicenseApplicationID,
                            appointment.AppointmentDate,
                            appointment.CreatedByUserID,
                            RetakeTestApplicationID = retakeApplicationId
                        }, transaction);

                        transaction.Commit();
                        return appointmentId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public async Task<bool> UpdateAppointmentDateAsync(int testAppointmentId, DateTime appointmentDate)
        {
            using (var connection = CreateConnection())
            {
                string sql = "UPDATE TestAppointments SET AppointmentDate = @AppointmentDate WHERE TestAppointmentID = @Id AND IsLocked = 0";
                int rows = await connection.ExecuteAsync(sql, new { AppointmentDate = appointmentDate, Id = testAppointmentId });
                return rows > 0;
            }
        }

        public async Task<int> TakeTestAsync(int testAppointmentId, bool testResult, string? notes, int createdByUserId)
        {
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int locked = await connection.ExecuteAsync(
                            "UPDATE TestAppointments SET IsLocked = 1 WHERE TestAppointmentID = @Id AND IsLocked = 0",
                            new { Id = testAppointmentId }, transaction);

                        if (locked == 0)
                            throw new InvalidOperationException("This appointment is locked; the test was already taken.");

                        string sqlTest = @"
                            INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                            VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
                            SELECT CAST(SCOPE_IDENTITY() as int);";

                        int testId = await connection.ExecuteScalarAsync<int>(sqlTest, new
                        {
                            TestAppointmentID = testAppointmentId,
                            TestResult = testResult,
                            Notes = notes,
                            CreatedByUserID = createdByUserId
                        }, transaction);

                        transaction.Commit();
                        return testId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
