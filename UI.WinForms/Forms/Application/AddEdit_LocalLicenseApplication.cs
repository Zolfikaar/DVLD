using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.Forms.Application
{
    public partial class AddEdit_LocalLicenseApplication : Form
    {
        public enum Mode { AddNew = 0, Update = 1 }
        private Mode _mode;

        private readonly PersonService _personService;
        private readonly LocalLicenseService _localLicenseService;
        private int _localLicenseAppId;
        private LocalLicenseDto _applicationDto;
        private List<CountryDto> _countries = new List<CountryDto>();
        private int _selectedPersonId = -1;

        public AddEdit_LocalLicenseApplication(LocalLicenseService localLicenseService, int localLicenseAppId, PersonService personService)
        {
            InitializeComponent();
            _localLicenseService = localLicenseService;
            _localLicenseAppId = localLicenseAppId;
            _mode = (_localLicenseAppId == -1) ? Mode.AddNew : Mode.Update;
            _personService = personService;
        }

        private async void AddEdit_LocalLicenseApplication_Load(object sender, EventArgs e)
        {
            _resetDefualtValues();

            _countries = (await _personService.GetAllCountriesAsync()).ToList();

            if (_mode == Mode.Update)
            {
                await _loadApplicationDataAsync();
            }
        }

        private void _resetDefualtValues()
        {
            _loadFilterOptionsToComboBox();
            _loadLicenseClassesToComboBox();
            _resetPersonInfo();

            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblApplicationFees.Text = "15";
            lblCreatedBy.Text = CurrentUserSession.IsLoggedIn ? CurrentUserSession.CurrentUser.Username : "Unknown";

            if (_mode == Mode.AddNew)
            {
                lblTitle.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _applicationDto = new LocalLicenseDto();

                lblLocalLicenseAppID.Text = "N/A";
                btnSave.Enabled = false;
                btnNext.Enabled = false;
                tpApplicationInfo.Enabled = false;
            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";
                btnSave.Enabled = true;
                btnNext.Enabled = true;
                tpApplicationInfo.Enabled = true;
            }
        }

        private void _loadFilterOptionsToComboBox()
        {
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.Add("National No");
            cbFilterBy.Items.Add("Person ID");
            cbFilterBy.SelectedIndex = 0;
        }

        private void _loadLicenseClassesToComboBox()
        {
            cbLicenseClasses.Items.Clear();
            cbLicenseClasses.Items.Add("Class 1 - Small Motorcycle");
            cbLicenseClasses.Items.Add("Class 2 - Heavy Motorcycle License");
            cbLicenseClasses.Items.Add("Class 3 - Ordinary driving license");
            cbLicenseClasses.Items.Add("Class 4 - Commercial");
            cbLicenseClasses.Items.Add("Class 5 - Agricultural");
            cbLicenseClasses.SelectedIndex = 2;
        }

        private async Task _loadApplicationDataAsync()
        {
            _applicationDto = await _localLicenseService.GetLocalLicenseByIdAsync(_localLicenseAppId);

            if (_applicationDto == null)
            {
                MessageBox.Show("No Application with ID = " + _localLicenseAppId, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
                return;
            }

            lblLocalLicenseAppID.Text = _applicationDto.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = _applicationDto.ApplicationDate.ToString("dd/MM/yyyy");
            lblApplicationFees.Text = _applicationDto.PaidFees.ToString("0.##");
            lblCreatedBy.Text = _applicationDto.CreatedByUserName;
            if (_applicationDto.LicenseClassID >= 1 && _applicationDto.LicenseClassID <= cbLicenseClasses.Items.Count)
                cbLicenseClasses.SelectedIndex = _applicationDto.LicenseClassID - 1;

            await _loadPersonByIdAsync(_applicationDto.ApplicantPersonID);
        }

        private async Task _loadPersonByIdAsync(int personId)
        {
            PersonDto person = await _personService.GetPersonByPersonIdAsync(personId);

            if (person == null)
            {
                MessageBox.Show("No Person Found with ID = " + personId, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _resetPersonInfo();
                return;
            }

            _selectPerson(person);
        }

        private async Task _loadPersonByNationalNoAsync(string nationalNo)
        {
            PersonDto person = null;

            try
            {
                person = await _personService.GetPersonByNationalNoAsync(nationalNo);
            }
            catch (InvalidOperationException)
            {
                person = null;
            }

            if (person == null)
            {
                MessageBox.Show("No Person Found with National No = " + nationalNo, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _resetPersonInfo();
                return;
            }

            _selectPerson(person);
        }

        private void _selectPerson(PersonDto person)
        {
            _selectedPersonId = person.PersonID;

            lblPersonID.Text = person.PersonID.ToString();
            lblFullName.Text = person.FullName;
            lblNationalNo.Text = person.NationalNo;
            lblGendor.Text = person.GenderText;
            lblEmail.Text = person.Email;
            lblAddress.Text = person.Address;
            lblDateOfBirth.Text = person.DateOfBirth.ToString("dd/MM/yyyy");
            lblPhone.Text = person.Phone;

            CountryDto country = _countries.FirstOrDefault(c => c.CountryID == person.NationalityCountryID);
            lblCountry.Text = country == null ? string.Empty : country.CountryName;

            llEditPersonInfo.Enabled = true;
            btnNext.Enabled = true;
            btnSave.Enabled = true;
            tpApplicationInfo.Enabled = true;
        }

        private void _resetPersonInfo()
        {
            _selectedPersonId = -1;

            lblPersonID.Text = "[?????]";
            lblFullName.Text = "[?????]";
            lblNationalNo.Text = "[?????]";
            lblGendor.Text = "[?????]";
            lblEmail.Text = "[?????]";
            lblAddress.Text = "[?????]";
            lblDateOfBirth.Text = "[?????]";
            lblPhone.Text = "[?????]";
            lblCountry.Text = "[?????]";

            llEditPersonInfo.Enabled = false;

            if (_mode == Mode.AddNew)
            {
                btnNext.Enabled = false;
                btnSave.Enabled = false;
                tpApplicationInfo.Enabled = false;
            }
        }

        private async void btnFindPerson_Click(object sender, EventArgs e)
        {
            string filterValue = txtFilterValue.Text.Trim();

            if (string.IsNullOrEmpty(filterValue))
            {
                MessageBox.Show("Please enter a search value!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbFilterBy.SelectedItem.ToString() == "Person ID")
            {
                int personId;
                if (!int.TryParse(filterValue, out personId))
                {
                    MessageBox.Show("Person ID must be a number!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await _loadPersonByIdAsync(personId);
            }
            else
            {
                await _loadPersonByNationalNoAsync(filterValue);
            }
        }

        private async void btnAddPerson_Click(object sender, EventArgs e)
        {
            var frm = new UI.WinForms.Forms.Person.AddEditForm(_personService, -1);
            frm.ShowDialog();

            if (frm.SavedPersonId > 0)
            {
                await _loadPersonByIdAsync(frm.SavedPersonId);
            }
        }

        private async void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_selectedPersonId == -1)
            {
                MessageBox.Show("Please select a person first!", "No Person Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frm = new UI.WinForms.Forms.Person.AddEditForm(_personService, _selectedPersonId);
            frm.ShowDialog();

            await _loadPersonByIdAsync(_selectedPersonId);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_selectedPersonId == -1)
            {
                MessageBox.Show("Please Select a Person First!", "Select Person", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tcApplicationInfo.SelectedTab = tpApplicationInfo;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedPersonId == -1)
            {
                MessageBox.Show("Please Select a Person First!", "Select Person", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbLicenseClasses.SelectedItem == null)
            {
                MessageBox.Show("Please Select a License Class!", "Select License Class", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedClass = cbLicenseClasses.SelectedItem.ToString();
            int licenseClassId = cbLicenseClasses.SelectedIndex + 1;

            try
            {
                int excludedAppId = _mode == Mode.Update ? _localLicenseAppId : -1;
                if (await _localLicenseService.HasActiveApplicationAsync(_selectedPersonId, licenseClassId, excludedAppId))
                {
                    MessageBox.Show("Choose another License Class, the selected Person already has an active application for the selected class!",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_mode == Mode.Update)
                {
                    if (await _localLicenseService.UpdateLocalLicenseAsync(_localLicenseAppId, licenseClassId))
                    {
                        _applicationDto.LicenseClassID = licenseClassId;
                        _applicationDto.ClassName = selectedClass;
                        MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error: Data was not saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return;
                }

                _applicationDto.ApplicantPersonID = _selectedPersonId;
                _applicationDto.LicenseClassID = licenseClassId;
                _applicationDto.CreatedByUserID = CurrentUserSession.CurrentUserId;
                _applicationDto.ClassName = selectedClass;
                _applicationDto.NationalNo = lblNationalNo.Text;
                _applicationDto.FullName = lblFullName.Text;
                _applicationDto.ApplicationDate = DateTime.Now;
                _applicationDto.Status = "New";

                int newAppId = await _localLicenseService.AddLocalLicenseAsync(_applicationDto);

                if (newAppId < 1)
                {
                    MessageBox.Show("Error: Data was not saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _localLicenseAppId = newAppId;
                _applicationDto.LocalDrivingLicenseApplicationID = newAppId;
                _mode = Mode.Update;

                lblLocalLicenseAppID.Text = newAppId.ToString();
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving the application: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
