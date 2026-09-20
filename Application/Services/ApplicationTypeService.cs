using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Interfaces;

namespace Application.Services
{
    public class ApplicationTypeService
    {
        private readonly IApplicationTypeRepository _applicationTypeRepository;

        public ApplicationTypeService(IApplicationTypeRepository applicationTypeRepository)
        {
            _applicationTypeRepository = applicationTypeRepository;
        }

        public async Task<IEnumerable<ApplicationTypeDto>> GetAllApplicationTypesAsync()
        {
            var applicationTypes = await _applicationTypeRepository.GetAllApplicationTypesAsync();
            return applicationTypes.Select(at => new ApplicationTypeDto
            {
                ApplicationTypeID = at.ApplicationTypeID,
                ApplicationTypeTitle = at.ApplicationTypeTitle,
                ApplicationFees = at.ApplicationFees
            });

            
        }

        public async Task<bool> UpdateApplicationTypeAsync(int id, ApplicationTypeDto applicationTypeDto)
        {
            var applicationTypeEntity = new Domain.Entities.ApplicationType
            {
                ApplicationTypeID = applicationTypeDto.ApplicationTypeID,
                ApplicationTypeTitle = applicationTypeDto.ApplicationTypeTitle,
                ApplicationFees = applicationTypeDto.ApplicationFees
            };
            return await _applicationTypeRepository.UpdateApplicationTypeAsync(id, applicationTypeEntity);
        }

        public async Task<ApplicationTypeDto> GetApplicationTypeByIdAsync(int id)
        {
            var applicationType = await _applicationTypeRepository.GetApplicationTypeByIdAsync(id);
            if (applicationType == null) return null;
            return new ApplicationTypeDto
            {
                ApplicationTypeID = applicationType.ApplicationTypeID,
                ApplicationTypeTitle = applicationType.ApplicationTypeTitle,
                ApplicationFees = applicationType.ApplicationFees
            };
        }
    }
}
