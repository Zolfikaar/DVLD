using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Infrastructure.DB;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public class LicenseRepository : ILicenseRepository
    {
        private const string PersonFullName =
            "LTRIM(RTRIM(p.FirstName + ' ' + p.SecondName + ' ' + ISNULL(p.ThirdName, '') + ' ' + p.LastName))";

        private const string LicenseSelect = @"
            SELECT
                l.LicenseID,
                l.ApplicationID,
                l.DriverID,
                l.LicenseClass AS LicenseClassID,
                lc.ClassName,
                l.IssueDate,
                l.ExpirationDate,
                l.Notes,
                l.PaidFees,
                l.IsActive,
                l.IssueReason,
                l.CreatedByUserID,
                d.PersonID,
                p.NationalNo,
                " + PersonFullName + @" AS FullName,
                p.Gender,
                p.DateOfBirth,
                p.ImagePath,
                CAST(CASE WHEN EXISTS (
                    SELECT 1 FROM DetainedLicenses dl WHERE dl.LicenseID = l.LicenseID AND dl.IsReleased = 0
                ) THEN 1 ELSE 0 END AS bit) AS IsDetained
            FROM Licenses l
            INNER JOIN Drivers d ON d.DriverID = l.DriverID
            INNER JOIN People p ON p.PersonID = d.PersonID
            INNER JOIN LicenseClasses lc ON lc.LicenseClassID = l.LicenseClass";

        private const string InternationalLicenseSelect = @"
            SELECT
                il.InternationalLicenseID,
                il.ApplicationID,
                il.DriverID,
                il.IssuedUsingLocalLicenseID,
                il.IssueDate,
                il.ExpirationDate,
                il.IsActive,
                il.CreatedByUserID,
                d.PersonID,
                p.NationalNo,
                " + PersonFullName + @" AS FullName
            FROM InternationalLicenses il
            INNER JOIN Drivers d ON d.DriverID = il.DriverID
            INNER JOIN People p ON p.PersonID = d.PersonID";

        private const string DetainedLicenseSelect = @"
            SELECT
                dl.DetainID,
                dl.LicenseID,
                dl.DetainDate,
                dl.FineFees,
                dl.CreatedByUserID,
                dl.IsReleased,
                dl.ReleaseDate,
                dl.ReleasedByUserID,
                dl.ReleaseApplicationID,
                p.NationalNo,
                " + PersonFullName + @" AS FullName
            FROM DetainedLicenses dl
            INNER JOIN Licenses l ON l.LicenseID = dl.LicenseID
            INNER JOIN Drivers d ON d.DriverID = l.DriverID
            INNER JOIN People p ON p.PersonID = d.PersonID";

        private const string InsertCompletedApplication = @"
            INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
            VALUES (@ApplicantPersonID, GETDATE(), @ApplicationTypeID, @Status, GETDATE(),
                    (SELECT ApplicationFees FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID),
                    @CreatedByUserID);
            SELECT CAST(SCOPE_IDENTITY() as int);";

        public LicenseRepository()
        {
            CreateConnection();
        }

        private SqlConnection CreateConnection()
        {
            return DbInitializer.Connection();
        }

        private static Task<int> InsertCompletedApplicationAsync(IDbConnection connection, IDbTransaction transaction,
            int personId, ApplicationTypeId applicationType, int createdByUserId)
        {
            return connection.ExecuteScalarAsync<int>(InsertCompletedApplication, new
            {
                ApplicantPersonID = personId,
                ApplicationTypeID = (int)applicationType,
                Status = (int)ApplicationStatus.Completed,
                CreatedByUserID = createdByUserId
            }, transaction);
        }

        // ---------- License classes ----------

        public async Task<IEnumerable<LicenseClass>> GetAllLicenseClassesAsync()
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<LicenseClass>("SELECT * FROM LicenseClasses ORDER BY LicenseClassID");
            }
        }

        public async Task<LicenseClass> GetLicenseClassByIdAsync(int licenseClassId)
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<LicenseClass>(
                    "SELECT * FROM LicenseClasses WHERE LicenseClassID = @Id", new { Id = licenseClassId });
            }
        }

        // ---------- Local licenses ----------

        public async Task<License> GetLicenseByIdAsync(int licenseId)
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<License>(
                    LicenseSelect + " WHERE l.LicenseID = @Id", new { Id = licenseId });
            }
        }

        public async Task<License> GetLatestLicenseByNationalNoAsync(string nationalNo, int? licenseClassId)
        {
            using (var connection = CreateConnection())
            {
                string sql = LicenseSelect + @"
                    WHERE p.NationalNo = @NationalNo AND (@LicenseClassId IS NULL OR l.LicenseClass = @LicenseClassId)
                    ORDER BY l.IsActive DESC, l.LicenseID DESC";

                return await connection.QueryFirstOrDefaultAsync<License>(sql,
                    new { NationalNo = nationalNo, LicenseClassId = licenseClassId });
            }
        }

        public async Task<IEnumerable<License>> GetLicensesByPersonIdAsync(int personId)
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<License>(
                    LicenseSelect + " WHERE d.PersonID = @PersonId ORDER BY l.IsActive DESC, l.ExpirationDate DESC",
                    new { PersonId = personId });
            }
        }

        public async Task<int> IssueFirstTimeLicenseAsync(int applicationId, int personId, int licenseClassId, string? notes, int createdByUserId)
        {
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int? driverId = await connection.ExecuteScalarAsync<int?>(
                            "SELECT TOP 1 DriverID FROM Drivers WHERE PersonID = @PersonId",
                            new { PersonId = personId }, transaction);

                        if (driverId == null)
                        {
                            driverId = await connection.ExecuteScalarAsync<int>(@"
                                INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
                                VALUES (@PersonId, @CreatedByUserID, GETDATE());
                                SELECT CAST(SCOPE_IDENTITY() as int);",
                                new { PersonId = personId, CreatedByUserID = createdByUserId }, transaction);
                        }

                        int licenseId = await connection.ExecuteScalarAsync<int>(@"
                            INSERT INTO Licenses (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                            SELECT @ApplicationID, @DriverID, lc.LicenseClassID, GETDATE(), DATEADD(YEAR, lc.DefaultValidityLength, GETDATE()),
                                   @Notes, lc.ClassFees, 1, @IssueReason, @CreatedByUserID
                            FROM LicenseClasses lc
                            WHERE lc.LicenseClassID = @LicenseClassID;
                            SELECT CAST(SCOPE_IDENTITY() as int);",
                            new
                            {
                                ApplicationID = applicationId,
                                DriverID = driverId,
                                Notes = notes,
                                IssueReason = (int)IssueReason.FirstTime,
                                CreatedByUserID = createdByUserId,
                                LicenseClassID = licenseClassId
                            }, transaction);

                        await connection.ExecuteAsync(
                            "UPDATE Applications SET ApplicationStatus = @Completed, LastStatusDate = GETDATE() WHERE ApplicationID = @ApplicationID",
                            new { Completed = (int)ApplicationStatus.Completed, ApplicationID = applicationId }, transaction);

                        transaction.Commit();
                        return licenseId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public async Task<int> RenewLicenseAsync(License oldLicense, string? notes, int createdByUserId)
        {
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int applicationId = await InsertCompletedApplicationAsync(connection, transaction,
                            oldLicense.PersonID, ApplicationTypeId.RenewLicense, createdByUserId);

                        int licenseId = await connection.ExecuteScalarAsync<int>(@"
                            INSERT INTO Licenses (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                            SELECT @ApplicationID, @DriverID, lc.LicenseClassID, GETDATE(), DATEADD(YEAR, lc.DefaultValidityLength, GETDATE()),
                                   @Notes, lc.ClassFees, 1, @IssueReason, @CreatedByUserID
                            FROM LicenseClasses lc
                            WHERE lc.LicenseClassID = @LicenseClassID;
                            SELECT CAST(SCOPE_IDENTITY() as int);",
                            new
                            {
                                ApplicationID = applicationId,
                                oldLicense.DriverID,
                                Notes = notes,
                                IssueReason = (int)IssueReason.Renew,
                                CreatedByUserID = createdByUserId,
                                oldLicense.LicenseClassID
                            }, transaction);

                        await connection.ExecuteAsync("UPDATE Licenses SET IsActive = 0 WHERE LicenseID = @LicenseID",
                            new { oldLicense.LicenseID }, transaction);

                        transaction.Commit();
                        return licenseId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public async Task<int> ReplaceLicenseAsync(License oldLicense, bool isLost, decimal replacementFees, int createdByUserId)
        {
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int applicationId = await InsertCompletedApplicationAsync(connection, transaction, oldLicense.PersonID,
                            isLost ? ApplicationTypeId.ReplaceLostLicense : ApplicationTypeId.ReplaceDamagedLicense, createdByUserId);

                        int licenseId = await connection.ExecuteScalarAsync<int>(@"
                            INSERT INTO Licenses (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                            VALUES (@ApplicationID, @DriverID, @LicenseClassID, GETDATE(), @ExpirationDate, @Notes, @PaidFees, 1, @IssueReason, @CreatedByUserID);
                            SELECT CAST(SCOPE_IDENTITY() as int);",
                            new
                            {
                                ApplicationID = applicationId,
                                oldLicense.DriverID,
                                oldLicense.LicenseClassID,
                                oldLicense.ExpirationDate,
                                oldLicense.Notes,
                                PaidFees = replacementFees,
                                IssueReason = (int)(isLost ? IssueReason.ReplacementForLost : IssueReason.ReplacementForDamaged),
                                CreatedByUserID = createdByUserId
                            }, transaction);

                        await connection.ExecuteAsync("UPDATE Licenses SET IsActive = 0 WHERE LicenseID = @LicenseID",
                            new { oldLicense.LicenseID }, transaction);

                        transaction.Commit();
                        return licenseId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // ---------- International licenses ----------

        public async Task<IEnumerable<InternationalLicense>> GetAllInternationalLicensesAsync()
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<InternationalLicense>(
                    InternationalLicenseSelect + " ORDER BY il.InternationalLicenseID DESC");
            }
        }

        public async Task<IEnumerable<InternationalLicense>> GetInternationalLicensesByPersonIdAsync(int personId)
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<InternationalLicense>(
                    InternationalLicenseSelect + " WHERE d.PersonID = @PersonId ORDER BY il.InternationalLicenseID DESC",
                    new { PersonId = personId });
            }
        }

        public async Task<InternationalLicense> GetActiveInternationalLicenseByDriverIdAsync(int driverId)
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<InternationalLicense>(
                    InternationalLicenseSelect + " WHERE il.DriverID = @DriverId AND il.IsActive = 1 ORDER BY il.ExpirationDate DESC",
                    new { DriverId = driverId });
            }
        }

        public async Task<int> IssueInternationalLicenseAsync(License localLicense, int createdByUserId)
        {
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int applicationId = await InsertCompletedApplicationAsync(connection, transaction,
                            localLicense.PersonID, ApplicationTypeId.NewInternationalLicense, createdByUserId);

                        await connection.ExecuteAsync(
                            "UPDATE InternationalLicenses SET IsActive = 0 WHERE DriverID = @DriverID AND IsActive = 1",
                            new { localLicense.DriverID }, transaction);

                        int internationalLicenseId = await connection.ExecuteScalarAsync<int>(@"
                            INSERT INTO InternationalLicenses (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
                            VALUES (@ApplicationID, @DriverID, @LicenseID, GETDATE(), DATEADD(YEAR, 1, GETDATE()), 1, @CreatedByUserID);
                            SELECT CAST(SCOPE_IDENTITY() as int);",
                            new
                            {
                                ApplicationID = applicationId,
                                localLicense.DriverID,
                                localLicense.LicenseID,
                                CreatedByUserID = createdByUserId
                            }, transaction);

                        transaction.Commit();
                        return internationalLicenseId;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // ---------- Detained licenses ----------

        public async Task<IEnumerable<DetainedLicense>> GetAllDetainedLicensesAsync()
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<DetainedLicense>(
                    DetainedLicenseSelect + " ORDER BY dl.IsReleased, dl.DetainID DESC");
            }
        }

        public async Task<DetainedLicense> GetActiveDetainByLicenseIdAsync(int licenseId)
        {
            using (var connection = CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<DetainedLicense>(
                    DetainedLicenseSelect + " WHERE dl.LicenseID = @LicenseId AND dl.IsReleased = 0",
                    new { LicenseId = licenseId });
            }
        }

        public async Task<int> DetainLicenseAsync(int licenseId, decimal fineFees, int createdByUserId)
        {
            using (var connection = CreateConnection())
            {
                string sql = @"
                    INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased)
                    VALUES (@LicenseID, GETDATE(), @FineFees, @CreatedByUserID, 0);
                    SELECT CAST(SCOPE_IDENTITY() as int);";

                return await connection.ExecuteScalarAsync<int>(sql, new
                {
                    LicenseID = licenseId,
                    FineFees = fineFees,
                    CreatedByUserID = createdByUserId
                });
            }
        }

        public async Task<int> ReleaseDetainedLicenseAsync(DetainedLicense detainedLicense, int personId, int releasedByUserId)
        {
            using (var connection = CreateConnection())
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int applicationId = await InsertCompletedApplicationAsync(connection, transaction,
                            personId, ApplicationTypeId.ReleaseDetainedLicense, releasedByUserId);

                        int rows = await connection.ExecuteAsync(@"
                            UPDATE DetainedLicenses
                            SET IsReleased = 1, ReleaseDate = GETDATE(), ReleasedByUserID = @ReleasedByUserID, ReleaseApplicationID = @ReleaseApplicationID
                            WHERE DetainID = @DetainID AND IsReleased = 0",
                            new
                            {
                                ReleasedByUserID = releasedByUserId,
                                ReleaseApplicationID = applicationId,
                                detainedLicense.DetainID
                            }, transaction);

                        if (rows == 0)
                            throw new InvalidOperationException("This license has already been released.");

                        transaction.Commit();
                        return applicationId;
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
