using System;
using System.Linq;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.Forms.Test
{
    public partial class TakeTest : Form
    {
        private readonly int _testAppointmentId;
        private readonly LocalLicenseService _localLicenseService;
        private readonly TestAppointmentService _testAppointmentService;
        private readonly TestTypeService _testTypeService;

        public TakeTest(int testAppointmentId, LocalLicenseService localLicenseService,
            TestAppointmentService testAppointmentService, TestTypeService testTypeService)
        {
            InitializeComponent();
            _testAppointmentId = testAppointmentId;
            _localLicenseService = localLicenseService;
            _testAppointmentService = testAppointmentService;
            _testTypeService = testTypeService;
        }

        private async void TakeTest_Load(object sender, EventArgs e)
        {
            try
            {
                TestAppointmentDto appointment = await _testAppointmentService.GetAppointmentByIdAsync(_testAppointmentId);
                if (appointment == null)
                {
                    MessageBox.Show("The appointment was not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                LocalLicenseDto application = await _localLicenseService.GetLocalLicenseByIdAsync(appointment.LocalDrivingLicenseApplicationID);
                TestTypeDto testType = await _testTypeService.GetTestTypeByIdAsync(appointment.TestTypeID);
                var appointments = await _testAppointmentService.GetAppointmentsAsync(appointment.LocalDrivingLicenseApplicationID, appointment.TestTypeID);

                if (testType != null)
                {
                    lblTitle.Text = testType.TestTypeTitle;
                    Text = "Take " + testType.TestTypeTitle;
                }

                if (application != null)
                {
                    lblLocalLicenseAppID.Text = application.LocalDrivingLicenseApplicationID.ToString();
                    lblLicenseClass.Text = application.ClassName;
                    lblApplicant.Text = application.FullName;
                }

                lblTrial.Text = appointments.Count(a => a.TestID.HasValue).ToString();
                lblAppointmentDate.Text = appointment.AppointmentDate.ToString("dd/MM/yyyy HH:mm");
                lblTestFees.Text = (appointment.PaidFees + appointment.RetakeFees).ToString("0.00");
                lblTestID.Text = appointment.TestID.HasValue ? appointment.TestID.ToString() : "Not taken yet";

                if (appointment.IsLocked)
                {
                    rbPass.Checked = appointment.TestResult == true;
                    rbFail.Checked = appointment.TestResult != true;
                    gbResult.Enabled = false;
                    btnSave.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading test data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? The result cannot be changed after saving.", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int testId = await _testAppointmentService.TakeTestAsync(_testAppointmentId, rbPass.Checked, txtNotes.Text,
                    CurrentUserSession.CurrentUserId);

                lblTestID.Text = testId.ToString();
                gbResult.Enabled = false;
                btnSave.Enabled = false;
                MessageBox.Show("Test result saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving the test result: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
