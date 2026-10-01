using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;
using UI.WinForms.Forms.License;
using UI.WinForms.Forms.Test;

namespace UI.WinForms.Forms.Application
{
    public partial class ManageApplications_LocalLicense : Form
    {
        private readonly LocalLicenseService _localLicenseService;
        private readonly PersonService _personService;
        private readonly TestAppointmentService _testAppointmentService;
        private readonly TestTypeService _testTypeService;
        private readonly ApplicationTypeService _applicationTypeService;
        private readonly LicenseService _licenseService;
        private List<LocalLicenseDto> _allApplications = new List<LocalLicenseDto>();

        public ManageApplications_LocalLicense(LocalLicenseService localLicenseService, PersonService personService,
            TestAppointmentService testAppointmentService, TestTypeService testTypeService,
            ApplicationTypeService applicationTypeService, LicenseService licenseService)
        {
            InitializeComponent();
            _localLicenseService = localLicenseService;
            _personService = personService;
            _testAppointmentService = testAppointmentService;
            _testTypeService = testTypeService;
            _applicationTypeService = applicationTypeService;
            _licenseService = licenseService;
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
            var frm = new LocalLicense_ApplicationDetails(selectedAppId, _localLicenseService, _personService, _licenseService);
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

            if (MessageBox.Show("Are you sure you want to delete this application?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                if (await _localLicenseService.DeleteLocalLicenseAsync(selectedAppId))
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _loadApplicationsDataAsync();
                }
                else
                {
                    MessageBox.Show("Error: Application could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting the application: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private LocalLicenseDto _selectedApplication()
        {
            if (dgvLocalLicenses.CurrentRow == null)
                return null;

            int selectedAppId = (int)dgvLocalLicenses.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value;
            return _allApplications.FirstOrDefault(a => a.LocalDrivingLicenseApplicationID == selectedAppId);
        }

        private void cmsLocalLicenses_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LocalLicenseDto application = _selectedApplication();
            if (application == null)
            {
                e.Cancel = true;
                return;
            }

            bool isNew = application.ApplicationStatus == LocalLicenseDto.StatusNew;
            bool hasLicense = application.LicenseID > 0;
            int passed = application.PassedTestCount;

            editApplicationToolStripMenuItem.Enabled = isNew && passed == 0;
            deleteApplicationToolStripMenuItem.Enabled = isNew && passed == 0;
            cancelApplicationToolStripMenuItem.Enabled = isNew;

            scheduleTestsToolStripMenuItem.Enabled = isNew && passed < 3;
            scheduleVisionTestToolStripMenuItem.Enabled = isNew && passed == 0;
            scheduleWrittenTestToolStripMenuItem.Enabled = isNew && passed == 1;
            scheduleStreetTestToolStripMenuItem.Enabled = isNew && passed == 2;

            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = isNew && passed == 3 && !hasLicense;
            showLicenseToolStripMenuItem.Enabled = hasLicense;
        }

        private async void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalLicenseDto application = _selectedApplication();
            if (application == null)
                return;

            if (MessageBox.Show("Are you sure you want to cancel application #" + application.LocalDrivingLicenseApplicationID + "?",
                    "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                if (await _localLicenseService.CancelLocalLicenseAsync(application.LocalDrivingLicenseApplicationID))
                {
                    MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _loadApplicationsDataAsync();
                }
                else
                {
                    MessageBox.Show("The application could not be cancelled. Only applications with status 'New' can be cancelled.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cancelling the application: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task _openTestAppointmentsAsync(int testTypeId)
        {
            LocalLicenseDto application = _selectedApplication();
            if (application == null)
                return;

            new ManageTestAppointments(application.LocalDrivingLicenseApplicationID, testTypeId, _localLicenseService,
                _testAppointmentService, _testTypeService, _applicationTypeService).ShowDialog();

            await _loadApplicationsDataAsync();
        }

        private async void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await _openTestAppointmentsAsync(1);
        }

        private async void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await _openTestAppointmentsAsync(2);
        }

        private async void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await _openTestAppointmentsAsync(3);
        }

        private async void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalLicenseDto application = _selectedApplication();
            if (application == null)
                return;

            new IssueLicenseFirstTime(application.LocalDrivingLicenseApplicationID, _localLicenseService, _licenseService).ShowDialog();
            await _loadApplicationsDataAsync();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalLicenseDto application = _selectedApplication();
            if (application == null || application.LicenseID <= 0)
                return;

            new LicenseDetails(_licenseService, application.LicenseID).ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalLicenseDto application = _selectedApplication();
            if (application == null)
                return;

            new LicenseHistory(_licenseService, _personService, application.ApplicantPersonID).ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}