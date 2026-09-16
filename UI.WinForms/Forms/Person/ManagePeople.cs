using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.DTOs.Person;
using Application.Services;
using UI.WinForms.Forms.Person;


namespace UI.WinForms.Forms
{
    public partial class ManagePeople : Form
    {
        private readonly PersonService _personService;
        private int _recordCount = 0;
        private List<PersonDto> _allPeopleList = new List<PersonDto>();
        //private List<string> _filterByList = new List<string>();
        public ManagePeople(PersonService personService)
        {
            InitializeComponent();
            _personService = personService;
        }

        private async void ManagePeople_Load(object sender, EventArgs e)
        {
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.Add("None");
            cbFilterBy.Items.Add("Person ID");
            cbFilterBy.Items.Add("National No");
            cbFilterBy.Items.Add("First Name");
            cbFilterBy.Items.Add("Phone");
            cbFilterBy.Items.Add("Email");

            cbFilterBy.SelectedIndex = 0;

            await _refreshPeopleListAsync();
        }

        private async Task _refreshPeopleListAsync()
        {
            try
            {
                var peopleList = await _personService.GetAllPeopleAsync();

                // 1. تنظيف أي ربط سابق
                dgvPeople.DataSource = null;

                // 2. السماح للتوليد التلقائي للـ Columns بناءً على الـ DTO
                dgvPeople.AutoGenerateColumns = true;

                // تحويل الـ IEnumerable إلى List صريحة لمنع مشاكل الـ Deferred Execution مع الـ Binding
                _allPeopleList = peopleList?.ToList();

                // 3. إسناد القائمة (الـ DTOs)
                dgvPeople.DataSource = _allPeopleList;

                // 4. التأكد من وجود بيانات قبل محاولة تعديل عناوين الأعمدة
                if (dgvPeople.Rows.Count > 0)
                {
                    _configureGridColumns();
                    _recordCount = _allPeopleList.Count;
                }

                lblRecordsCount.Text = _recordCount.ToString();
                // إجبار الشاشة على إعادة رسم العناصر فوراً
                dgvPeople.Refresh();
                dgvPeople.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ أثناء تحميل بيانات الأشخاص: {ex.Message}", "خطأ",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _configureGridColumns()
        {
            if (dgvPeople.Columns.Count == 0) return;

            _setColumnHeader("PersonID", "Person ID");
            _setColumnHeader("NationalNo", "National No");
            _setColumnHeader("FullName", "Full Name");
            _setColumnHeader("GenderText", "Gender");
            _setColumnHeader("DateOfBirth", "Date Of Birth");
            _setColumnHeader("Phone", "Phone");
            _setColumnHeader("Email", "Email");
            _setColumnHeader("Address", "Address");

            // 2. إخفاء الأعمدة غير المطلوبة بأسماء مطابقة للـ DTO
            _hideColumn("FirstName");
            _hideColumn("SecondName");
            _hideColumn("thirdName");
            _hideColumn("LastName");
            _hideColumn("NationalityCountryID");
            _hideColumn("ImagePath");

        }

        // ميثود مساعدة لتغيير الاسم دون رمي استثناء
        private void _setColumnHeader(string columnName, string headerText)
        {
            if (dgvPeople.Columns.Contains(columnName))
                dgvPeople.Columns[columnName].HeaderText = headerText;
                

        }

        // ميثود مساعدة للإخفاء بأمان
        private void _hideColumn(string columnName)
        {
            if (dgvPeople.Columns.Contains(columnName))
                dgvPeople.Columns[columnName].Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var frm = new AddEditForm(_personService);
            frm.ShowDialog();

            // إعادة تحميل الجدول بعد إغلاق الشاشة لتحديث البيانات
            _ = _refreshPeopleListAsync();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPeople.CurrentRow == null) return;

            // سحب الـ PersonalID من الصف المحدد حالياً
            int selectedPersonId = (int)dgvPeople.CurrentRow.Cells["PersonID"].Value;

            // تمرير الخدمة والـ ID للشاشة
            var frm = new AddEditForm(_personService, selectedPersonId);
            frm.ShowDialog();

            // إعادة تحديث الجدول فور الإغلاق
            _ = _refreshPeopleListAsync();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPeople.CurrentRow == null) return;

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this person?",
                "Confirm Delete",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.OK)
            {
                int selectedPersonId = (int)dgvPeople.CurrentRow.Cells["PersonID"].Value;

                try
                {
                    bool isDeleted = await _personService.DeletePersonAsync(selectedPersonId);

                    if (isDeleted)
                    {
                        MessageBox.Show("Person deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await _refreshPeopleListAsync();
                    }
                    else
                    {
                        MessageBox.Show("Person could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Microsoft.Data.SqlClient.SqlException ex) when (ex.Number == 547) // 547 = Foreign Key Constraint Violation
                {
                    MessageBox.Show(
                        "Cannot delete this person because they have related data linked in the system.",
                        "Delete Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = tbSearch.Text.Trim();
            string selectedFilter = cbFilterBy.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(searchText) || string.IsNullOrEmpty(selectedFilter))
            {
                dgvPeople.DataSource = _allPeopleList; // إعادة القائمة كاملة
                return;
            }

            // فلترة القائمة بناءً على الخيار المحدد في الـ DropDown
            var filteredList = _allPeopleList.Where(p =>
            {
                switch (selectedFilter)
                {
                    case "Person ID":
                        return p.PersonID.ToString().StartsWith(searchText);

                    case "National No":
                        return p.NationalNo.StartsWith(searchText, StringComparison.OrdinalIgnoreCase);

                    case "First Name":
                        return p.FirstName.StartsWith(searchText, StringComparison.OrdinalIgnoreCase);

                    case "Email":
                        return p.Email != null && p.Email.StartsWith(searchText, StringComparison.OrdinalIgnoreCase);

                    case "Phone":
                        return p.Phone != null && p.Phone.Contains(searchText);

                    default:
                        return true;
                }
            }).ToList();

            dgvPeople.DataSource = filteredList;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // إخفاء/إظهار حقل البحث النصي وتفريغه عند اختيار None
            bool isFilterActive = cbFilterBy.SelectedItem?.ToString() != "None";
            tbSearch.Visible = isFilterActive;

            if (!isFilterActive)
            {
                tbSearch.Clear();
                dgvPeople.DataSource = _allPeopleList;
            }
            else
            {
                tbSearch.Focus();
            }
        }
    }
}
