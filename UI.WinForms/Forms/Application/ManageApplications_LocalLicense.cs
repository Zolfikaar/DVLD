using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.Forms.Application
{
    public partial class ManageApplications_LocalLicense : Form
    {
        private readonly LocalLicenseService _localLicenseService;
        private readonly PersonService _personService;
        private List<LocalLicenseDto> _allApplications = new List<LocalLicenseDto>();

        public ManageApplications_LocalLicense(LocalLicenseService localLicenseService, PersonService personService)
        {
            InitializeComponent();
            _localLicenseService = localLicenseService;
            _personService = personService;
        }

        private async void ManageApplications_LocalLicense_Load(object sender, EventArgs e)
        {
            _setupFilterOptions();
            await _loadApplicationsDataAsync();
        }

        private async Task _loadApplicationsDataAsync()
        {
            try
            {
                var data = await _localLicenseService.GetAllLocalLicenseAsync();
                _allApplications = data?.ToList() ?? new List<LocalLicenseDto>();

                dgvLocalLicenses.DataSource = _allApplications;
                lblRecordsCount.Text = _allApplications.Count.ToString();
                dgvLocalLicenses.ContextMenuStrip = cmsLocalLicenses;
                _formatGridColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading applications: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _formatGridColumns()
        {
            if (dgvLocalLicenses.Columns.Count == 0) return;

            if (dgvLocalLicenses.Columns["LocalDrivingLicenseApplicationID"] != null)
                dgvLocalLicenses.Columns["LocalDrivingLicenseApplicationID"].HeaderText = "L.D.L.AppID";

            if (dgvLocalLicenses.Columns["ClassName"] != null)
                dgvLocalLicenses.Columns["ClassName"].HeaderText = "Driving Class";

            if (dgvLocalLicenses.Columns["NationalNo"] != null)
                dgvLocalLicenses.Columns["NationalNo"].HeaderText = "National No.";

            if (dgvLocalLicenses.Columns["FullName"] != null)
                dgvLocalLicenses.Columns["FullName"].HeaderText = "Full Name";

            if (dgvLocalLicenses.Columns["ApplicationDate"] != null)
            {
                dgvLocalLicenses.Columns["ApplicationDate"].HeaderText = "Application Date";
                dgvLocalLicenses.Columns["ApplicationDate"].DefaultCellStyle.Format = "g";
            }

            if (dgvLocalLicenses.Columns["PassedTestCount"] != null)
                dgvLocalLicenses.Columns["PassedTestCount"].HeaderText = "Passed Tests";

            if (dgvLocalLicenses.Columns["Status"] != null)
                dgvLocalLicenses.Columns["Status"].HeaderText = "Status";
        }

        private void _setupFilterOptions()
        {
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.Add("None");
            cbFilterBy.Items.Add("L.D.L.AppID");
            cbFilterBy.Items.Add("National No.");
            cbFilterBy.Items.Add("Full Name");
            cbFilterBy.Items.Add("Status");
            cbFilterBy.SelectedIndex = 0;

            txtFilterValue.Visible = false;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isFiltered = cbFilterBy.SelectedItem.ToString() != "None";
            txtFilterValue.Visible = isFiltered;

            if (!isFiltered)
            {
                txtFilterValue.Clear();
                dgvLocalLicenses.DataSource = _allApplications;
                lblRecordsCount.Text = _allApplications.Count.ToString();
            }
            else
            {
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtFilterValue.Text.Trim().ToLower();
            string selectedFilter = cbFilterBy.SelectedItem.ToString();

            if (string.IsNullOrEmpty(filterText))
            {
                dgvLocalLicenses.DataSource = _allApplications;
                lblRecordsCount.Text = _allApplications.Count.ToString();
                return;
            }

            IEnumerable<LocalLicenseDto> filtered = _allApplications;

            switch (selectedFilter)
            {
                case "L.D.L.AppID":
                    filtered = _allApplications.Where(x => x.LocalDrivingLicenseApplicationID.ToString().StartsWith(filterText));
                    break;
                case "National No.":
                    filtered = _allApplications.Where(x => x.NationalNo.ToLower().StartsWith(filterText));
                    break;
                case "Full Name":
                    filtered = _allApplications.Where(x => x.FullName.ToLower().Contains(filterText));
                    break;
                case "Status":
                    filtered = _allApplications.Where(x => x.Status.ToLower().StartsWith(filterText));
                    break;
            }

            var result = filtered.ToList();
            dgvLocalLicenses.DataSource = result;
            lblRecordsCount.Text = result.Count.ToString();
        }

        private void dgvLocalLicenses_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvLocalLicenses.ClearSelection();
                dgvLocalLicenses.Rows[e.RowIndex].Selected = true;

                int columnIndex = e.ColumnIndex >= 0 ? e.ColumnIndex : 0;
                dgvLocalLicenses.CurrentCell = dgvLocalLicenses.Rows[e.RowIndex].Cells[columnIndex];

                // إظهار القائمة المنسدلة بموقع الماوس فوراً
                if (dgvLocalLicenses.ContextMenuStrip != null)
                {
                    dgvLocalLicenses.ContextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private async void btnAddNew_Click(object sender, EventArgs e)
        {
            var frm = new AddEdit_LocalLicenseApplication(_localLicenseService, -1, _personService);
            frm.ShowDialog();
            await _loadApplicationsDataAsync();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLocalLicenses.CurrentRow == null) return;

            int selectedAppId = (int)dgvLocalLicenses.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value;
            var frm = new LocalLicense_ApplicationDetails(selectedAppId);
            frm.ShowDialog();
        }

        private async void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLocalLicenses.CurrentRow == null) return;

            int selectedAppId = (int)dgvLocalLicenses.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value;
            var frm = new AddEdit_LocalLicenseApplication(_localLicenseService, selectedAppId, _personService);
            frm.ShowDialog();
            await _loadApplicationsDataAsync();
        }

        private async void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLocalLicenses.CurrentRow == null) return;

            int selectedAppId = (int)dgvLocalLicenses.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value;

            if (MessageBox.Show("Are you sure you want to delete this application?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool deleted = await _localLicenseService.DeleteLocalLicenseAsync(selectedAppId);
                if (deleted)
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _loadApplicationsDataAsync();
                }
                else
                {
                    MessageBox.Show("Error: Application could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}