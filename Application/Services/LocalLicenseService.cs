using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class LocalLicenseService
    {
        private readonly ILocalLicenseRepository _localLicenseRepository;

        public LocalLicenseService(ILocalLicenseRepository localLicenseRepository)
        {
            _localLicenseRepository = localLicenseRepository;
        }

        public async Task<IEnumerable<LocalLicenseDto>> GetAllLocalLicenseAsync()
        {
            var localLicenses = await _localLicenseRepository.GetAllLocalLicenseAsync();
            if (localLicenses == null) return new List<LocalLicenseDto>();

            return localLicenses.Select(ls => new LocalLicenseDto
            {
                LocalDrivingLicenseApplicationID = ls.LocalDrivingLicenseApplicationID,
                ClassName = ls.ClassName,
                NationalNo = ls.NationalNo,
                FullName = ls.FullName,
                ApplicationDate = ls.ApplicationDate,
                PassedTestCount = ls.PassedTestCount,
                Status = ls.Status
            });
        }

        public async Task<LocalLicenseDto> GetLocalLicenseByIdAsync(int licenseId)
        {
            var localLicense = await _localLicenseRepository.GetLocalLicenseByIdAsync(licenseId);
            if (localLicense == null) return null;

            return new LocalLicenseDto
            {
                LocalDrivingLicenseApplicationID = localLicense.LocalDrivingLicenseApplicationID,
                ClassName = localLicense.ClassName,
                NationalNo = localLicense.NationalNo,
                FullName = localLicense.FullName,
                ApplicationDate = localLicense.ApplicationDate,
                PassedTestCount = localLicense.PassedTestCount,
                Status = localLicense.Status
            };
        }

        public async Task<int> AddLocalLicenseAsync(LocalLicenseDto localLicenseDto)
        {
            if (localLicenseDto == null)
                throw new ArgumentNullException(nameof(localLicenseDto));

            var entity = new LocalLicense
            {
                LocalDrivingLicenseApplicationID = localLicenseDto.LocalDrivingLicenseApplicationID,
                ClassName = localLicenseDto.ClassName,
                NationalNo = localLicenseDto.NationalNo,
                FullName = localLicenseDto.FullName,
                ApplicationDate = localLicenseDto.ApplicationDate,
                PassedTestCount = localLicenseDto.PassedTestCount,
                Status = localLicenseDto.Status
            };

            return await _localLicenseRepository.AddLocalLicenseAsync(entity);
        }

        public async Task<bool> DeleteLocalLicenseAsync(int licenseId)
        {
            return await _localLicenseRepository.DeleteLocalLicenseAsync(licenseId);
        }
    }
}