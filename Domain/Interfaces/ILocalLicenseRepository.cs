using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILocalLicenseRepository
    {
        Task<IEnumerable<LocalLicense>> GetAllLocalLicenseAsync();
        Task<LocalLicense> GetLocalLicenseByIdAsync(int id);
        Task<int> AddLocalLicenseAsync(LocalLicense localLicense);
        Task<bool> UpdateLocalLicenseAsync(LocalLicense license, int id);
        Task<bool> DeleteLocalLicenseAsync(int id);
        Task<bool> CancelLocalLicenseAsync(int id);
        Task<bool> HasActiveApplicationAsync(int personId, int licenseClassId, int excludedLocalLicenseAppId);
    }
}
