using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.DTOs.Person;
using Application.Services;
using DependencyInjection;

namespace UI.WinForms.Forms.Person
{
    public partial class AddEditForm : Form
    {
        private readonly PersonService _personService;
        private int _personId;
        private bool _isEditMode;
        private string _selectedImagePath = string.Empty;

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
                await _loadCountriesAsync();
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

            var countriesList = countries.ToList();
            cbCountry.DisplayMember = "CountryName"; // النص المكتوب
            cbCountry.ValueMember = "CountryID";     // القيمة المخبأة
            cbCountry.DataSource = null;
            cbCountry.DataSource = countriesList;
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

        private async Task<bool> _validateInputsAsync()
        {
            // 1. الفحص المبدئي للحقول الإجبارية
            if (string.IsNullOrWhiteSpace(tbNationalNumber.Text) ||
                string.IsNullOrWhiteSpace(tbFirstname.Text) ||
                string.IsNullOrWhiteSpace(tbSecondname.Text) ||
                string.IsNullOrWhiteSpace(tbLastname.Text) ||
                string.IsNullOrWhiteSpace(tbPhone.Text) ||
                string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                MessageBox.Show("Please fill all required fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 2. فحص صحة البريد الإلكتروني (إن وُجد)
            if (!string.IsNullOrWhiteSpace(tbEmail.Text) && !_isValidEmail(tbEmail.Text.Trim()))
            {
                MessageBox.Show("Invalid Email format!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 3. الفحص في حالة الإضافة فقط: التأكد من عدم تكرار الرقم القومي عبر الـ Service
            if (!_isEditMode)
            {
                bool isNationalNoExists = await _personService.IsPersonExists(tbNationalNumber.Text.Trim());
                if (isNationalNoExists)
                {
                    MessageBox.Show("This National Number is already assigned to another person!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        // ميثود مساعدة لفحص صيغة الإيميل
        private bool _isValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = ofd.FileName;
                    pbPersonPhoto.BackgroundImage = Image.FromFile(_selectedImagePath);
                }
            }
        }

        private string _handlePersonImage()
        {
            // إذا لم يتم اختيار صورة جديدة ولم تكن هناك صورة أصلية
            if (string.IsNullOrEmpty(_selectedImagePath))
            {
                return string.Empty;
            }

            try
            {
                // 1. تحديد مجلد التخزين
                string imagesFolder = Path.Combine(System.Windows.Forms.Application.StartupPath, "People_Photos");
                if (!Directory.Exists(imagesFolder))
                {
                    Directory.CreateDirectory(imagesFolder);
                }

                // 2. توليد اسم فريد للصورة باستخدام Guid
                string fileExtension = Path.GetExtension(_selectedImagePath);
                string newFileName = $"{Guid.NewGuid()}{fileExtension}";
                string destinationPath = Path.Combine(imagesFolder, newFileName);

                // 3. نسخ الصورة إلى مجلد المشروع
                File.Copy(_selectedImagePath, destinationPath, true);

                return destinationPath; // هذا هو المسار الذي سيتخزن بالداتابيس
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ أثناء حفظ الصورة: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private async void btnSaveRecord_Click(object sender, EventArgs e)
        {
            var isValidInputs = await _validateInputsAsync();
            if (!isValidInputs) return;

            // معالجة الصورة واستخراج المسار النهائي
            string imagePathToSave = _handlePersonImage();

            // معالجة امنة ل id البلد
            int selectedCountryId = 0;

            if (cbCountry.SelectedValue != null)
            {
                // إذا كانت القيمة كائن CountryDto بدلاً من الرقم، نسحب منه الخاصية
                if (cbCountry.SelectedValue is int id)
                {
                    selectedCountryId = id;
                }
                else if (int.TryParse(cbCountry.SelectedValue.ToString(), out int parsedId))
                {
                    selectedCountryId = parsedId;
                }
            }

            var personDto = new PersonDto
            {
                NationalNo = tbNationalNumber.Text.Trim(),
                FirstName = tbFirstname.Text.Trim(),
                SecondName = tbSecondname.Text.Trim(),
                ThirdName = tbThirdname.Text.Trim(),
                LastName = tbLastname.Text.Trim(),
                GenderText = rbMale.Checked ? "Male" : "Female",
                DateOfBirth = dtpDateOfBirth.Value,
                Phone = tbPhone.Text.Trim(),
                Email = tbEmail.Text.Trim(),
                Address = tbAddress.Text.Trim(),
                NationalityCountryID = selectedCountryId,
                ImagePath = imagePathToSave // مسار الصورة بعد حفظها
            };

            try
            {
                int newPersonId = await _personService.AddPersonAsync(personDto);
                if (newPersonId > 0)
                {
                    MessageBox.Show($"Person Saved Successfully with ID: {newPersonId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // تحويل الشاشة لوضع التعديل بعد الإضافة النجاح
                    _personId = newPersonId;
                    _isEditMode = true;
                    this.Text = "Edit Person";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
