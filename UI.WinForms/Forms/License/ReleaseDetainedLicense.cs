using System;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.Forms.License
{
    public partial class ReleaseDetainedLicense : Form
    {
        private const int ReleaseApplicationTypeId = 5;

        private readonly LicenseService _licenseService;
        private readonly PersonService _personService;
        private readonly ApplicationTypeService _applicationTypeService;
        private readonly int _initialLicenseId;
        private decimal _applicationFees;

        public ReleaseDetainedLicense(LicenseService licenseService, PersonService personService,
            ApplicationTypeService applicationTypeService, int licenseId = -1)
        {
            InitializeComponent();
            _licenseService = licenseService;
            _personService = personService;
            _applicationTypeService = applicationTypeService;
            _initialLicenseId = licenseId;
        }

        private async void ReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            ctrlLicenseFinder1.LicenseService = _licenseService;
            ctrlLicenseFinder1.LicenseSelected += ctrlLicenseFinder1_LicenseSelected;

            _clearDetainInfo();
            lblApplicationID.Text = "N/A";
            lblCreatedBy.Text = CurrentUserSession.CurrentUserName;
            btnRelease.Enabled = false;
            llShowLicensesHistory.Enabled = false;
            llShowNewLicenseInfo.Text = "Show License Info";
            llShowNewLicenseInfo.Enabled = false;

            try
            {
                ApplicationTypeDto applicationType = await _applicationTypeService.GetApplicationTypeByIdAsync(ReleaseApplicationTypeId);
                _applicationFees = applicationType != null ? applicationType.ApplicationFees : 0;
                lblApplicationFees.Text = _applicationFees.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading fees: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (_initialLicenseId > 0)
                await ctrlLicenseFinder1.LoadLicenseAsync(_initialLicenseId);
        }

        private void _clearDetainInfo()
        {
            lblDetainID.Text = "N/A";
            lblDetainDate.Text = "N/A";
            lblLicenseID.Text = "N/A";
            lblFineFees.Text = "0.00";
            lblTotalFees.Text = _applicationFees.ToString("0.00");
        }

        private async void ctrlLicenseFinder1_LicenseSelected(object sender, EventArgs e)
        {
            LicenseDto license = ctrlLicenseFinder1.SelectedLicense;
            btnRelease.Enabled = false;
            llShowLicensesHistory.Enabled = license != null;
            llShowNewLicenseInfo.Enabled = license != null;
            _clearDetainInfo();

            if (license == null)
                return;

            lblLicenseID.Text = license.LicenseID.ToString();

            DetainedLicenseDto detained = await _licenseService.GetActiveDetainByLicenseIdAsync(license.LicenseID);
            if (detained == null)
            {
                MessageBox.Show("This license is not detained.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblDetainID.Text = detained.DetainID.ToString();
            lblDetainDate.Text = detained.DetainDate.ToString("dd/MM/yyyy");
            lblFineFees.Text = detained.FineFees.ToString("0.00");
            lblTotalFees.Text = (detained.FineFees + _applicationFees).ToString("0.00");
            btnRelease.Enabled = true;
        }

        private async void btnRelease_Click(object sender, EventArgs e)
        {
            LicenseDto license = ctrlLicenseFinder1.SelectedLicense;
            if (license == null)
                return;

            if (MessageBox.Show("Total fees are " + lblTotalFees.Text + ". Are you sure you want to release this license?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int applicationId = await _licenseService.ReleaseDetainedLicenseAsync(license.LicenseID, CurrentUserSession.CurrentUserId);

                lblApplicationID.Text = applicationId.ToString();
                btnRelease.Enabled = false;
                ctrlLicenseFinder1.FilterEnabled = false;

                MessageBox.Show("License released successfully.", "Released", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error releasing the license: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseDto license = ctrlLicenseFinder1.SelectedLicense;
            if (license != null)
                new LicenseHistory(_licenseService, _personService, license.PersonID).ShowDialog();
        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseDto license = ctrlLicenseFinder1.SelectedLicense;
            if (license != null)
                new LicenseDetails(_licenseService, license.LicenseID).ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
