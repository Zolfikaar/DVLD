using System;
using System.Linq;
using System.Windows.Forms;
using Application.Services;

namespace UI.WinForms.Forms.License
{
    public partial class LicenseHistory : Form
    {
        private readonly LicenseService _licenseService;
        private readonly PersonService _personService;
        private readonly int _personId;

        public LicenseHistory(LicenseService licenseService, PersonService personService, int personId)
        {
            InitializeComponent();
            _licenseService = licenseService;
            _personService = personService;
            _personId = personId;
        }

        private async void LicenseHistory_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.ShowEditLink = false;

            try
            {
                await ctrlPersonCard1.LoadPersonAsync(_personService, _personId);

                var localLicenses = await _licenseService.GetLicensesByPersonIdAsync(_personId);
                dgvLocalLicenses.DataSource = localLicenses.Select(l => new
                {
                    LicenseID = l.LicenseID,
                    ApplicationID = l.ApplicationID,
                    Class = l.ClassName,
                    IssueDate = l.IssueDate.ToString("dd/MM/yyyy"),
                    ExpirationDate = l.ExpirationDate.ToString("dd/MM/yyyy"),
                    IssueReason = l.IssueReasonText,
                    IsActive = l.IsActive,
                    IsDetained = l.IsDetained
                }).ToList();

                var internationalLicenses = await _licenseService.GetInternationalLicensesByPersonIdAsync(_personId);
                dgvInternationalLicenses.DataSource = internationalLicenses.Select(l => new
                {
                    InternationalLicenseID = l.InternationalLicenseID,
                    ApplicationID = l.ApplicationID,
                    LocalLicenseID = l.IssuedUsingLocalLicenseID,
                    IssueDate = l.IssueDate.ToString("dd/MM/yyyy"),
                    ExpirationDate = l.ExpirationDate.ToString("dd/MM/yyyy"),
                    IsActive = l.IsActive
                }).ToList();

                gbLocalLicenses.Text = "Local Licenses (" + dgvLocalLicenses.Rows.Count + ")";
                gbInternationalLicenses.Text = "International Licenses (" + dgvInternationalLicenses.Rows.Count + ")";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading license history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
