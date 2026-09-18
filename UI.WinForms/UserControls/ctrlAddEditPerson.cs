using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.DTOs;
using Application.DTOs.Person;
using Application.Services;

namespace UI.WinForms.UserControls
{
    public partial class ctrlAddEditPerson : UserControl
    {
        private PersonService _personService;
        private int _personId = -1;
        private bool _isEditMode;
        private string _selectedImagePath = string.Empty;
        private string _existingImagePath = string.Empty;
        private bool _removeImage;

        public event EventHandler Saved;
        public event EventHandler ModeChanged;

        public bool IsEditMode
        {
            get { return _isEditMode; }
        }

        public int PersonId
        {
            get { return _personId; }
        }

        public ctrlAddEditPerson()
        {
            InitializeComponent();
        }

        public async Task InitializeAsync(PersonService personService, int personId = -1)
        {
            if (personService == null)
                throw new ArgumentNullException(nameof(personService));

            _personService = personService;
            _personId = personId;
            _isEditMode = personId > 0;
            _selectedImagePath = string.Empty;
            _existingImagePath = string.Empty;
            _removeImage = false;

            await LoadCountriesAsync();

            if (_isEditMode)
                await LoadPersonDataAsync();
            else
                ResetForm();

            ModeChanged?.Invoke(this, EventArgs.Empty);
        }

        public PersonDto GetPersonDto()
        {
            return new PersonDto
            {
                PersonID = _personId > 0 ? _personId : 0,
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
                NationalityCountryID = GetSelectedCountryId(),
                ImagePath = ResolveImagePathToSave()
            };
        }

