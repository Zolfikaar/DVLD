using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.Forms.Application
{
    public partial class ManageApplicationTypes : Form
    {
        private readonly ApplicationTypeService _applicationTypeService;

        public ManageApplicationTypes(ApplicationTypeService applicationTypeService)
        {
            InitializeComponent();
            _applicationTypeService = applicationTypeService;
        }

        private async void ApplicationTypes_Load(object sender, EventArgs e)
        {
            // ربط الـ ContextMenu بالـ DataGridView لضمان الظهور
            if (contextMenuStrip1 != null)
            {
                dgvApplicationTypes.ContextMenuStrip = contextMenuStrip1;
            }

            await LoadApplicationTypesAsync();
        }

        private async Task LoadApplicationTypesAsync()
        {
            try
            {
                var types = await _applicationTypeService.GetAllApplicationTypesAsync();
                var list = types?.ToList() ?? new List<ApplicationTypeDto>();

                dgvApplicationTypes.DataSource = list;
                lblRecordsCount.Text = list.Count.ToString();

                _formatGridColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _formatGridColumns()
        {
            if (dgvApplicationTypes.Columns.Count == 0) return;

            if (dgvApplicationTypes.Columns["ApplicationTypeID"] != null)
                dgvApplicationTypes.Columns["ApplicationTypeID"].HeaderText = "ID";

            if (dgvApplicationTypes.Columns["ApplicationTypeTitle"] != null)
                dgvApplicationTypes.Columns["ApplicationTypeTitle"].HeaderText = "Title";

            if (dgvApplicationTypes.Columns["ApplicationFees"] != null)
            {
                dgvApplicationTypes.Columns["ApplicationFees"].HeaderText = "Fees";
                dgvApplicationTypes.Columns["ApplicationFees"].DefaultCellStyle.Format = "N4";
            }
        }

        private void dgvApplicationTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvApplicationTypes.ClearSelection();
                dgvApplicationTypes.Rows[e.RowIndex].Selected = true;

                // تحديد الخلية الحالية لمنع حدوث NullReference في CurrentRow
                int columnIndex = e.ColumnIndex >= 0 ? e.ColumnIndex : 0;
                dgvApplicationTypes.CurrentCell = dgvApplicationTypes.Rows[e.RowIndex].Cells[columnIndex];
            }
        }

        private async void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplicationTypes.CurrentRow == null) return;

            int selectedId = (int)dgvApplicationTypes.CurrentRow.Cells["ApplicationTypeID"].Value;

            var frm = new EditApplicationType(_applicationTypeService, selectedId);
            frm.ShowDialog();

            await LoadApplicationTypesAsync();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}