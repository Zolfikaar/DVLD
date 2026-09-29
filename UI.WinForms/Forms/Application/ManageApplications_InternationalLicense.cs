using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;
using UI.WinForms.Forms.License;

namespace UI.WinForms.Forms.Application
{
    public partial class ManageApplications_InternationalLicense : Form
    {
        private readonly LicenseService _licenseService;
        private readonly PersonService _personService;
        private readonly ApplicationTypeService _applicationTypeService;
        private List<InternationalLicenseDto> _licenses = new List<InternationalLicenseDto>();

        public ManageApplications_InternationalLicense(LicenseService licenseService, PersonService personService,
            ApplicationTypeService applicationTypeService)
        {
            InitializeComponent();
            _licenseService = licenseService;
            _personService = personService;
            _applicationTypeService = applicationTypeService;
        }

        private async void ManageApplications_InternationalLicense_Load(object sender, EventArgs e)
        {
            cbFilterBy.Items.AddRange(new object[] { "None", "Int.License ID", "Local License ID", "National No.", "Full Name", "Is Active" });
            cbFilterBy.SelectedIndex = 0;
            await _loadDataAsync();
        }

        private async Task _loadDataAsync()
        {
            try
            {
                _licenses = (await _licenseService.GetAllInternationalLicensesAsync()).ToList();
                _applyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading international licenses: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _applyFilter()
        {
            string filter = cbFilterBy.SelectedItem?.ToString() ?? "None";
            string value = txtFilterValue.Text.Trim().ToLower();
            IEnumerable<InternationalLicenseDto> rows = _licenses;

            if (filter != "None" && value != "")
            {
                switch (filter)
                {
                    case "Int.License ID":
                        rows = rows.Where(l => l.InternationalLicenseID.ToString().StartsWith(value));
                        break;
                    case "Local License ID":
                        rows = rows.Where(l => l.IssuedUsingLocalLicenseID.ToString().StartsWith(value));
                        break;
                    case "National No.":
                        rows = rows.Where(l => l.NationalNo.ToLower().StartsWith(value));
                        break;
                    case "Full Name":
                        rows = rows.Where(l => l.FullName.ToLower().Contains(value));
                        break;
                    case "Is Active":
                        rows = rows.Where(l => (l.IsActive ? "yes" : "no").StartsWith(value));
                        break;
                }
            }

            var result = rows.Select(l => new
            {
                InternationalLicenseID = l.InternationalLicenseID,
                ApplicationID = l.ApplicationID,
                DriverID = l.DriverID,
                LocalLicenseID = l.IssuedUsingLocalLicenseID,
                NationalNo = l.NationalNo,
                FullName = l.FullName,
                IssueDate = l.IssueDate.ToString("dd/MM/yyyy"),
                ExpirationDate = l.ExpirationDate.ToString("dd/MM/yyyy"),
                IsActive = l.IsActive
            }).ToList();

            dgvApplications.DataSource = result;
            lblRecordsCount.Text = result.Count.ToString();
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

        private async void btnAddNew_Click(object sender, EventArgs e)
        {
            new IssueInternationalLicense(_licenseService, _personService, _applicationTypeService).ShowDialog();
            await _loadDataAsync();
        }

        private void dgvApplications_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int id = (int)dgvApplications.Rows[e.RowIndex].Cells["InternationalLicenseID"].Value;
            InternationalLicenseDto license = _licenses.FirstOrDefault(l => l.InternationalLicenseID == id);
            if (license != null)
                new LicenseHistory(_licenseService, _personService, license.PersonID).ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
