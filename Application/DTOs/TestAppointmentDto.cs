using System;

namespace Application.DTOs
{
    public class TestAppointmentDto
    {
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int? RetakeTestApplicationID { get; set; }
        public decimal RetakeFees { get; set; }
        public int? TestID { get; set; }
        public bool? TestResult { get; set; }
    }
}
