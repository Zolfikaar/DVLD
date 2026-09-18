using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.WinForms.UserControls
{
    /// <summary>
    /// Designer surface only. WinForms cannot design a generic UserControl,
    /// so all grid behavior lives in <see cref="ctrlDataGridManager{T}"/> below.
    /// </summary>
    public partial class ctrlDataGridManager : UserControl
    {
        public ctrlDataGridManager()
        {
            InitializeComponent();
        }
    }

    public class ctrlDataGridManager<T> : ctrlDataGridManager where T : class
    {
        private const string NoneFilterOption = "None";

        private Func<Task<IEnumerable<T>>> _dataFetcher;
        private Dictionary<string, string> _columnHeaders;
        private Dictionary<string, Func<T, string, bool>> _filterConditions;
        private Func<T, object> _keySelector;
        private List<T> _allItems = new List<T>();
        private bool _isInitialized;
        private bool _isBinding;

        public event EventHandler OnAddNewClicked;
        public event EventHandler OnEditClicked;
        public event EventHandler OnDeleteClicked;
        public event EventHandler<T> OnRowSelected;

        public ctrlDataGridManager()
        {
            WireControlEvents();
        }

        public async Task InitializeManagerAsync(
            string title,
            Func<Task<IEnumerable<T>>> dataFetcher,
            Dictionary<string, string> columnHeaders,
            Dictionary<string, Func<T, string, bool>> filterConditions,
            ContextMenuStrip contextMenu = null,
            Func<T, object> keySelector = null)
        {
            if (dataFetcher == null)
                throw new ArgumentNullException(nameof(dataFetcher));

            _dataFetcher = dataFetcher;
            _columnHeaders = columnHeaders ?? new Dictionary<string, string>();
            _filterConditions = filterConditions ?? new Dictionary<string, Func<T, string, bool>>();
            _keySelector = keySelector;

            lblTitle.Text = title ?? string.Empty;
            dgvList.ContextMenuStrip = contextMenu;

            ConfigureFilterOptions();
            _isInitialized = true;

            await RefreshDataAsync();
        }

        public async Task RefreshDataAsync()
        {
            if (_dataFetcher == null)
                return;

            object keyToRestore = GetSelectedKey();

            try
            {
                IEnumerable<T> data = await _dataFetcher();
                _allItems = data != null ? data.ToList() : new List<T>();
                ApplyFilter(keyToRestore);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while loading data: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public T GetSelectedEntity()
        {
            if (dgvList == null)
                return null;

            if (dgvList.CurrentRow != null && dgvList.CurrentRow.DataBoundItem != null)
                return dgvList.CurrentRow.DataBoundItem as T;

            if (dgvList.SelectedRows.Count > 0 && dgvList.SelectedRows[0].DataBoundItem != null)
                return dgvList.SelectedRows[0].DataBoundItem as T;

            return null;
        }

        private void WireControlEvents()
        {
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            dgvList.CellMouseDown += dgvList_CellMouseDown;
            dgvList.SelectionChanged += dgvList_SelectionChanged;
            dgvList.DataBindingComplete += dgvList_DataBindingComplete;
        }

        private void ConfigureFilterOptions()
        {
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.Add(NoneFilterOption);

            if (_filterConditions != null)
            {
                foreach (string filterOption in _filterConditions.Keys)
                {
                    if (!string.IsNullOrWhiteSpace(filterOption) &&
                        !string.Equals(filterOption, NoneFilterOption, StringComparison.OrdinalIgnoreCase))
                    {
                        cbFilterBy.Items.Add(filterOption);
                    }
                }
            }

            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = false;
            txtFilterValue.Clear();
        }

        private void BindGrid(List<T> items, object keyToRestore)
        {
            List<T> source = items ?? new List<T>();

            if (keyToRestore == null)
                keyToRestore = GetSelectedKey();

            _isBinding = true;
            try
            {
                dgvList.AutoGenerateColumns = true;
                dgvList.DataSource = null;
                dgvList.DataSource = source;

                ApplyColumnHeaders();
                UpdateRecordsCount(source.Count);
                RestoreSelection(keyToRestore);
                UpdateActionButtonsState();
                dgvList.Refresh();
            }
            finally
            {
                _isBinding = false;
            }
        }

        private object GetSelectedKey()
        {
            if (_keySelector == null)
                return null;

            T selectedEntity = GetSelectedEntity();
            if (selectedEntity == null)
                return null;

            return _keySelector(selectedEntity);
        }

        private void RestoreSelection(object key)
        {
            if (dgvList.Rows.Count == 0)
                return;

            DataGridViewRow targetRow = FindRowByKey(key);
            if (targetRow == null)
                return;

            SelectRow(targetRow);
        }

        private DataGridViewRow FindRowByKey(object key)
        {
            if (key == null || _keySelector == null)
                return null;

            foreach (DataGridViewRow row in dgvList.Rows)
            {
                T item = row.DataBoundItem as T;
                if (item == null)
                    continue;

                if (Equals(_keySelector(item), key))
                    return row;
            }

            return null;
        }

        private void SelectRow(DataGridViewRow row)
        {
            if (row == null)
                return;

            int columnIndex = GetFirstVisibleColumnIndex();
            if (columnIndex < 0)
                return;

            dgvList.ClearSelection();
            row.Selected = true;
            if (row.Cells[columnIndex].Visible)
                dgvList.CurrentCell = row.Cells[columnIndex];
        }

        private void ApplyColumnHeaders()
        {
            if (dgvList.Columns.Count == 0 || _columnHeaders == null || _columnHeaders.Count == 0)
                return;

            foreach (DataGridViewColumn column in dgvList.Columns)
            {
                if (column == null)
                    continue;

                string propertyName = string.IsNullOrEmpty(column.DataPropertyName)
                    ? column.Name
                    : column.DataPropertyName;

                string headerText;
                if (_columnHeaders.TryGetValue(propertyName, out headerText))
                {
                    column.HeaderText = headerText;
                    column.Visible = true;
                }
                else
                {
                    column.Visible = false;
                }
            }
        }

        private void ApplyFilter(object keyToRestore = null)
        {
            if (!_isInitialized)
                return;

            string selectedFilter = cbFilterBy.SelectedItem as string;
            string searchText = txtFilterValue.Text != null ? txtFilterValue.Text.Trim() : string.Empty;

            if (string.IsNullOrEmpty(selectedFilter) ||
                string.Equals(selectedFilter, NoneFilterOption, StringComparison.OrdinalIgnoreCase) ||
                string.IsNullOrEmpty(searchText))
            {
                BindGrid(_allItems, keyToRestore);
                return;
            }

            Func<T, string, bool> predicate;
            if (_filterConditions == null ||
                !_filterConditions.TryGetValue(selectedFilter, out predicate) ||
                predicate == null)
            {
                BindGrid(_allItems, keyToRestore);
                return;
            }

            List<T> filteredList = _allItems
                .Where(item => item != null && predicate(item, searchText))
                .ToList();

            BindGrid(filteredList, keyToRestore);
        }

        private void UpdateRecordsCount(int count)
        {
            lblRecordsCount.Text = count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = cbFilterBy.SelectedItem as string;
            bool isFilterActive = !string.IsNullOrEmpty(selectedFilter) &&
                                  !string.Equals(selectedFilter, NoneFilterOption, StringComparison.OrdinalIgnoreCase);

            txtFilterValue.Visible = isFilterActive;

            if (!isFilterActive)
            {
                txtFilterValue.Clear();
                BindGrid(_allItems, GetSelectedKey());
                return;
            }

            txtFilterValue.Focus();
            ApplyFilter();
        }

        private void dgvList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || e.RowIndex < 0 || e.RowIndex >= dgvList.Rows.Count)
                return;

            DataGridViewRow row = dgvList.Rows[e.RowIndex];
            if (row == null)
                return;

            SelectRow(row);
            RaiseRowSelected();
        }

        private int GetFirstVisibleColumnIndex()
        {
            foreach (DataGridViewColumn column in dgvList.Columns)
            {
                if (column != null && column.Visible)
                    return column.Index;
            }

            return -1;
        }

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            if (_isBinding)
                return;

            RaiseRowSelected();
        }

        private void dgvList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            UpdateActionButtonsState();
        }

        private void RaiseRowSelected()
        {
            UpdateActionButtonsState();

            T selectedEntity = GetSelectedEntity();
            if (selectedEntity != null)
                OnRowSelected?.Invoke(this, selectedEntity);
        }

        private void UpdateActionButtonsState()
        {
            bool hasSelection = GetSelectedEntity() != null;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OnAddNewClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (GetSelectedEntity() == null)
                return;

            OnEditClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (GetSelectedEntity() == null)
                return;

            OnDeleteClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
