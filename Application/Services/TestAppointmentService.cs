using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class TestAppointmentService
    {
        private readonly ITestAppointmentRepository _testAppointmentRepository;
        private readonly ILocalLicenseRepository _localLicenseRepository;

        public TestAppointmentService(ITestAppointmentRepository testAppointmentRepository, ILocalLicenseRepository localLicenseRepository)
        {
            _testAppointmentRepository = testAppointmentRepository;
            _localLicenseRepository = localLicenseRepository;
        }

        private static TestAppointmentDto ToDto(TestAppointment a)
        {
            return new TestAppointmentDto
            {
                TestAppointmentID = a.TestAppointmentID,
                TestTypeID = a.TestTypeID,
                LocalDrivingLicenseApplicationID = a.LocalDrivingLicenseApplicationID,
                AppointmentDate = a.AppointmentDate,
                PaidFees = a.PaidFees,
                CreatedByUserID = a.CreatedByUserID,
                IsLocked = a.IsLocked,
                RetakeTestApplicationID = a.RetakeTestApplicationID,
                RetakeFees = a.RetakeFees,
                TestID = a.TestID,
                TestResult = a.TestResult
            };
        }

        public async Task<IEnumerable<TestAppointmentDto>> GetAppointmentsAsync(int localLicenseAppId, int testTypeId)
        {
            var appointments = await _testAppointmentRepository.GetAppointmentsAsync(localLicenseAppId, testTypeId);
            return appointments.Select(ToDto).ToList();
        }

        public async Task<TestAppointmentDto?> GetAppointmentByIdAsync(int testAppointmentId)
        {
            var appointment = await _testAppointmentRepository.GetAppointmentByIdAsync(testAppointmentId);
            return appointment == null ? null : ToDto(appointment);
        }

        public Task<bool> HasActiveAppointmentAsync(int localLicenseAppId, int testTypeId)
        {
            return _testAppointmentRepository.HasActiveAppointmentAsync(localLicenseAppId, testTypeId);
        }

        public Task<bool> HasPassedTestAsync(int localLicenseAppId, int testTypeId)
        {
            return _testAppointmentRepository.HasPassedTestAsync(localLicenseAppId, testTypeId);
        }

        public Task<bool> IsRetakeAsync(int localLicenseAppId, int testTypeId)
        {
            return _testAppointmentRepository.HasAttendedTestAsync(localLicenseAppId, testTypeId);
        }

        public async Task<string?> GetScheduleErrorAsync(int localLicenseAppId, int testTypeId)
        {
            var application = await _localLicenseRepository.GetLocalLicenseByIdAsync(localLicenseAppId);
            if (application == null)
                return "The application was not found.";

            if (application.ApplicationStatus != LocalLicenseDto.StatusNew)
                return "Tests can only be scheduled for applications with status 'New'.";

            if (testTypeId < 1 || testTypeId > 3)
                return "Unknown test type.";

            if (testTypeId > 1 && !await _testAppointmentRepository.HasPassedTestAsync(localLicenseAppId, testTypeId - 1))
                return "The previous test must be passed before scheduling this test.";

            if (await _testAppointmentRepository.HasPassedTestAsync(localLicenseAppId, testTypeId))
                return "The applicant already passed this test.";

            if (await _testAppointmentRepository.HasActiveAppointmentAsync(localLicenseAppId, testTypeId))
                return "The applicant already has an active appointment for this test.";

            return null;
        }

        public async Task<int> ScheduleTestAsync(int localLicenseAppId, int testTypeId, DateTime appointmentDate, int createdByUserId)
        {
            string? error = await GetScheduleErrorAsync(localLicenseAppId, testTypeId);
            if (error != null)
                throw new InvalidOperationException(error);

            var application = await _localLicenseRepository.GetLocalLicenseByIdAsync(localLicenseAppId);
            bool isRetake = await _testAppointmentRepository.HasAttendedTestAsync(localLicenseAppId, testTypeId);

            var appointment = new TestAppointment
            {
                TestTypeID = testTypeId,
                LocalDrivingLicenseApplicationID = localLicenseAppId,
                AppointmentDate = appointmentDate,
                CreatedByUserID = createdByUserId
            };

            return await _testAppointmentRepository.AddAppointmentAsync(appointment, isRetake, application.ApplicantPersonID);
        }

        public async Task<bool> RescheduleTestAsync(int testAppointmentId, DateTime appointmentDate)
        {
            var appointment = await _testAppointmentRepository.GetAppointmentByIdAsync(testAppointmentId);
            if (appointment == null)
                throw new InvalidOperationException("The appointment was not found.");

            if (appointment.IsLocked)
                throw new InvalidOperationException("This appointment is locked because the test was already taken.");

            return await _testAppointmentRepository.UpdateAppointmentDateAsync(testAppointmentId, appointmentDate);
        }

        public async Task<int> TakeTestAsync(int testAppointmentId, bool testResult, string? notes, int createdByUserId)
        {
            var appointment = await _testAppointmentRepository.GetAppointmentByIdAsync(testAppointmentId);
            if (appointment == null)
                throw new InvalidOperationException("The appointment was not found.");

            if (appointment.IsLocked)
                throw new InvalidOperationException("This appointment is locked because the test was already taken.");

            return await _testAppointmentRepository.TakeTestAsync(testAppointmentId, testResult,
                string.IsNullOrWhiteSpace(notes) ? null : notes!.Trim(), createdByUserId);
        }
    }
}
