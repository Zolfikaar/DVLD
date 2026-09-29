using System;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;
using UI.WinForms.Forms.License;

namespace UI.WinForms.Forms.Application
{
    public partial class LocalLicense_ApplicationDetails : Form
    {
        private readonly int _localLicenseAppId;
        private readonly LocalLicenseService _localLicenseService;
        private readonly PersonService _personService;
        private readonly LicenseService _licenseService;
        private LocalLicenseDto _application;

        public LocalLicense_ApplicationDetails(int localLicenseAppId, LocalLicenseService localLicenseService,
            PersonService personService, LicenseService licenseService)
        {
            InitializeComponent();
            _localLicenseAppId = localLicenseAppId;
            _localLicenseService = localLicenseService;
            _personService = personService;
            _licenseService = licenseService;
        }

        private async void LocalLicense_ApplicationDetails_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.ShowEditLink = false;
            llShowLicenseInfo.Enabled = false;

            try
            {
                _application = await _localLicenseService.GetLocalLicenseByIdAsync(_localLicenseAppId);
                if (_application == null)
                {
                    MessageBox.Show("No application with ID = " + _localLicenseAppId, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                lblLocalLicenseAppID.Text = _application.LocalDrivingLicenseApplicationID.ToString();
                lblLicenseClass.Text = _application.ClassName;
                lblPassedTests.Text = _application.PassedTestCount + "/3";
                lblLicenseID.Text = _application.LicenseID > 0 ? _application.LicenseID.ToString() : "Not issued yet";
                lblApplicationID.Text = _application.ApplicationID.ToString();
                lblStatus.Text = _application.Status;
                lblApplicationType.Text = _application.ApplicationTypeTitle;
                lblFees.Text = _application.PaidFees.ToString("0.00");
                lblApplicant.Text = _application.FullName;
                lblApplicationDate.Text = _application.ApplicationDate.ToString("dd/MM/yyyy");
                lblStatusDate.Text = _application.LastStatusDate.ToString("dd/MM/yyyy");
                lblCreatedBy.Text = _application.CreatedByUserName;
                llShowLicenseInfo.Enabled = _application.LicenseID > 0;

                await ctrlPersonCard1.LoadPersonAsync(_personService, _application.ApplicantPersonID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading application details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_application == null || _application.LicenseID <= 0)
                return;

            new LicenseDetails(_licenseService, _application.LicenseID).ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
