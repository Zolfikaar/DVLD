using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.DTOs;
using Application.DTOs.Person;
using Application.Services;

namespace UI.WinForms.UserControls
{
    public partial class ctrlPersonCard : UserControl
    {
        private PersonService _personService;
        private int _personId;
        private PersonDto _personDto;

        public event EventHandler OnEditClicked;

        public int PersonId
        {
            get { return _personId; }
        }

        public PersonDto CurrentPerson
        {
            get { return _personDto; }
        }

        public bool ShowEditLink
        {
            get { return lnklblEditInfo.Visible; }
            set { lnklblEditInfo.Visible = value; }
        }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public async Task LoadPersonAsync(PersonService personService, int personId)
        {
            if (personService == null)
                throw new ArgumentNullException(nameof(personService));

            _personService = personService;
            _personId = personId;
            await RefreshDataAsync();
        }

        public async Task RefreshDataAsync()
        {
            if (_personService == null || _personId <= 0)
                return;

            try
            {
                _personDto = await _personService.GetPersonByPersonIdAsync(_personId);
                if (_personDto == null)
                {
                    MessageBox.Show("Person not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FindForm()?.Close();
                    return;
                }

                BindPerson(_personDto);
                await LoadCountryNameAsync(_personDto.NationalityCountryID);
                LoadPersonImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading person details: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BindPerson(PersonDto person, string countryName = null)
        {
            if (person == null)
                return;

            _personDto = person;
            _personId = person.PersonID;

            lblPersonId.Text = person.PersonID.ToString();
            lblNationalNo.Text = person.NationalNo;
            lblFullName.Text = string.IsNullOrWhiteSpace(person.FullName)
                ? (person.FirstName + " " + person.SecondName + " " + person.ThirdName + " " + person.LastName).Replace("  ", " ").Trim()
                : person.FullName;
            lblGender.Text = person.GenderText;
            lblEmail.Text = string.IsNullOrEmpty(person.Email) ? "N/A" : person.Email;
            lblPhone.Text = person.Phone;
            lblAddress.Text = person.Address;
            lblDateOfBirth.Text = person.DateOfBirth.ToShortDateString();

            if (!string.IsNullOrWhiteSpace(countryName))
                lblCountry.Text = countryName;

            LoadPersonImage();
        }

        private async Task LoadCountryNameAsync(int countryId)
        {
            System.Collections.Generic.IEnumerable<CountryDto> countries = await _personService.GetAllCountriesAsync();
            CountryDto country = countries != null
                ? countries.FirstOrDefault(c => c.CountryID == countryId)
                : null;

            lblCountry.Text = country != null ? country.CountryName : "N/A";
        }

        private void LoadPersonImage()
        {
            if (_personDto == null)
                return;

            if (!string.IsNullOrEmpty(_personDto.ImagePath) && File.Exists(_personDto.ImagePath))
            {
                pbPersonPicture.ImageLocation = _personDto.ImagePath;
                return;
            }

            pbPersonPicture.ImageLocation = null;
            pbPersonPicture.Image = _personDto.GenderText == "Male"
                ? Properties.Resources.icons8_person_100_1
                : Properties.Resources.icons8_person_100;
        }

        private void lnklblEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnEditClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
