using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Services;


namespace UI.WinForms.Forms
{
    public partial class ManagePeople : Form
    {
        private readonly PersonService _personService;
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
                }

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

            // 1. الاسم هنا يجب أن يكون PersonalID ليطابق الـ DTO
            _setColumnHeader("PersonalID", "Person ID");
            _setColumnHeader("NationalNo", "National No");
            _setColumnHeader("FullName", "Full Name");
            _setColumnHeader("GenderText", "Gender");
            _setColumnHeader("DateOfBirth", "Date Of Birth");
            _setColumnHeader("Phone", "Phone");
            _setColumnHeader("Email", "Email");
            _setColumnHeader("Address", "Address");

            // 2. إخفاء الأعمدة غير المطلوبة بأسماء مطابقة للـ DTO
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
    }
}
