using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.Forms.License
{
    public partial class ManageDetainedLicenses : Form
    {
        private readonly LicenseService _licenseService;
        private readonly PersonService _personService;
        private readonly ApplicationTypeService _applicationTypeService;
        private List<DetainedLicenseDto> _detainedLicenses = new List<DetainedLicenseDto>();

        public ManageDetainedLicenses(LicenseService licenseService, PersonService personService, ApplicationTypeService applicationTypeService)
        {
            InitializeComponent();
            _licenseService = licenseService;
            _personService = personService;
            _applicationTypeService = applicationTypeService;
        }

        private async void ManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            cbFilterBy.Items.AddRange(new object[] { "None", "Detain ID", "License ID", "National No.", "Full Name", "Is Released" });
            cbFilterBy.SelectedIndex = 0;
            await _loadDataAsync();
        }

        private async Task _loadDataAsync()
        {
            try
            {
                _detainedLicenses = (await _licenseService.GetAllDetainedLicensesAsync()).ToList();
                _applyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading detained licenses: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _applyFilter()
        {
            string filter = cbFilterBy.SelectedItem?.ToString() ?? "None";
            string value = txtFilterValue.Text.Trim().ToLower();
            IEnumerable<DetainedLicenseDto> rows = _detainedLicenses;

            if (filter != "None" && value != "")
            {
                switch (filter)
                {
                    case "Detain ID":
                        rows = rows.Where(d => d.DetainID.ToString().StartsWith(value));
                        break;
                    case "License ID":
                        rows = rows.Where(d => d.LicenseID.ToString().StartsWith(value));
                        break;
                    case "National No.":
                        rows = rows.Where(d => d.NationalNo.ToLower().StartsWith(value));
                        break;
                    case "Full Name":
                        rows = rows.Where(d => d.FullName.ToLower().Contains(value));
                        break;
                    case "Is Released":
                        rows = rows.Where(d => (d.IsReleased ? "yes" : "no").StartsWith(value));
                        break;
                }
            }

            var result = rows.Select(d => new
            {
                DetainID = d.DetainID,
                LicenseID = d.LicenseID,
                DetainDate = d.DetainDate.ToString("dd/MM/yyyy"),
                IsReleased = d.IsReleased,
                FineFees = d.FineFees,
                ReleaseDate = d.ReleaseDate.HasValue ? d.ReleaseDate.Value.ToString("dd/MM/yyyy") : "",
                NationalNo = d.NationalNo,
                FullName = d.FullName,
                ReleaseApplicationID = d.ReleaseApplicationID
            }).ToList();

            dgvDetainedLicenses.DataSource = result;
            lblRecordsCount.Text = result.Count.ToString();
        }

        private DetainedLicenseDto _selectedDetainedLicense()
        {
            if (dgvDetainedLicenses.CurrentRow == null)
                return null;

            int detainId = (int)dgvDetainedLicenses.CurrentRow.Cells["DetainID"].Value;
            return _detainedLicenses.FirstOrDefault(d => d.DetainID == detainId);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = cbFilterBy.SelectedIndex > 0;
            txtFilterValue.Clear();
            _applyFilter();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _applyFilter();
        }

        private void cmsDetained_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DetainedLicenseDto detained = _selectedDetainedLicense();
            if (detained == null)
            {
                e.Cancel = true;
                return;
            }

            releaseToolStripMenuItem.Enabled = !detained.IsReleased;
        }

        private async void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetainedLicenseDto detained = _selectedDetainedLicense();
            if (detained == null)
                return;

            new ReleaseDetainedLicense(_licenseService, _personService, _applicationTypeService, detained.LicenseID).ShowDialog();
            await _loadDataAsync();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetainedLicenseDto detained = _selectedDetainedLicense();
            if (detained != null)
                new LicenseDetails(_licenseService, detained.LicenseID).ShowDialog();
        }

        private async void btnDetain_Click(object sender, EventArgs e)
        {
            new DetainLicense(_licenseService, _personService).ShowDialog();
            await _loadDataAsync();
        }

        private async void btnRelease_Click(object sender, EventArgs e)
        {
            new ReleaseDetainedLicense(_licenseService, _personService, _applicationTypeService).ShowDialog();
            await _loadDataAsync();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