        private async Task LoadPersonDataAsync()
        {
            try
            {
                PersonDto person = await _personService.GetPersonByPersonIdAsync(_personId);
                if (person == null)
                {
                    MessageBox.Show("Person not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FindForm()?.Close();
                    return;
                }

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

                rbMale.Checked = person.GenderText == "Male";
                rbFemale.Checked = person.GenderText == "Female";

                if (person.NationalityCountryID > 0)
                    cbCountry.SelectedValue = person.NationalityCountryID;

                _existingImagePath = person.ImagePath ?? string.Empty;
                ApplyPersonImage(_existingImagePath, person.GenderText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading person data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadCountriesAsync()
        {
            System.Collections.Generic.IEnumerable<CountryDto> countries = await _personService.GetAllCountriesAsync();
            System.Collections.Generic.List<CountryDto> countriesList = countries != null
                ? countries.ToList()
                : new System.Collections.Generic.List<CountryDto>();

            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
            cbCountry.DataSource = null;
            cbCountry.DataSource = countriesList;
        }

        private void ResetForm()
        {
            lblPersonID.Text = "N/A";
            tbNationalNumber.Clear();
            tbFirstname.Clear();
            tbSecondname.Clear();
            tbThirdname.Clear();
            tbLastname.Clear();
            tbEmail.Clear();
            tbPhone.Clear();
            tbAddress.Clear();

            DateTime maxAdultDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.MaxDate = DateTime.Now;
            dtpDateOfBirth.MinDate = new DateTime(1900, 1, 1);
            dtpDateOfBirth.Value = maxAdultDate;

            rbMale.Checked = true;
            rbFemale.Checked = false;

            if (cbCountry.Items.Count > 0)
                cbCountry.SelectedIndex = 0;

            _selectedImagePath = string.Empty;
            _existingImagePath = string.Empty;
            _removeImage = false;
            ApplyDefaultImage(true);
            errorProvider1.Clear();
        }

        private void ApplyPersonImage(string imagePath, string genderText)
        {
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                SetPhoto(Image.FromFile(imagePath));
                btnClearImage.Visible = true;
                return;
            }

            ApplyDefaultImage(genderText != "Female");
        }

        private void ApplyDefaultImage(bool isMale)
        {
            SetPhoto(isMale
                ? Properties.Resources.icons8_person_100_1
                : Properties.Resources.icons8_person_100);
            btnClearImage.Visible = false;
        }

        private void SetPhoto(Image image)
        {
            pbPersonPhoto.BackgroundImage = image;
        }

        private async Task<bool> ValidateInputsAsync()
        {
            if (string.IsNullOrWhiteSpace(tbNationalNumber.Text) ||
                string.IsNullOrWhiteSpace(tbFirstname.Text) ||
                string.IsNullOrWhiteSpace(tbSecondname.Text) ||
                string.IsNullOrWhiteSpace(tbLastname.Text) ||
                string.IsNullOrWhiteSpace(tbPhone.Text) ||
                string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                MessageBox.Show("Please fill all required fields!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(tbEmail.Text) && !IsValidEmail(tbEmail.Text.Trim()))
            {
                MessageBox.Show("Invalid Email format!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_isEditMode)
            {
                bool isNationalNoExists = await _personService.IsPersonExists(tbNationalNumber.Text.Trim());
                if (isNationalNoExists)
                {
                    MessageBox.Show("This National Number is already assigned to another person!",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                MailAddress addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private int GetSelectedCountryId()
        {
            if (cbCountry.SelectedValue == null)
                return 0;

            if (cbCountry.SelectedValue is int)
                return (int)cbCountry.SelectedValue;

            int parsedId;
            if (int.TryParse(cbCountry.SelectedValue.ToString(), out parsedId))
                return parsedId;

            return 0;
        }

        private string ResolveImagePathToSave()
        {
            if (_removeImage)
                return string.Empty;

            if (string.IsNullOrEmpty(_selectedImagePath))
                return _existingImagePath ?? string.Empty;

            try
            {
                string imagesFolder = Path.Combine(System.Windows.Forms.Application.StartupPath, "People_Photos");
                if (!Directory.Exists(imagesFolder))
                    Directory.CreateDirectory(imagesFolder);

                string fileExtension = Path.GetExtension(_selectedImagePath);
                string newFileName = Guid.NewGuid().ToString() + fileExtension;
                string destinationPath = Path.Combine(imagesFolder, newFileName);
                File.Copy(_selectedImagePath, destinationPath, true);
                return destinationPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the image: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return _existingImagePath ?? string.Empty;
            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                _selectedImagePath = ofd.FileName;
                _removeImage = false;
                SetPhoto(Image.FromFile(_selectedImagePath));
                btnClearImage.Visible = true;
            }
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            _selectedImagePath = string.Empty;
            _existingImagePath = string.Empty;
            _removeImage = true;
            ApplyDefaultImage(rbMale.Checked);
        }

        private async void btnSaveRecord_Click(object sender, EventArgs e)
        {
            if (_personService == null)
                return;

            bool isValidInputs = await ValidateInputsAsync();
            if (!isValidInputs)
                return;

            PersonDto personDto = GetPersonDto();

            try
            {
                if (_isEditMode)
                {
                    bool updatedPerson = await _personService.UpdatePersonAsync(personDto, _personId);
                    if (updatedPerson)
                    {
                        _existingImagePath = personDto.ImagePath;
                        _selectedImagePath = string.Empty;
                        MessageBox.Show("Person Updated Successfully", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Saved?.Invoke(this, EventArgs.Empty);
                        FindForm()?.Close();
                    }
                }
                else
                {
                    int newPersonId = await _personService.AddPersonAsync(personDto);
                    if (newPersonId > 0)
                    {
                        _personId = newPersonId;
                        _isEditMode = true;
                        lblPersonID.Text = _personId.ToString();
                        _existingImagePath = personDto.ImagePath;
                        _selectedImagePath = string.Empty;
                        MessageBox.Show("Person Saved Successfully with ID: " + newPersonId, "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ModeChanged?.Invoke(this, EventArgs.Empty);
                        Saved?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
