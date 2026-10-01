using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.UserControls
{
    public partial class ctrlLicenseFinder : UserControl
    {
        public event EventHandler LicenseSelected;

        public LicenseService LicenseService { get; set; }

        public int? LicenseClassFilter { get; set; }

        public LicenseDto SelectedLicense
        {
            get { return ctrlLicenseCard1.SelectedLicense; }
        }

        public bool FilterEnabled
        {
            get { return gbFilter.Enabled; }
            set { gbFilter.Enabled = value; }
        }

        public ctrlLicenseFinder()
        {
            InitializeComponent();
            cbFindBy.Items.Add("License ID");
            cbFindBy.Items.Add("National No.");
            cbFindBy.SelectedIndex = 0;
        }

        public async Task LoadLicenseAsync(int licenseId)
        {
            cbFindBy.SelectedIndex = 0;
            txtFindValue.Text = licenseId.ToString();
            await FindAsync();
        }

        public void FocusFilter()
        {
            txtFindValue.Focus();
        }

        private async Task FindAsync()
        {
            if (LicenseService == null)
                return;

            string value = txtFindValue.Text.Trim();
            if (value == "")
            {
                MessageBox.Show("Please enter a value to search for.", "Find License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                LicenseDto license = null;

                if (cbFindBy.SelectedIndex == 0)
                {
                    if (!int.TryParse(value, out int licenseId))
                    {
                        MessageBox.Show("License ID must be a number.", "Find License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    license = await LicenseService.GetLicenseByIdAsync(licenseId);
                }
                else
                {
                    license = await LicenseService.GetLatestLicenseByNationalNoAsync(value, LicenseClassFilter);
                }

                if (license == null)
                {
                    ctrlLicenseCard1.Clear();
                    MessageBox.Show("No license was found for \"" + value + "\".", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ctrlLicenseCard1.BindLicense(license);
                }

                LicenseSelected?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching for the license: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            await FindAsync();
        }

        private async void txtFindValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await FindAsync();
            }
        }

        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFindValue.Clear();
        }
    }
}
