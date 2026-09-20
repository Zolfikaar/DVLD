using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.Forms.Test
{
    public partial class ManageTestTypes : Form
    {
        private readonly TestTypeService _testTypeService;

        public ManageTestTypes(TestTypeService testTypeService)
        {
            InitializeComponent();
            _testTypeService = testTypeService;
        }

        private async void TestTypes_Load(object sender, EventArgs e)
        {
            // ربط الـ ContextMenu بالـ DataGridView لضمان الظهور
            if (contextMenuStrip1 != null)
            {
                dgvTestTypes.ContextMenuStrip = contextMenuStrip1;
            }

            await LoadTestTypesAsync();
        }

        private async Task LoadTestTypesAsync()
        {
            try
            {
                var types = await _testTypeService.GetAllTestTypesAsync();
                var list = types?.ToList() ?? new List<TestTypeDto>();

                dgvTestTypes.DataSource = list;
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
            if (dgvTestTypes.Columns.Count == 0) return;

            if (dgvTestTypes.Columns["TestTypeID"] != null)
                dgvTestTypes.Columns["TestTypeID"].HeaderText = "ID";

            if (dgvTestTypes.Columns["TestTypeTitle"] != null)
                dgvTestTypes.Columns["TestTypeTitle"].HeaderText = "Title";

            if (dgvTestTypes.Columns["TestTypeDescription"] != null)
                dgvTestTypes.Columns["TestTypeDescription"].HeaderText = "Description";

            if (dgvTestTypes.Columns["TestTypeFees"] != null)
            {
                dgvTestTypes.Columns["TestTypeFees"].HeaderText = "Fees";
                dgvTestTypes.Columns["TestTypeFees"].DefaultCellStyle.Format = "N4";
            }
        }

        private void dgvTestTypes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvTestTypes.ClearSelection();
                dgvTestTypes.Rows[e.RowIndex].Selected = true;

                // تحديد الخلية الحالية لمنع حدوث NullReference في CurrentRow
                int columnIndex = e.ColumnIndex >= 0 ? e.ColumnIndex : 0;
                dgvTestTypes.CurrentCell = dgvTestTypes.Rows[e.RowIndex].Cells[columnIndex];
            }
        }

        private async void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTestTypes.CurrentRow == null) return;

            int selectedId = (int)dgvTestTypes.CurrentRow.Cells["TestTypeID"].Value;

            var frm = new EditTestType(_testTypeService, selectedId);
            frm.ShowDialog();

            await LoadTestTypesAsync();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}