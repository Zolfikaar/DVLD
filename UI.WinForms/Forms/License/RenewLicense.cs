using System;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.Forms.License
{
    public partial class RenewLicense : Form
    {
        private const int RenewApplicationTypeId = 2;

        private readonly LicenseService _licenseService;
        private readonly PersonService _personService;
        private readonly ApplicationTypeService _applicationTypeService;
        private decimal _applicationFees;
        private int _newLicenseId = -1;

        public RenewLicense(LicenseService licenseService, PersonService personService, ApplicationTypeService applicationTypeService)
        {
            InitializeComponent();
            _licenseService = licenseService;
            _personService = personService;
            _applicationTypeService = applicationTypeService;
        }

        private async void RenewLicense_Load(object sender, EventArgs e)
        {
            ctrlLicenseFinder1.LicenseService = _licenseService;
            ctrlLicenseFinder1.LicenseSelected += ctrlLicenseFinder1_LicenseSelected;

            lblRenewAppID.Text = "N/A";
            lblRenewedLicenseID.Text = "N/A";
            lblOldLicenseID.Text = "N/A";
            lblApplicationDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lblIssueDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lblExpirationDate.Text = "N/A";
            lblLicenseFees.Text = "0.00";
            lblCreatedBy.Text = CurrentUserSession.CurrentUserName;
            btnRenew.Enabled = false;
            llShowLicensesHistory.Enabled = false;
            llShowNewLicenseInfo.Enabled = false;

            try
            {
                ApplicationTypeDto applicationType = await _applicationTypeService.GetApplicationTypeByIdAsync(RenewApplicationTypeId);
                _applicationFees = applicationType != null ? applicationType.ApplicationFees : 0;
                lblApplicationFees.Text = _applicationFees.ToString("0.00");
                lblTotalFees.Text = _applicationFees.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading fees: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ctrlLicenseFinder1_LicenseSelected(object sender, EventArgs e)
        {
            LicenseDto license = ctrlLicenseFinder1.SelectedLicense;
            btnRenew.Enabled = false;
            llShowLicensesHistory.Enabled = license != null;
            lblOldLicenseID.Text = license != null ? license.LicenseID.ToString() : "N/A";

            if (license == null)
                return;

            LicenseClassDto licenseClass = await _licenseService.GetLicenseClassByIdAsync(license.LicenseClassID);
            decimal licenseFees = licenseClass != null ? licenseClass.ClassFees : 0;
            lblLicenseFees.Text = licenseFees.ToString("0.00");
            lblTotalFees.Text = (_applicationFees + licenseFees).ToString("0.00");
            lblExpirationDate.Text = licenseClass != null
                ? DateTime.Today.AddYears(licenseClass.DefaultValidityLength).ToString("dd/MM/yyyy")
                : "N/A";

            string error = _licenseService.GetRenewError(license);
            if (error != null)
            {
                MessageBox.Show(error, "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnRenew.Enabled = true;
        }

        private async void btnRenew_Click(object sender, EventArgs e)
        {
            LicenseDto license = ctrlLicenseFinder1.SelectedLicense;
            if (license == null)
                return;

            if (!chkOldLicenseHandedIn.Checked)
            {
                MessageBox.Show("The applicant must hand in the old license before it can be renewed.", "Hand In Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to renew this license?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _newLicenseId = await _licenseService.RenewLicenseAsync(license.LicenseID, txtNotes.Text, CurrentUserSession.CurrentUserId);

                lblRenewedLicenseID.Text = _newLicenseId.ToString();
                btnRenew.Enabled = false;
                ctrlLicenseFinder1.FilterEnabled = false;
                llShowNewLicenseInfo.Enabled = true;

                MessageBox.Show("License renewed successfully. New License ID = " + _newLicenseId, "Renewed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error renewing the license: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
