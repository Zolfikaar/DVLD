using System;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.Forms.License
{
    public partial class ReplaceLicense : Form
    {
        private const int ReplaceLostApplicationTypeId = 3;
        private const int ReplaceDamagedApplicationTypeId = 4;

        private readonly LicenseService _licenseService;
        private readonly PersonService _personService;
        private readonly ApplicationTypeService _applicationTypeService;
        private int _newLicenseId = -1;

        public ReplaceLicense(LicenseService licenseService, PersonService personService, ApplicationTypeService applicationTypeService)
        {
            InitializeComponent();
            _licenseService = licenseService;
            _personService = personService;
            _applicationTypeService = applicationTypeService;
        }

        private async void ReplaceLicense_Load(object sender, EventArgs e)
        {
            ctrlLicenseFinder1.LicenseService = _licenseService;
            ctrlLicenseFinder1.LicenseSelected += ctrlLicenseFinder1_LicenseSelected;

            lblReplaceAppID.Text = "N/A";
            lblReplacedLicenseID.Text = "N/A";
            lblOldLicenseID.Text = "N/A";
            lblApplicationDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lblReplacementFees.Text = LicenseService.ReplacementFees.ToString("0.00");
            lblCreatedBy.Text = CurrentUserSession.CurrentUserName;
            btnIssue.Enabled = false;
            llShowLicensesHistory.Enabled = false;
            llShowNewLicenseInfo.Enabled = false;

            await _loadFeesAsync();
        }

        private async System.Threading.Tasks.Task _loadFeesAsync()
        {
            try
            {
                int applicationTypeId = rbLost.Checked ? ReplaceLostApplicationTypeId : ReplaceDamagedApplicationTypeId;
                ApplicationTypeDto applicationType = await _applicationTypeService.GetApplicationTypeByIdAsync(applicationTypeId);
                decimal applicationFees = applicationType != null ? applicationType.ApplicationFees : 0;

                lblTitle.Text = rbLost.Checked ? "Replacement for Lost License" : "Replacement for Damaged License";
                Text = lblTitle.Text;
                lblApplicationFees.Text = applicationFees.ToString("0.00");
                lblTotalFees.Text = (applicationFees + LicenseService.ReplacementFees).ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading fees: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void rbReplacementType_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked && lblCreatedBy.Text != "[????]")
                await _loadFeesAsync();
        }

        private void ctrlLicenseFinder1_LicenseSelected(object sender, EventArgs e)
        {
            LicenseDto license = ctrlLicenseFinder1.SelectedLicense;
            btnIssue.Enabled = false;
            llShowLicensesHistory.Enabled = license != null;
            lblOldLicenseID.Text = license != null ? license.LicenseID.ToString() : "N/A";

            if (license == null)
                return;

            string error = _licenseService.GetReplacementError(license);
            if (error != null)
            {
                MessageBox.Show(error, "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnIssue.Enabled = true;
        }

        private async void btnIssue_Click(object sender, EventArgs e)
        {
            LicenseDto license = ctrlLicenseFinder1.SelectedLicense;
            if (license == null)
                return;

            if (MessageBox.Show("Are you sure you want to issue a replacement for this license?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _newLicenseId = await _licenseService.ReplaceLicenseAsync(license.LicenseID, rbLost.Checked, CurrentUserSession.CurrentUserId);

                lblReplacedLicenseID.Text = _newLicenseId.ToString();
                btnIssue.Enabled = false;
                rbLost.Enabled = false;
                rbDamaged.Enabled = false;
                ctrlLicenseFinder1.FilterEnabled = false;
                llShowNewLicenseInfo.Enabled = true;

                MessageBox.Show("Replacement license issued successfully. New License ID = " + _newLicenseId, "Issued",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error issuing the replacement: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (_newLicenseId > 0)
                new LicenseDetails(_licenseService, _newLicenseId).ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
