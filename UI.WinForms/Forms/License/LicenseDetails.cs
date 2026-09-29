using System;
using System.Windows.Forms;
using Application.Services;

namespace UI.WinForms.Forms.License
{
    public partial class LicenseDetails : Form
    {
        private readonly LicenseService _licenseService;
        private readonly int _licenseId;

        public LicenseDetails(LicenseService licenseService, int licenseId)
        {
            InitializeComponent();
            _licenseService = licenseService;
            _licenseId = licenseId;
        }

        private async void LicenseDetails_Load(object sender, EventArgs e)
        {
            try
            {
                if (!await ctrlLicenseCard1.LoadLicenseAsync(_licenseService, _licenseId))
                {
                    MessageBox.Show("No license with ID = " + _licenseId, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading license: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
