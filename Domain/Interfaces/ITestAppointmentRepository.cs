using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITestAppointmentRepository
    {
        Task<IEnumerable<TestAppointment>> GetAppointmentsAsync(int localLicenseAppId, int testTypeId);
        Task<TestAppointment> GetAppointmentByIdAsync(int testAppointmentId);
        Task<bool> HasActiveAppointmentAsync(int localLicenseAppId, int testTypeId);
        Task<bool> HasPassedTestAsync(int localLicenseAppId, int testTypeId);
        Task<bool> HasAttendedTestAsync(int localLicenseAppId, int testTypeId);
        Task<int> AddAppointmentAsync(TestAppointment appointment, bool isRetake, int applicantPersonId);
        Task<bool> UpdateAppointmentDateAsync(int testAppointmentId, DateTime appointmentDate);
        Task<int> TakeTestAsync(int testAppointmentId, bool testResult, string? notes, int createdByUserId);
    }
}
