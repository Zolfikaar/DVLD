using System;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;
using UI.WinForms.Forms.Person;

namespace UI.WinForms.Forms.User
{
    public partial class AddEditUserForm : Form
    {
        private readonly UserService _userService;
        private readonly PersonService _personService;
        private readonly int _userId;
        private readonly bool _isEditMode;
        private int _selectedPersonId = -1;
        private string _existingPasswordHash = string.Empty;

        public AddEditUserForm(UserService userService, PersonService personService, int userId = -1)
        {
            InitializeComponent();
            _userService = userService;
            _personService = personService;
            _userId = userId;
            _isEditMode = userId > 0;
        }

        private async void AddEditUserForm_Load(object sender, EventArgs e)
        {
            cbFindBy.Items.Clear();
            cbFindBy.Items.Add("Person ID");
            cbFindBy.Items.Add("National No");
            cbFindBy.SelectedIndex = 0;
            ctrlPersonCard1.ShowEditLink = false;

            if (_isEditMode)
            {
                Text = "Edit User";
                gbFindPerson.Enabled = false;
                txtPassword.Enabled = false;
                txtConfirmPassword.Enabled = false;
                lblPasswordHint.Visible = true;
                await LoadUserAsync();
            }
            else
            {
                Text = "Add New User";
                lblUserIdValue.Text = "N/A";
                chkIsActive.Checked = true;
                lblPasswordHint.Visible = false;
            }
        }

        private async System.Threading.Tasks.Task LoadUserAsync()
        {
            UserDto user = await _userService.GetUserByIdAsync(_userId);
            if (user == null)
            {
                MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            _selectedPersonId = user.PersonId;
            _existingPasswordHash = user.PasswordHash ?? string.Empty;
            lblUserIdValue.Text = user.Id.ToString();
            txtUsername.Text = user.Username;
            chkIsActive.Checked = user.IsActive;
            await ctrlPersonCard1.LoadPersonAsync(_personService, user.PersonId);
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            string searchValue = txtFindValue.Text != null ? txtFindValue.Text.Trim() : string.Empty;
            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please enter a search value.", "Find Person", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PersonDto person = null;
            try
            {
                if (cbFindBy.SelectedItem != null && cbFindBy.SelectedItem.ToString() == "Person ID")
                {
                    int personId;
                    if (!int.TryParse(searchValue, out personId))
                    {
                        MessageBox.Show("Person ID must be a number.", "Find Person", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    person = await _personService.GetPersonByPersonIdAsync(personId);
                }
                else
                {
                    person = await _personService.GetPersonByNationalNoAsync(searchValue);
                }
            }
            catch (Exception)
            {
                person = null;
            }

            if (person == null)
            {
                MessageBox.Show("Person not found.", "Find Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserDto existingUser = await _userService.GetUserByPersonIdAsync(person.PersonID);
            if (existingUser != null && (!_isEditMode || existingUser.Id != _userId))
            {
                MessageBox.Show("This person already has a user account.", "Find Person", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _selectedPersonId = person.PersonID;
            await ctrlPersonCard1.LoadPersonAsync(_personService, person.PersonID);
        }

        private async void btnAddPerson_Click(object sender, EventArgs e)
        {
            AddEditForm frm = new AddEditForm(_personService);
            frm.ShowDialog();

            if (frm.SavedPersonId <= 0)
                return;

            UserDto existingUser = await _userService.GetUserByPersonIdAsync(frm.SavedPersonId);
            if (existingUser != null)
            {
                MessageBox.Show("This person already has a user account.", "Add Person", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _selectedPersonId = frm.SavedPersonId;
            await ctrlPersonCard1.LoadPersonAsync(_personService, frm.SavedPersonId);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedPersonId <= 0)
            {
                MessageBox.Show("Please select a person first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = txtUsername.Text != null ? txtUsername.Text.Trim() : string.Empty;
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string password = txtPassword.Text ?? string.Empty;
            string confirmPassword = txtConfirmPassword.Text ?? string.Empty;

            if (!_isEditMode)
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.Equals(password, confirmPassword, StringComparison.Ordinal))
                {
                    MessageBox.Show("Password and confirmation do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            UserDto userDto = new UserDto
            {
                Id = _isEditMode ? _userId : 0,
                PersonId = _selectedPersonId,
                Username = username,
                PasswordHash = _isEditMode ? _existingPasswordHash : password,
                IsActive = chkIsActive.Checked
            };

            try
            {
                if (_isEditMode)
                {
                    bool updated = await _userService.UpdateUserAsync(userDto);
                    if (updated)
                    {
                        MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
                else
                {
                    int newUserId = await _userService.CreateUserAsync(userDto);
                    if (newUserId > 0)
                    {
                        MessageBox.Show("User saved successfully with ID: " + newUserId, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
