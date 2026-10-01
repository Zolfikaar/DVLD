using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Infrastructure.DB;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public class LocalLicenseRepository : ILocalLicenseRepository
    {
        private const string LocalLicenseSelect = @"
            SELECT
                v.LocalDrivingLicenseApplicationID,
                v.ClassName,
                v.NationalNo,
                v.FullName,
                v.ApplicationDate,
                v.PassedTestCount,
                v.Status,
                ldla.ApplicationID,
                ldla.LicenseClassID,
                a.ApplicantPersonID,
                a.ApplicationStatus,
                a.PaidFees,
                a.LastStatusDate,
                a.CreatedByUserID,
                at.ApplicationTypeTitle,
                ISNULL(u.UserName, '') AS CreatedByUserName,
                ISNULL((SELECT TOP 1 l.LicenseID FROM Licenses l WHERE l.ApplicationID = ldla.ApplicationID), 0) AS LicenseID
            FROM LocalDrivingLicenseApplications_View v
            INNER JOIN LocalDrivingLicenseApplications ldla ON ldla.LocalDrivingLicenseApplicationID = v.LocalDrivingLicenseApplicationID
            INNER JOIN Applications a ON a.ApplicationID = ldla.ApplicationID
            INNER JOIN ApplicationTypes at ON at.ApplicationTypeID = a.ApplicationTypeID
            LEFT JOIN Users u ON u.UserID = a.CreatedByUserID";

        public LocalLicenseRepository()
        {
            CreateConnection();
        }

        private SqlConnection CreateConnection()
        {
            return DbInitializer.Connection();
        }

        public async Task<IEnumerable<LocalLicense>> GetAllLocalLicenseAsync()
        {
            using (var connection = CreateConnection())
            {
                string sql = LocalLicenseSelect + " ORDER BY v.LocalDrivingLicenseApplicationID DESC";
                return await connection.QueryAsync<LocalLicense>(sql);
            }
        }

        public async Task<LocalLicense> GetLocalLicenseByIdAsync(int id)
        {
            using (var connection = CreateConnection())
            {
                string sql = LocalLicenseSelect + " WHERE v.LocalDrivingLicenseApplicationID = @Id";
                return await connection.QueryFirstOrDefaultAsync<LocalLicense>(sql, new { Id = id });
            }
        }

        public async Task<int> AddLocalLicenseAsync(LocalLicense localLicense)
        {
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string sqlApp = @"
                            INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                            VALUES (@ApplicantPersonID, GETDATE(), @ApplicationTypeID, @Status, GETDATE(),
                                    (SELECT ApplicationFees FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID),
                                    @CreatedByUserID);
                            SELECT CAST(SCOPE_IDENTITY() as int);";

                        int appId = await connection.ExecuteScalarAsync<int>(sqlApp, new
                        {
                            localLicense.ApplicantPersonID,
                            ApplicationTypeID = (int)ApplicationTypeId.NewLocalLicense,
                            Status = (int)ApplicationStatus.New,
                            localLicense.CreatedByUserID
                        }, transaction);

                        string sqlLocal = @"
                            INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                            VALUES (@ApplicationID, @LicenseClassID);
                            SELECT CAST(SCOPE_IDENTITY() as int);";

                        int localAppId = await connection.ExecuteScalarAsync<int>(sqlLocal,
                            new { ApplicationID = appId, localLicense.LicenseClassID }, transaction);

                        transaction.Commit();
                        return localAppId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public async Task<bool> UpdateLocalLicenseAsync(LocalLicense license, int id)
        {
            using (var connection = CreateConnection())
            {
                string sql = @"
                    UPDATE LocalDrivingLicenseApplications
                    SET LicenseClassID = @LicenseClassID
                    WHERE LocalDrivingLicenseApplicationID = @Id;

                    UPDATE Applications
                    SET LastStatusDate = GETDATE()
                    WHERE ApplicationID = (SELECT ApplicationID FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @Id);";

                int rows = await connection.ExecuteAsync(sql, new { license.LicenseClassID, Id = id });
                return rows > 0;
            }
        }

        public async Task<bool> DeleteLocalLicenseAsync(int id)
        {
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int? applicationId = await connection.ExecuteScalarAsync<int?>(
                            "SELECT ApplicationID FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @Id",
                            new { Id = id }, transaction);

                        if (applicationId == null)
                        {
                            transaction.Rollback();
                            return false;
                        }

                        int takenTests = await connection.ExecuteScalarAsync<int>(@"
                            SELECT COUNT(*)
                            FROM Tests t
                            INNER JOIN TestAppointments ta ON ta.TestAppointmentID = t.TestAppointmentID
                            WHERE ta.LocalDrivingLicenseApplicationID = @Id",
                            new { Id = id }, transaction);

                        if (takenTests > 0)
                            throw new InvalidOperationException(
                                "This application cannot be deleted because the applicant has already taken " + takenTests +
                                " test(s). Cancel the application instead.");

                        int issuedLicenses = await connection.ExecuteScalarAsync<int>(
                            "SELECT COUNT(*) FROM Licenses WHERE ApplicationID = @ApplicationID",
                            new { ApplicationID = applicationId }, transaction);

                        if (issuedLicenses > 0)
                            throw new InvalidOperationException(
                                "This application cannot be deleted because a driving license was already issued for it.");

                        List<int> retakeApplicationIds = (await connection.QueryAsync<int>(@"
                            SELECT RetakeTestApplicationID
                            FROM TestAppointments
                            WHERE LocalDrivingLicenseApplicationID = @Id AND RetakeTestApplicationID IS NOT NULL",
                            new { Id = id }, transaction)).ToList();

                        await connection.ExecuteAsync(@"
                            DELETE t FROM Tests t
                            INNER JOIN TestAppointments ta ON ta.TestAppointmentID = t.TestAppointmentID
                            WHERE ta.LocalDrivingLicenseApplicationID = @Id;

                            DELETE FROM TestAppointments WHERE LocalDrivingLicenseApplicationID = @Id;

                            DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @Id;",
                            new { Id = id }, transaction);

                        retakeApplicationIds.Add(applicationId.Value);
                        int rows = await connection.ExecuteAsync(
                            "DELETE FROM Applications WHERE ApplicationID IN @Ids",
                            new { Ids = retakeApplicationIds }, transaction);

                        transaction.Commit();
                        return rows > 0;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public async Task<bool> CancelLocalLicenseAsync(int id)
        {
            using (var connection = CreateConnection())
            {
                string sql = @"
                    UPDATE Applications
                    SET ApplicationStatus = @Cancelled, LastStatusDate = GETDATE()
                    WHERE ApplicationStatus = @New
                      AND ApplicationID = (SELECT ApplicationID FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @Id)";

                int rows = await connection.ExecuteAsync(sql, new
                {
                    Id = id,
                    Cancelled = (int)ApplicationStatus.Cancelled,
                    New = (int)ApplicationStatus.New
                });
                return rows > 0;
            }
        }

        public async Task<bool> HasActiveApplicationAsync(int personId, int licenseClassId, int excludedLocalLicenseAppId)
        {
            using (var connection = CreateConnection())
            {
                string sql = @"
                    SELECT CAST(CASE WHEN EXISTS (
                        SELECT 1
                        FROM LocalDrivingLicenseApplications ldla
                        INNER JOIN Applications a ON a.ApplicationID = ldla.ApplicationID
                        WHERE a.ApplicantPersonID = @PersonId
                          AND ldla.LicenseClassID = @LicenseClassId
                          AND a.ApplicationStatus <> @Cancelled
                          AND ldla.LocalDrivingLicenseApplicationID <> @ExcludedId
                    ) THEN 1 ELSE 0 END AS bit)";

                return await connection.ExecuteScalarAsync<bool>(sql, new
                {
                    PersonId = personId,
                    LicenseClassId = licenseClassId,
                    Cancelled = (int)ApplicationStatus.Cancelled,
                    ExcludedId = excludedLocalLicenseAppId
                });
            }
        }
    }
}
