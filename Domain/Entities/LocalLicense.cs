using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class LocalLicense
    {
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public int LicenseClassID { get; set; }
        public int CreatedByUserID { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public string NationalNo { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime ApplicationDate { get; set; }
        public int PassedTestCount { get; set; }
        public string Status { get; set; } = string.Empty;

    }
}
