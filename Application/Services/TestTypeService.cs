using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Interfaces;

namespace Application.Services
{
    public class TestTypeService
    {
        private readonly ITestTypeRepository _testTypeRepository;
        public TestTypeService(ITestTypeRepository testTypeRepository)
        {
            _testTypeRepository = testTypeRepository;
        }
        public async Task<IEnumerable<TestTypeDto>> GetAllTestTypesAsync()
        {
            var testTypes = await _testTypeRepository.GetAllTestTypesAsync();
            return testTypes.Select(tt => new TestTypeDto
            {
                TestTypeID = tt.TestTypeID,
                TestTypeTitle = tt.TestTypeTitle,
                TestTypeDescription = tt.TestTypeDescription,
                TestTypeFees = tt.TestTypeFees
            });
        }
        public async Task<bool> UpdateTestTypeAsync(int id, TestTypeDto testTypeDto)
        {
            var testTypeEntity = new Domain.Entities.TestType
            {
                TestTypeID = testTypeDto.TestTypeID,
                TestTypeTitle = testTypeDto.TestTypeTitle,
                TestTypeDescription = testTypeDto.TestTypeDescription,
                TestTypeFees = testTypeDto.TestTypeFees
            };
            return await _testTypeRepository.UpdateTestTypeAsync(id, testTypeEntity);
        }
        public async Task<TestTypeDto> GetTestTypeByIdAsync(int id)
        {
            var testType = await _testTypeRepository.GetTestTypeByIdAsync(id);
            if (testType == null) return null;
            return new TestTypeDto
            {
                TestTypeID = testType.TestTypeID,
                TestTypeTitle = testType.TestTypeTitle,
                TestTypeDescription = testType.TestTypeDescription,
                TestTypeFees = testType.TestTypeFees
            };
        }
    }
}
