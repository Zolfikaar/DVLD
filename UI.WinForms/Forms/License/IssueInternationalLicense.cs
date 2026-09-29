using System;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.Forms.License
{
    public partial class IssueInternationalLicense : Form
    {
        private const int InternationalLicenseApplicationTypeId = 6;

        private readonly LicenseService _licenseService;
        private readonly PersonService _personService;
        private readonly ApplicationTypeService _applicationTypeService;
        private int _internationalLicenseId = -1;

        public IssueInternationalLicense(LicenseService licenseService, PersonService personService, ApplicationTypeService applicationTypeService)
        {
            InitializeComponent();
            _licenseService = licenseService;
            _personService = personService;
            _applicationTypeService = applicationTypeService;
        }

        private async void IssueInternationalLicense_Load(object sender, EventArgs e)
        {
            ctrlLicenseFinder1.LicenseService = _licenseService;
            ctrlLicenseFinder1.LicenseClassFilter = LicenseService.OrdinaryLicenseClassId;
            ctrlLicenseFinder1.LicenseSelected += ctrlLicenseFinder1_LicenseSelected;

            lblInternationalAppID.Text = "N/A";
            lblInternationalLicenseID.Text = "N/A";
            lblLocalLicenseID.Text = "N/A";
            lblApplicationDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lblIssueDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lblExpirationDate.Text = DateTime.Today.AddYears(1).ToString("dd/MM/yyyy");
            lblCreatedBy.Text = CurrentUserSession.CurrentUserName;
            btnIssue.Enabled = false;
            llShowLicensesHistory.Enabled = false;
            llShowNewLicenseInfo.Visible = false;

            try
            {
                ApplicationTypeDto applicationType = await _applicationTypeService.GetApplicationTypeByIdAsync(InternationalLicenseApplicationTypeId);
                lblFees.Text = applicationType != null ? applicationType.ApplicationFees.ToString("0.00") : "0.00";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading fees: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ctrlLicenseFinder1_LicenseSelected(object sender, EventArgs e)
        {
            LicenseDto license = ctrlLicenseFinder1.SelectedLicense;
            btnIssue.Enabled = false;
            llShowLicensesHistory.Enabled = license != null;
            lblLocalLicenseID.Text = license != null ? license.LicenseID.ToString() : "N/A";

            if (license == null)
                return;

            string error = await _licenseService.GetInternationalIssueErrorAsync(license);
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

            if (MessageBox.Show("Are you sure you want to issue an international license?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _internationalLicenseId = await _licenseService.IssueInternationalLicenseAsync(license.LicenseID, CurrentUserSession.CurrentUserId);

                lblInternationalLicenseID.Text = _internationalLicenseId.ToString();
                btnIssue.Enabled = false;
                ctrlLicenseFinder1.FilterEnabled = false;

                MessageBox.Show("International license issued successfully. ID = " + _internationalLicenseId, "Issued",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error issuing the international license: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
