using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.DTOs.Person;
using Application.Services;

namespace UI.WinForms.Forms.Person
{
    public partial class PersonDetails : Form
    {
        private readonly PersonService _personService;
        private readonly int _personId;
        private PersonDto _personDto;

        public PersonDetails(PersonService personService, int personId)
        {
            InitializeComponent();
            _personService = personService;
            _personId = personId;
        }

        private async void PersonDetailsForm_Shown(object sender, EventArgs e)
        {
            await _loadPersonDetailsAsync();
        }

        private async Task _loadPersonDetailsAsync()
        {
            try
            {
                _personDto = await _personService.GetPersonByPersonIdAsync(_personId);

                if (_personDto == null)
                {
                    MessageBox.Show("Person not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // 1. تعبئة النصوص المباشرة
                lblPersonId.Text = _personDto.PersonID.ToString();
                lblNationalNo.Text = _personDto.NationalNo;
                lblFullName.Text = $"{_personDto.FirstName} {_personDto.SecondName} {_personDto.ThirdName} {_personDto.LastName}".Replace("  ", " ");
                lblGender.Text = _personDto.GenderText;
                lblEmail.Text = string.IsNullOrEmpty(_personDto.Email) ? "N/A" : _personDto.Email;
                lblPhone.Text = _personDto.Phone;
                lblAddress.Text = _personDto.Address;
                lblDateOfBirth.Text = _personDto.DateOfBirth.ToShortDateString();

                // 2. جلب اسم البلد باستخدام NationalityCountryID
                await _loadCountryNameAsync(_personDto.NationalityCountryID);

                // 3. تحميل الصورة الشخصية
                _loadPersonImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading person details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task _loadCountryNameAsync(int countryId)
        {
            var countries = await _personService.GetAllCountriesAsync();
            var country = countries.FirstOrDefault(c => c.CountryID == countryId);

            lblCountry.Text = country != null ? country.CountryName : "N/A";
        }

        private void _loadPersonImage()
        {
            if (!string.IsNullOrEmpty(_personDto.ImagePath) && File.Exists(_personDto.ImagePath))
            {
                pbPersonPicture.ImageLocation = _personDto.ImagePath;
            }
            else
            {
                if (_personDto.GenderText == "Male")
                    pbPersonPicture.Image = Properties.Resources.icons8_person_100_1;
                else
                    pbPersonPicture.Image = Properties.Resources.icons8_person_100;
            }
        }

        private async void lnklblEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new AddEditForm(_personService, _personId);
            frm.ShowDialog();

            await _loadPersonDetailsAsync();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}