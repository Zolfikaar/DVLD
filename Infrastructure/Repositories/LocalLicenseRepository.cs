using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DB;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public class LocalLicenseRepository : ILocalLicenseRepository
    {
        

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
                string sql = @"
                    SELECT 
                        LocalDrivingLicenseApplicationID,
                        ClassName,
                        NationalNo,
                        FullName,
                        ApplicationDate,
                        PassedTestCount,
                        Status
                    FROM LocalDrivingLicenseApplications_View
                    ORDER BY LocalDrivingLicenseApplicationID DESC";

                return await connection.QueryAsync<LocalLicense>(sql);
            }
        }

        public async Task<LocalLicense> GetLocalLicenseByIdAsync(int id)
        {
            using (var connection = CreateConnection())
            {
                string sql = @"
                    SELECT 
                        LocalDrivingLicenseApplicationID,
                        ClassName,
                        NationalNo,
                        FullName,
                        ApplicationDate,
                        PassedTestCount,
                        Status
                    FROM LocalDrivingLicenseApplications_View
                    WHERE LocalDrivingLicenseApplicationID = @Id";

                return await connection.QueryFirstOrDefaultAsync<LocalLicense>(sql, new { Id = id });
            }
        }

        public async Task<int> AddLocalLicenseAsync(LocalLicense localLicense)
        {
            // تنفيذ الإضافة عبر الجداول الأساسية لمنع أخطاء الـ View
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. إضافة الطلب الأساسي
                        string sqlApp = @"
                            INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                            VALUES (@ApplicantPersonID, GETDATE(), 1, 1, GETDATE(), 15.00, @CreatedByUserID);
                            SELECT CAST(SCOPE_IDENTITY() as int);";

                        // ملاحظة: افترضنا القيم الأساسية للطلب
                        int appId = await connection.ExecuteScalarAsync<int>(sqlApp, new
                        {
                            ApplicantPersonID = localLicense.ApplicantPersonID,
                            CreatedByUserID = localLicense.CreatedByUserID
                        }, transaction: transaction);

                        // 2. ربطه بطلب الرخصة المحلية
                        string sqlLocal = @"
                            INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                            VALUES (@ApplicationID, @LicenseClassID);
                            SELECT CAST(SCOPE_IDENTITY() as int);";

                        int localAppId = await connection.ExecuteScalarAsync<int>(sqlLocal, new { ApplicationID = appId, LicenseClassID = localLicense.LicenseClassID }, transaction: transaction);

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
            return await Task.FromResult(true); // غير مستخدم غالباً في هذا الموديول
        }

        public async Task<bool> DeleteLocalLicenseAsync(int id)
        {
            using (var connection = CreateConnection())
            {
                string sql = "DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @Id";
                int rows = await connection.ExecuteAsync(sql, new { Id = id });
                return rows > 0;
            }
        }
    }
}