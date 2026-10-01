using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILicenseRepository
    {
        Task<IEnumerable<LicenseClass>> GetAllLicenseClassesAsync();
        Task<LicenseClass> GetLicenseClassByIdAsync(int licenseClassId);

        Task<License> GetLicenseByIdAsync(int licenseId);
        Task<License> GetLatestLicenseByNationalNoAsync(string nationalNo, int? licenseClassId);
        Task<IEnumerable<License>> GetLicensesByPersonIdAsync(int personId);
        Task<int> IssueFirstTimeLicenseAsync(int applicationId, int personId, int licenseClassId, string? notes, int createdByUserId);
        Task<int> RenewLicenseAsync(License oldLicense, string? notes, int createdByUserId);
        Task<int> ReplaceLicenseAsync(License oldLicense, bool isLost, decimal replacementFees, int createdByUserId);

        Task<IEnumerable<InternationalLicense>> GetAllInternationalLicensesAsync();
        Task<IEnumerable<InternationalLicense>> GetInternationalLicensesByPersonIdAsync(int personId);
        Task<InternationalLicense> GetActiveInternationalLicenseByDriverIdAsync(int driverId);
        Task<int> IssueInternationalLicenseAsync(License localLicense, int createdByUserId);

        Task<IEnumerable<DetainedLicense>> GetAllDetainedLicensesAsync();
        Task<DetainedLicense> GetActiveDetainByLicenseIdAsync(int licenseId);
        Task<int> DetainLicenseAsync(int licenseId, decimal fineFees, int createdByUserId);
        Task<int> ReleaseDetainedLicenseAsync(DetainedLicense detainedLicense, int personId, int releasedByUserId);
    }
}
