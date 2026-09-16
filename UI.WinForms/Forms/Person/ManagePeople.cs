using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Services;
using UI.WinForms.Forms.Person;


namespace UI.WinForms.Forms
{
    public partial class ManagePeople : Form
    {
        private readonly PersonService _personService;
        private int _recordCount = 0;
        public ManagePeople(PersonService personService)
        {
            InitializeComponent();
            _personService = personService;
        }

        private async void ManagePeople_Load(object sender, EventArgs e)
        {
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
                var list = peopleList?.ToList();

                // 3. إسناد القائمة (الـ DTOs)
                dgvPeople.DataSource = list;

                // 4. التأكد من وجود بيانات قبل محاولة تعديل عناوين الأعمدة
                if (dgvPeople.Rows.Count > 0)
                {
                    _configureGridColumns();
                    _recordCount = list.Count;
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
    }
}
