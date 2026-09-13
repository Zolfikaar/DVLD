using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Services;
using DependencyInjection;

namespace UI.WinForms.Forms.Person
{
    public partial class AddEditForm : Form
    {
        private readonly PersonService _personService;
        private readonly int _personId;
        private readonly bool _isEditMode;

        // Constructor يخدم الحالتين (الإضافة والتعديل)
        public AddEditForm(PersonService personService, int personId = -1)
        {
            InitializeComponent();
            _personService = personService;
            _personId = personId;
            _isEditMode = (personId > 0);
        }


        private async void AddEdit_Load(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                this.Text = "Edit Person";
                await _loadPersonDataAsync();
                await _loadCountriesAsync();
            }
            else
            {
                this.Text = "Add New Person";
                _resetForm();
            }
        }

        private async Task _loadPersonDataAsync()
        {
            try
            {
                var person = await _personService.GetPersonByPersonIdAsync(_personId);

                if (person == null)
                {
                    MessageBox.Show("Person not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                // 1. تعبئة النصوص
                lblPersonID.Text = person.PersonID.ToString();
                tbNationalNumber.Text = person.NationalNo;
                tbFirstname.Text = person.FirstName;
                tbSecondname.Text = person.SecondName;
                tbThirdname.Text = person.ThirdName;
                tbLastname.Text = person.LastName;
                tbEmail.Text = person.Email;
                tbPhone.Text = person.Phone;
                tbAddress.Text = person.Address;
                dtpDateOfBirth.Value = person.DateOfBirth;

                // 2. تعبئة الجنس
                if (person.GenderText == "Male")
                {
                    rbMale.Checked = true;
                }
                else if (person.GenderText == "Female")
                {
                    rbFemale.Checked = true;
                }

                

                // 3. تعبئة الدولة (تأكد أن cbCountry ممتلئ بدول ومربوط بـ ValueMember = "CountryID")
                if (person.NationalityCountryID > 0)
                {
                    cbCountry.SelectedValue = person.NationalityCountryID;
                }

                // 4. تعبئة الصورة
                if (!string.IsNullOrEmpty(person.ImagePath) && System.IO.File.Exists(person.ImagePath))
                {
                    pbPersonPhoto.BackgroundImage = Image.FromFile(person.ImagePath);
                }
                else
                {
                    // تحميل الصورة الافتراضية من الـ Resources حسب الجنس
                    pbPersonPhoto.BackgroundImage = person.GenderText == "Female"
                        ? Properties.Resources.icons8_person_100      // صورة الأنثى الافتراضية
                        : Properties.Resources.icons8_person_100_1; // صورة الذكر الافتراضية
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ أثناء جلب بيانات الشخص: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task _loadCountriesAsync()
        {
            var countries = await _personService.GetAllCountriesAsync();

            cbCountry.DataSource = countries.ToList();
            cbCountry.DisplayMember = "CountryName"; // النص المكتوب
            cbCountry.ValueMember = "CountryID";     // القيمة المخبأة
        }

        private void _resetForm()
        {
            // 1. تفريغ النصوص
            lblPersonID.Text = "N/A";
            tbNationalNumber.Clear();
            tbFirstname.Clear();
            tbSecondname.Clear();
            tbThirdname.Clear();
            tbLastname.Clear();
            tbEmail.Clear();
            tbPhone.Clear();
            tbAddress.Clear();

            // 2. ضبط التاريخ (الحد الأقصى 18 سنة لتجنب اختيار قاصر)
            DateTime maxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.MaxDate = DateTime.Now;
            dtpDateOfBirth.Value = maxDate;

            // 3. ضبط القيم الافتراضية
            rbMale.Checked = true;
            rbFemale.Checked = false;

            if (cbCountry.Items.Count > 0)
                cbCountry.SelectedIndex = 0;

            // 4. تفريغ الصورة وصورة الغلاف
            if (pbPersonPhoto.BackgroundImage != null)
            {
                pbPersonPhoto.BackgroundImage.Dispose();
                pbPersonPhoto.BackgroundImage = null;
            }

            // 5. مسح أخطاء الـ Validation إذا كانت معروضة
            errorProvider1.Clear();
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            _resetForm();
        }
    }
}
