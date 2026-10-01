using System;

namespace Application.DTOs
{
    public class LicenseDto
    {
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; } = string.Empty;
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public int IssueReason { get; set; }
        public string IssueReasonText { get; set; } = string.Empty;
        public int CreatedByUserID { get; set; }
        public int PersonID { get; set; }
        public string NationalNo { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string GenderText { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string? ImagePath { get; set; }
        public bool IsDetained { get; set; }
        public bool IsExpired => ExpirationDate.Date < DateTime.Today;
    }

    public class LicenseClassDto
    {
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public string ClassDescription { get; set; } = string.Empty;
        public int MinimumAllowedAge { get; set; }
        public int DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }
    }

    public class InternationalLicenseDto
    {
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public int PersonID { get; set; }
        public string NationalNo { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }

    public class DetainedLicenseDto
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }
        public string NationalNo { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }
}
