using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.Forms.Test
{
    public partial class ManageTestAppointments : Form
    {
        private readonly int _localLicenseAppId;
        private readonly int _testTypeId;
        private readonly LocalLicenseService _localLicenseService;
        private readonly TestAppointmentService _testAppointmentService;
        private readonly TestTypeService _testTypeService;
        private readonly ApplicationTypeService _applicationTypeService;
        private List<TestAppointmentDto> _appointments = new List<TestAppointmentDto>();

        public ManageTestAppointments(int localLicenseAppId, int testTypeId, LocalLicenseService localLicenseService,
            TestAppointmentService testAppointmentService, TestTypeService testTypeService, ApplicationTypeService applicationTypeService)
        {
            InitializeComponent();
            _localLicenseAppId = localLicenseAppId;
            _testTypeId = testTypeId;
            _localLicenseService = localLicenseService;
            _testAppointmentService = testAppointmentService;
            _testTypeService = testTypeService;
            _applicationTypeService = applicationTypeService;
        }

        private async void ManageTestAppointments_Load(object sender, EventArgs e)
        {
            try
            {
                TestTypeDto testType = await _testTypeService.GetTestTypeByIdAsync(_testTypeId);
                if (testType != null)
                {
                    lblTitle.Text = testType.TestTypeTitle + " Appointments";
                    Text = lblTitle.Text;
                    lblTestFees.Text = testType.TestTypeFees.ToString("0.00");
                }

                await _loadApplicationInfoAsync();
                await _loadAppointmentsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task _loadApplicationInfoAsync()
        {
            LocalLicenseDto application = await _localLicenseService.GetLocalLicenseByIdAsync(_localLicenseAppId);
            if (application == null)
                return;

            lblLocalLicenseAppID.Text = application.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = application.ClassName;
            lblApplicant.Text = application.FullName;
            lblPassedTests.Text = application.PassedTestCount + "/3";
            lblStatus.Text = application.Status;
        }

        private async Task _loadAppointmentsAsync()
        {
            _appointments = (await _testAppointmentService.GetAppointmentsAsync(_localLicenseAppId, _testTypeId)).ToList();

            dgvAppointments.DataSource = _appointments.Select(a => new
            {
                AppointmentID = a.TestAppointmentID,
                AppointmentDate = a.AppointmentDate.ToString("dd/MM/yyyy HH:mm"),
                PaidFees = a.PaidFees + a.RetakeFees,
                IsRetake = a.RetakeTestApplicationID.HasValue,
                IsLocked = a.IsLocked,
                Result = a.TestResult == null ? "" : (a.TestResult.Value ? "Pass" : "Fail")
            }).ToList();

            lblRecordsCount.Text = _appointments.Count.ToString();
        }

        private TestAppointmentDto _selectedAppointment()
        {
            if (dgvAppointments.CurrentRow == null)
                return null;

            int appointmentId = (int)dgvAppointments.CurrentRow.Cells["AppointmentID"].Value;
            return _appointments.FirstOrDefault(a => a.TestAppointmentID == appointmentId);
        }

        private async void btnAddAppointment_Click(object sender, EventArgs e)
        {
            string error = await _testAppointmentService.GetScheduleErrorAsync(_localLicenseAppId, _testTypeId);
            if (error != null)
            {
                MessageBox.Show(error, "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            new ScheduleTest(_localLicenseAppId, _testTypeId, -1, _localLicenseService, _testAppointmentService,
                _testTypeService, _applicationTypeService).ShowDialog();

            await _loadAppointmentsAsync();
        }

        private void cmsAppointments_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TestAppointmentDto appointment = _selectedAppointment();
            if (appointment == null)
            {
                e.Cancel = true;
                return;
            }

            editAppointmentToolStripMenuItem.Enabled = !appointment.IsLocked;
            takeTestToolStripMenuItem.Enabled = !appointment.IsLocked;
        }

        private async void editAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestAppointmentDto appointment = _selectedAppointment();
            if (appointment == null)
                return;

            new ScheduleTest(_localLicenseAppId, _testTypeId, appointment.TestAppointmentID, _localLicenseService,
                _testAppointmentService, _testTypeService, _applicationTypeService).ShowDialog();

            await _loadAppointmentsAsync();
        }

        private async void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestAppointmentDto appointment = _selectedAppointment();
            if (appointment == null)
                return;

            new TakeTest(appointment.TestAppointmentID, _localLicenseService, _testAppointmentService, _testTypeService).ShowDialog();

            await _loadApplicationInfoAsync();
            await _loadAppointmentsAsync();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
