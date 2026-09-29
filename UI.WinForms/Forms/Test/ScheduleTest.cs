using System;
using System.Linq;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.Forms.Test
{
    public partial class ScheduleTest : Form
    {
        private const int RetakeTestApplicationTypeId = 7;

        private readonly int _localLicenseAppId;
        private readonly int _testTypeId;
        private readonly int _testAppointmentId;
        private readonly LocalLicenseService _localLicenseService;
        private readonly TestAppointmentService _testAppointmentService;
        private readonly TestTypeService _testTypeService;
        private readonly ApplicationTypeService _applicationTypeService;

        private bool IsAddNew
        {
            get { return _testAppointmentId == -1; }
        }

        public ScheduleTest(int localLicenseAppId, int testTypeId, int testAppointmentId, LocalLicenseService localLicenseService,
            TestAppointmentService testAppointmentService, TestTypeService testTypeService, ApplicationTypeService applicationTypeService)
        {
            InitializeComponent();
            _localLicenseAppId = localLicenseAppId;
            _testTypeId = testTypeId;
            _testAppointmentId = testAppointmentId;
            _localLicenseService = localLicenseService;
            _testAppointmentService = testAppointmentService;
            _testTypeService = testTypeService;
            _applicationTypeService = applicationTypeService;
        }

        private async void ScheduleTest_Load(object sender, EventArgs e)
        {
            try
            {
                LocalLicenseDto application = await _localLicenseService.GetLocalLicenseByIdAsync(_localLicenseAppId);
                TestTypeDto testType = await _testTypeService.GetTestTypeByIdAsync(_testTypeId);

                if (application == null || testType == null)
                {
                    MessageBox.Show("The application or test type was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                lblTitle.Text = "Schedule " + testType.TestTypeTitle;
                Text = lblTitle.Text;
                lblLocalLicenseAppID.Text = application.LocalDrivingLicenseApplicationID.ToString();
                lblLicenseClass.Text = application.ClassName;
                lblApplicant.Text = application.FullName;
                lblTestFees.Text = testType.TestTypeFees.ToString("0.00");

                var appointments = (await _testAppointmentService.GetAppointmentsAsync(_localLicenseAppId, _testTypeId)).ToList();
                lblTrial.Text = appointments.Count(a => a.TestID.HasValue).ToString();

                decimal retakeFees = 0;
                bool isRetake;

                if (IsAddNew)
                {
                    isRetake = await _testAppointmentService.IsRetakeAsync(_localLicenseAppId, _testTypeId);
                    if (isRetake)
                    {
                        ApplicationTypeDto retakeType = await _applicationTypeService.GetApplicationTypeByIdAsync(RetakeTestApplicationTypeId);
                        retakeFees = retakeType != null ? retakeType.ApplicationFees : 0;
                    }

                    dtpAppointmentDate.MinDate = DateTime.Today;
                    dtpAppointmentDate.Value = DateTime.Now.AddDays(1);
                    lblRetakeTestAppID.Text = "N/A";

                    string error = await _testAppointmentService.GetScheduleErrorAsync(_localLicenseAppId, _testTypeId);
                    if (error != null)
                    {
                        lblUserMessage.Text = error;
                        btnSave.Enabled = false;
                        dtpAppointmentDate.Enabled = false;
                    }
                }
                else
                {
                    TestAppointmentDto appointment = await _testAppointmentService.GetAppointmentByIdAsync(_testAppointmentId);
                    if (appointment == null)
                    {
                        MessageBox.Show("The appointment was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close();
                        return;
                    }

                    isRetake = appointment.RetakeTestApplicationID.HasValue;
                    retakeFees = appointment.RetakeFees;
                    lblTestFees.Text = appointment.PaidFees.ToString("0.00");
                    lblRetakeTestAppID.Text = isRetake ? appointment.RetakeTestApplicationID.ToString() : "N/A";

                    dtpAppointmentDate.MinDate = appointment.AppointmentDate < DateTime.Today ? appointment.AppointmentDate : DateTime.Today;
                    dtpAppointmentDate.Value = appointment.AppointmentDate;

                    if (appointment.IsLocked)
                    {
                        lblUserMessage.Text = "The applicant already sat for this test; the appointment is locked.";
                        btnSave.Enabled = false;
                        dtpAppointmentDate.Enabled = false;
                    }
                }

                gbRetakeTest.Enabled = isRetake;
                if (isRetake)
                    lblTitle.Text = "Schedule Retake Test";

                decimal testFees = decimal.Parse(lblTestFees.Text);
                lblRetakeAppFees.Text = retakeFees.ToString("0.00");
                lblTotalFees.Text = (testFees + retakeFees).ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointment data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsAddNew)
                {
                    int appointmentId = await _testAppointmentService.ScheduleTestAsync(_localLicenseAppId, _testTypeId,
                        dtpAppointmentDate.Value, CurrentUserSession.CurrentUserId);

                    MessageBox.Show("Test scheduled successfully. Appointment ID = " + appointmentId, "Saved",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await _testAppointmentService.RescheduleTestAsync(_testAppointmentId, dtpAppointmentDate.Value);
                    MessageBox.Show("Appointment updated successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving the appointment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
