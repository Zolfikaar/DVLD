using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.UserControls
{
    public partial class ctrlLicenseCard : UserControl
    {
        public LicenseDto SelectedLicense { get; private set; }

        public ctrlLicenseCard()
        {
            InitializeComponent();
            Clear();
        }

        public async Task<bool> LoadLicenseAsync(LicenseService licenseService, int licenseId)
        {
            LicenseDto license = await licenseService.GetLicenseByIdAsync(licenseId);
            if (license == null)
            {
                Clear();
                return false;
            }

            BindLicense(license);
            return true;
        }

        public void BindLicense(LicenseDto license)
        {
            SelectedLicense = license;

            lblClass.Text = license.ClassName;
            lblFullName.Text = license.FullName;
            lblLicenseID.Text = license.LicenseID.ToString();
            lblNationalNo.Text = license.NationalNo;
            lblGender.Text = license.GenderText;
            lblIssueDate.Text = license.IssueDate.ToString("dd/MM/yyyy");
            lblNotes.Text = string.IsNullOrWhiteSpace(license.Notes) ? "No Notes" : license.Notes;
            lblIssueReason.Text = license.IssueReasonText;
            lblIsActive.Text = license.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = license.DateOfBirth.ToString("dd/MM/yyyy");
            lblDriverID.Text = license.DriverID.ToString();
            lblExpirationDate.Text = license.ExpirationDate.ToString("dd/MM/yyyy") + (license.IsExpired ? " (Expired)" : "");
            lblIsDetained.Text = license.IsDetained ? "Yes" : "No";
        }

        public void Clear()
        {
            SelectedLicense = null;

            foreach (Label label in new[] { lblClass, lblFullName, lblLicenseID, lblNationalNo, lblGender, lblIssueDate, lblNotes,
                                            lblIssueReason, lblIsActive, lblDateOfBirth, lblDriverID, lblExpirationDate, lblIsDetained })
            {
                label.Text = "[????]";
            }
        }
    }
}
