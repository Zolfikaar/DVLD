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

        private static LocalLicenseDto ToDto(LocalLicense ls)
        {
            return new LocalLicenseDto
            {
                LocalDrivingLicenseApplicationID = ls.LocalDrivingLicenseApplicationID,
                ApplicationID = ls.ApplicationID,
                ApplicantPersonID = ls.ApplicantPersonID,
                LicenseClassID = ls.LicenseClassID,
                CreatedByUserID = ls.CreatedByUserID,
                CreatedByUserName = ls.CreatedByUserName,
                ApplicationTypeTitle = ls.ApplicationTypeTitle,
                ApplicationStatus = ls.ApplicationStatus,
                PaidFees = ls.PaidFees,
                LastStatusDate = ls.LastStatusDate,
                LicenseID = ls.LicenseID,
                ClassName = ls.ClassName,
                NationalNo = ls.NationalNo,
                FullName = ls.FullName,
                ApplicationDate = ls.ApplicationDate,
                PassedTestCount = ls.PassedTestCount,
                Status = ls.Status
            };
        }

        public async Task<IEnumerable<LocalLicenseDto>> GetAllLocalLicenseAsync()
        {
            var localLicenses = await _localLicenseRepository.GetAllLocalLicenseAsync();
            if (localLicenses == null) return new List<LocalLicenseDto>();

            return localLicenses.Select(ToDto).ToList();
        }

        public async Task<LocalLicenseDto?> GetLocalLicenseByIdAsync(int licenseId)
        {
            var localLicense = await _localLicenseRepository.GetLocalLicenseByIdAsync(licenseId);
            return localLicense == null ? null : ToDto(localLicense);
        }

        public async Task<bool> HasActiveApplicationAsync(int personId, int licenseClassId, int excludedLocalLicenseAppId = -1)
        {
            return await _localLicenseRepository.HasActiveApplicationAsync(personId, licenseClassId, excludedLocalLicenseAppId);
        }

        public async Task<int> AddLocalLicenseAsync(LocalLicenseDto localLicenseDto)
        {
            if (localLicenseDto == null)
                throw new ArgumentNullException(nameof(localLicenseDto));

            if (await HasActiveApplicationAsync(localLicenseDto.ApplicantPersonID, localLicenseDto.LicenseClassID))
                throw new InvalidOperationException(
                    "This person already has an application for the selected license class that is not cancelled.");

            var entity = new LocalLicense
            {
                ApplicantPersonID = localLicenseDto.ApplicantPersonID,
                LicenseClassID = localLicenseDto.LicenseClassID,
                CreatedByUserID = localLicenseDto.CreatedByUserID
            };

            return await _localLicenseRepository.AddLocalLicenseAsync(entity);
        }

        public async Task<bool> UpdateLocalLicenseAsync(int localLicenseAppId, int licenseClassId)
        {
            var current = await _localLicenseRepository.GetLocalLicenseByIdAsync(localLicenseAppId);
            if (current == null)
                throw new InvalidOperationException("The application was not found.");

            if (current.ApplicationStatus != LocalLicenseDto.StatusNew)
                throw new InvalidOperationException("Only applications with status 'New' can be edited.");

            if (current.LicenseClassID == licenseClassId)
                return true;

            if (current.PassedTestCount > 0)
                throw new InvalidOperationException("The license class cannot be changed after the applicant has passed a test.");

            if (await HasActiveApplicationAsync(current.ApplicantPersonID, licenseClassId, localLicenseAppId))
                throw new InvalidOperationException(
                    "This person already has an application for the selected license class that is not cancelled.");

            return await _localLicenseRepository.UpdateLocalLicenseAsync(
                new LocalLicense { LicenseClassID = licenseClassId }, localLicenseAppId);
        }

        public async Task<bool> CancelLocalLicenseAsync(int localLicenseAppId)
        {
            return await _localLicenseRepository.CancelLocalLicenseAsync(localLicenseAppId);
        }

        public async Task<bool> DeleteLocalLicenseAsync(int licenseId)
        {
            return await _localLicenseRepository.DeleteLocalLicenseAsync(licenseId);
        }
    }
}
