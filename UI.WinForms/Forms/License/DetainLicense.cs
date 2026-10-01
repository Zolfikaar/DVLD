using System;
using System.Globalization;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.Forms.License
{
    public partial class DetainLicense : Form
    {
        private readonly LicenseService _licenseService;
        private readonly PersonService _personService;
        private readonly int _initialLicenseId;

        public DetainLicense(LicenseService licenseService, PersonService personService, int licenseId = -1)
        {
            InitializeComponent();
            _licenseService = licenseService;
            _personService = personService;
            _initialLicenseId = licenseId;
        }

        private async void DetainLicense_Load(object sender, EventArgs e)
        {
            ctrlLicenseFinder1.LicenseService = _licenseService;
            ctrlLicenseFinder1.LicenseSelected += ctrlLicenseFinder1_LicenseSelected;

            lblDetainID.Text = "N/A";
            lblLicenseID.Text = "N/A";
            lblDetainDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lblCreatedBy.Text = CurrentUserSession.CurrentUserName;
            btnDetain.Enabled = false;
            llShowLicensesHistory.Enabled = false;
            llShowNewLicenseInfo.Text = "Show License Info";
            llShowNewLicenseInfo.Enabled = false;

            if (_initialLicenseId > 0)
                await ctrlLicenseFinder1.LoadLicenseAsync(_initialLicenseId);
        }

        private void ctrlLicenseFinder1_LicenseSelected(object sender, EventArgs e)
        {
            LicenseDto license = ctrlLicenseFinder1.SelectedLicense;
            btnDetain.Enabled = false;
            llShowLicensesHistory.Enabled = license != null;
            llShowNewLicenseInfo.Enabled = license != null;
            lblLicenseID.Text = license != null ? license.LicenseID.ToString() : "N/A";

            if (license == null)
                return;

            string error = _licenseService.GetDetainError(license);
            if (error != null)
            {
                MessageBox.Show(error, "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnDetain.Enabled = true;
            txtFineFees.Focus();
        }

        private async void btnDetain_Click(object sender, EventArgs e)
        {
            LicenseDto license = ctrlLicenseFinder1.SelectedLicense;
            if (license == null)
                return;

            if (!decimal.TryParse(txtFineFees.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal fineFees) || fineFees <= 0)
            {
                MessageBox.Show("Please enter valid fine fees greater than zero.", "Invalid Fine Fees", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFineFees.Focus();
                return;
            }

            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                int detainId = await _licenseService.DetainLicenseAsync(license.LicenseID, fineFees, CurrentUserSession.CurrentUserId);

                lblDetainID.Text = detainId.ToString();
                btnDetain.Enabled = false;
                txtFineFees.Enabled = false;
                ctrlLicenseFinder1.FilterEnabled = false;

                MessageBox.Show("License detained successfully. Detain ID = " + detainId, "Detained",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error detaining the license: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
