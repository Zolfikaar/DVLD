using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IApplicationTypeRepository
    {
        Task<IEnumerable<ApplicationType>> GetAllApplicationTypesAsync();
        Task<bool> UpdateApplicationTypeAsync(int id, ApplicationType applicationType);
        Task<ApplicationType> GetApplicationTypeByIdAsync(int id);
    }
}
