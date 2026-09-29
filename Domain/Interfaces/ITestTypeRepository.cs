using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITestTypeRepository
    {
        Task<IEnumerable<TestType>> GetAllTestTypesAsync();
        Task<bool> UpdateTestTypeAsync(int id, TestType testType);
        Task<TestType> GetTestTypeByIdAsync(int id);
    }
}
