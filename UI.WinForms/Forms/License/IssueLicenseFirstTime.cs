using System;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.Forms.License
{
    public partial class IssueLicenseFirstTime : Form
    {
        private readonly int _localLicenseAppId;
        private readonly LocalLicenseService _localLicenseService;
        private readonly LicenseService _licenseService;

        public int IssuedLicenseId { get; private set; } = -1;

        public IssueLicenseFirstTime(int localLicenseAppId, LocalLicenseService localLicenseService, LicenseService licenseService)
        {
            InitializeComponent();
            _localLicenseAppId = localLicenseAppId;
            _localLicenseService = localLicenseService;
            _licenseService = licenseService;
        }

        private async void IssueLicenseFirstTime_Load(object sender, EventArgs e)
        {
            try
            {
                LocalLicenseDto application = await _localLicenseService.GetLocalLicenseByIdAsync(_localLicenseAppId);
                if (application == null)
                {
                    MessageBox.Show("No application with ID = " + _localLicenseAppId, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                lblLocalLicenseAppID.Text = application.LocalDrivingLicenseApplicationID.ToString();
                lblApplicationID.Text = application.ApplicationID.ToString();
                lblLicenseClass.Text = application.ClassName;
                lblApplicant.Text = application.FullName;
                lblPassedTests.Text = application.PassedTestCount + "/3";

                LicenseClassDto licenseClass = await _licenseService.GetLicenseClassByIdAsync(application.LicenseClassID);
                if (licenseClass != null)
                {
                    lblLicenseFees.Text = licenseClass.ClassFees.ToString("0.00");
                    lblValidity.Text = licenseClass.DefaultValidityLength.ToString();
                }

                string error = await _licenseService.GetFirstTimeIssueErrorAsync(_localLicenseAppId);
                if (error != null)
                {
                    btnIssue.Enabled = false;
                    MessageBox.Show(error, "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading application: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnIssue_Click(object sender, EventArgs e)
        {
            try
            {
                IssuedLicenseId = await _licenseService.IssueFirstTimeLicenseAsync(_localLicenseAppId, txtNotes.Text,
                    CurrentUserSession.CurrentUserId);

                btnIssue.Enabled = false;
                MessageBox.Show("License issued successfully. License ID = " + IssuedLicenseId, "Issued",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error issuing the license: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
