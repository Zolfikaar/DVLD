using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILocalLicenseRepository
    {
        Task<IEnumerable<LocalLicense>> GetAllLocalLicenseAsync();
        Task<LocalLicense> GetLocalLicenseByIdAsync(int id);
        Task<int> AddLocalLicenseAsync(LocalLicense localLicense);
        Task <bool> UpdateLocalLicenseAsync(LocalLicense license, int id);
        Task <bool> DeleteLocalLicenseAsync(int id);

    }
}
