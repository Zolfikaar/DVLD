using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class LicenseService
    {
        public const int OrdinaryLicenseClassId = 3;
        public const int RenewalWindowDays = 30;
        public const decimal ReplacementFees = 20m;

        private readonly ILicenseRepository _licenseRepository;
        private readonly ILocalLicenseRepository _localLicenseRepository;

        public LicenseService(ILicenseRepository licenseRepository, ILocalLicenseRepository localLicenseRepository)
        {
            _licenseRepository = licenseRepository;
            _localLicenseRepository = localLicenseRepository;
        }

        public static string GetIssueReasonText(int issueReason)
        {
            switch (issueReason)
            {
                case 1: return "First Time";
                case 2: return "Renew";
                case 3: return "Replacement for Damaged";
                case 4: return "Replacement for Lost";
                default: return "Unknown";
            }
        }

        private static LicenseDto ToDto(License l)
        {
            return new LicenseDto
            {
                LicenseID = l.LicenseID,
                ApplicationID = l.ApplicationID,
                DriverID = l.DriverID,
                LicenseClassID = l.LicenseClassID,
                ClassName = l.ClassName,
                IssueDate = l.IssueDate,
                ExpirationDate = l.ExpirationDate,
                Notes = l.Notes ?? string.Empty,
                PaidFees = l.PaidFees,
                IsActive = l.IsActive,
                IssueReason = l.IssueReason,
                IssueReasonText = GetIssueReasonText(l.IssueReason),
                CreatedByUserID = l.CreatedByUserID,
                PersonID = l.PersonID,
                NationalNo = l.NationalNo,
                FullName = l.FullName,
                GenderText = l.Gender == 0 ? "Male" : "Female",
                DateOfBirth = l.DateOfBirth,
                ImagePath = l.ImagePath,
                IsDetained = l.IsDetained
            };
        }

        private static License ToEntity(LicenseDto l)
        {
            return new License
            {
                LicenseID = l.LicenseID,
                ApplicationID = l.ApplicationID,
                DriverID = l.DriverID,
                LicenseClassID = l.LicenseClassID,
                IssueDate = l.IssueDate,
                ExpirationDate = l.ExpirationDate,
                Notes = string.IsNullOrWhiteSpace(l.Notes) ? null : l.Notes,
                PaidFees = l.PaidFees,
                IsActive = l.IsActive,
                IssueReason = (byte)l.IssueReason,
                CreatedByUserID = l.CreatedByUserID,
                PersonID = l.PersonID
            };
        }

        private static InternationalLicenseDto ToDto(InternationalLicense il)
        {
            return new InternationalLicenseDto
            {
                InternationalLicenseID = il.InternationalLicenseID,
                ApplicationID = il.ApplicationID,
                DriverID = il.DriverID,
                IssuedUsingLocalLicenseID = il.IssuedUsingLocalLicenseID,
                IssueDate = il.IssueDate,
                ExpirationDate = il.ExpirationDate,
                IsActive = il.IsActive,
                CreatedByUserID = il.CreatedByUserID,
                PersonID = il.PersonID,
                NationalNo = il.NationalNo,
                FullName = il.FullName
            };
        }

        private static DetainedLicenseDto ToDto(DetainedLicense dl)
        {
            return new DetainedLicenseDto
            {
                DetainID = dl.DetainID,
                LicenseID = dl.LicenseID,
                DetainDate = dl.DetainDate,
                FineFees = dl.FineFees,
                CreatedByUserID = dl.CreatedByUserID,
                IsReleased = dl.IsReleased,
                ReleaseDate = dl.ReleaseDate,
                ReleasedByUserID = dl.ReleasedByUserID,
                ReleaseApplicationID = dl.ReleaseApplicationID,
                NationalNo = dl.NationalNo,
                FullName = dl.FullName
            };
        }

        // ---------- License classes ----------

        public async Task<IEnumerable<LicenseClassDto>> GetAllLicenseClassesAsync()
        {
            var classes = await _licenseRepository.GetAllLicenseClassesAsync();
            return classes.Select(c => new LicenseClassDto
            {
                LicenseClassID = c.LicenseClassID,
                ClassName = c.ClassName,
                ClassDescription = c.ClassDescription,
                MinimumAllowedAge = c.MinimumAllowedAge,
                DefaultValidityLength = c.DefaultValidityLength,
                ClassFees = c.ClassFees
            }).ToList();
        }

        public async Task<LicenseClassDto?> GetLicenseClassByIdAsync(int licenseClassId)
        {
            var c = await _licenseRepository.GetLicenseClassByIdAsync(licenseClassId);
            if (c == null) return null;

            return new LicenseClassDto
            {
                LicenseClassID = c.LicenseClassID,
                ClassName = c.ClassName,
                ClassDescription = c.ClassDescription,
                MinimumAllowedAge = c.MinimumAllowedAge,
                DefaultValidityLength = c.DefaultValidityLength,
                ClassFees = c.ClassFees
            };
        }

        // ---------- Local licenses ----------

        public async Task<LicenseDto?> GetLicenseByIdAsync(int licenseId)
        {
            var license = await _licenseRepository.GetLicenseByIdAsync(licenseId);
            return license == null ? null : ToDto(license);
        }

        public async Task<LicenseDto?> GetLatestLicenseByNationalNoAsync(string nationalNo, int? licenseClassId = null)
        {
            var license = await _licenseRepository.GetLatestLicenseByNationalNoAsync(nationalNo, licenseClassId);
            return license == null ? null : ToDto(license);
        }

        public async Task<IEnumerable<LicenseDto>> GetLicensesByPersonIdAsync(int personId)
        {
            var licenses = await _licenseRepository.GetLicensesByPersonIdAsync(personId);
            return licenses.Select(ToDto).ToList();
        }

        public async Task<string?> GetFirstTimeIssueErrorAsync(int localLicenseAppId)
        {
            var application = await _localLicenseRepository.GetLocalLicenseByIdAsync(localLicenseAppId);
            if (application == null)
                return "The application was not found.";

            if (application.LicenseID > 0)
                return "A license was already issued for this application (License ID " + application.LicenseID + ").";

            if (application.ApplicationStatus != LocalLicenseDto.StatusNew)
                return "Only applications with status 'New' can be issued a license.";

            if (application.PassedTestCount < 3)
                return "The applicant must pass all 3 tests before a license can be issued.";

            return null;
        }

        public async Task<int> IssueFirstTimeLicenseAsync(int localLicenseAppId, string? notes, int createdByUserId)
        {
            string? error = await GetFirstTimeIssueErrorAsync(localLicenseAppId);
            if (error != null)
                throw new InvalidOperationException(error);

            var application = await _localLicenseRepository.GetLocalLicenseByIdAsync(localLicenseAppId);

            return await _licenseRepository.IssueFirstTimeLicenseAsync(application.ApplicationID, application.ApplicantPersonID,
                application.LicenseClassID, string.IsNullOrWhiteSpace(notes) ? null : notes!.Trim(), createdByUserId);
        }

        public string? GetRenewError(LicenseDto license)
        {
            if (!license.IsActive)
                return "Only the active license can be renewed. License " + license.LicenseID + " is not active.";

            if (license.IsDetained)
                return "This license is detained. Release it before renewing.";

            if (license.ExpirationDate.Date > DateTime.Today.AddDays(RenewalWindowDays))
                return "This license is not expired yet. It expires on " + license.ExpirationDate.ToShortDateString() +
                       "; renewal is allowed from " + RenewalWindowDays + " days before expiration.";

            return null;
        }

        public async Task<int> RenewLicenseAsync(int licenseId, string? notes, int createdByUserId)
        {
            var license = await GetLicenseByIdAsync(licenseId);
            if (license == null)
                throw new InvalidOperationException("The license was not found.");

            string? error = GetRenewError(license);
            if (error != null)
                throw new InvalidOperationException(error);

            return await _licenseRepository.RenewLicenseAsync(ToEntity(license),
                string.IsNullOrWhiteSpace(notes) ? null : notes!.Trim(), createdByUserId);
        }

        public string? GetReplacementError(LicenseDto license)
        {
            if (!license.IsActive)
                return "Only active licenses can be replaced. License " + license.LicenseID + " is not active.";

            if (license.IsDetained)
                return "This license is detained. Release it before requesting a replacement.";

            return null;
        }

        public async Task<int> ReplaceLicenseAsync(int licenseId, bool isLost, int createdByUserId)
        {
            var license = await GetLicenseByIdAsync(licenseId);
            if (license == null)
                throw new InvalidOperationException("The license was not found.");

            string? error = GetReplacementError(license);
            if (error != null)
                throw new InvalidOperationException(error);

            return await _licenseRepository.ReplaceLicenseAsync(ToEntity(license), isLost, ReplacementFees, createdByUserId);
        }

        // ---------- International licenses ----------

        public async Task<IEnumerable<InternationalLicenseDto>> GetAllInternationalLicensesAsync()
        {
            var licenses = await _licenseRepository.GetAllInternationalLicensesAsync();
            return licenses.Select(ToDto).ToList();
        }

        public async Task<IEnumerable<InternationalLicenseDto>> GetInternationalLicensesByPersonIdAsync(int personId)
        {
            var licenses = await _licenseRepository.GetInternationalLicensesByPersonIdAsync(personId);
            return licenses.Select(ToDto).ToList();
        }

        public async Task<InternationalLicenseDto?> GetActiveInternationalLicenseByDriverIdAsync(int driverId)
        {
            var license = await _licenseRepository.GetActiveInternationalLicenseByDriverIdAsync(driverId);
            return license == null ? null : ToDto(license);
        }

        public async Task<string?> GetInternationalIssueErrorAsync(LicenseDto license)
        {
            if (license.LicenseClassID != OrdinaryLicenseClassId)
                return "International licenses can only be issued for an ordinary driving license (Class 3).";

            if (!license.IsActive)
                return "The local license is not active.";

            if (license.IsExpired)
                return "The local license expired on " + license.ExpirationDate.ToShortDateString() + ".";

            if (license.IsDetained)
                return "The local license is detained.";

            var active = await GetActiveInternationalLicenseByDriverIdAsync(license.DriverID);
            if (active != null && active.ExpirationDate.Date >= DateTime.Today)
                return "This driver already has an active international license (ID " + active.InternationalLicenseID +
                       ") valid until " + active.ExpirationDate.ToShortDateString() + ".";

            return null;
        }

        public async Task<int> IssueInternationalLicenseAsync(int localLicenseId, int createdByUserId)
        {
            var license = await GetLicenseByIdAsync(localLicenseId);
            if (license == null)
                throw new InvalidOperationException("The local license was not found.");

            string? error = await GetInternationalIssueErrorAsync(license);
            if (error != null)
                throw new InvalidOperationException(error);

            return await _licenseRepository.IssueInternationalLicenseAsync(ToEntity(license), createdByUserId);
        }

        // ---------- Detained licenses ----------

        public async Task<IEnumerable<DetainedLicenseDto>> GetAllDetainedLicensesAsync()
        {
            var licenses = await _licenseRepository.GetAllDetainedLicensesAsync();
            return licenses.Select(ToDto).ToList();
        }

        public async Task<DetainedLicenseDto?> GetActiveDetainByLicenseIdAsync(int licenseId)
        {
            var detained = await _licenseRepository.GetActiveDetainByLicenseIdAsync(licenseId);
            return detained == null ? null : ToDto(detained);
        }

        public string? GetDetainError(LicenseDto license)
        {
            if (!license.IsActive)
                return "Only active licenses can be detained.";

            if (license.IsDetained)
                return "This license is already detained.";

            return null;
        }

        public async Task<int> DetainLicenseAsync(int licenseId, decimal fineFees, int createdByUserId)
        {
            if (fineFees <= 0)
                throw new InvalidOperationException("Fine fees must be greater than zero.");

            var license = await GetLicenseByIdAsync(licenseId);
            if (license == null)
                throw new InvalidOperationException("The license was not found.");

            string? error = GetDetainError(license);
            if (error != null)
                throw new InvalidOperationException(error);

            return await _licenseRepository.DetainLicenseAsync(licenseId, fineFees, createdByUserId);
        }

        public async Task<int> ReleaseDetainedLicenseAsync(int licenseId, int releasedByUserId)
        {
            var license = await GetLicenseByIdAsync(licenseId);
            if (license == null)
                throw new InvalidOperationException("The license was not found.");

            var detained = await _licenseRepository.GetActiveDetainByLicenseIdAsync(licenseId);
            if (detained == null)
                throw new InvalidOperationException("This license is not detained.");

            return await _licenseRepository.ReleaseDetainedLicenseAsync(detained, license.PersonID, releasedByUserId);
        }
    }
}
