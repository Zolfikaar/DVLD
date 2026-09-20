using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;
using UI.WinForms.UserControls;

namespace UI.WinForms.Forms.User
{
    public partial class ManageUsers : Form
    {
        private readonly UserService _userService;
        private readonly PersonService _personService;
        private readonly ctrlDataGridManager<UserDto> _usersGridManager;

        public ManageUsers(UserService userService, PersonService personService)
        {
            InitializeComponent();
            _userService = userService;
            _personService = personService;

            _usersGridManager = new ctrlDataGridManager<UserDto>
            {
                Dock = DockStyle.Fill,
                RightToLeft = RightToLeft.Inherit,
                Name = "ctrlUsersManager"
            };

            _usersGridManager.OnAddNewClicked += usersGridManager_OnAddNewClicked;
            _usersGridManager.OnEditClicked += usersGridManager_OnEditClicked;
            _usersGridManager.OnDeleteClicked += usersGridManager_OnDeleteClicked;

            Controls.Add(_usersGridManager);
            _usersGridManager.SendToBack();
        }

        private async void ManageUsers_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> columnHeaders = new Dictionary<string, string>
            {
                { "Id", "User ID" },
                { "PersonId", "Person ID" },
                { "FullName", "Full Name" },
                { "Username", "User Name" },
                { "IsActiveText", "Is Active" }
            };

            Dictionary<string, Func<UserDto, string, bool>> filterConditions =
                new Dictionary<string, Func<UserDto, string, bool>>
                {
                    { "User ID", (user, value) => user.Id.ToString().StartsWith(value) },
                    { "Person ID", (user, value) => user.PersonId.ToString().StartsWith(value) },
                    {
                        "Full Name",
                        (user, value) => !string.IsNullOrEmpty(user.FullName) &&
                                         user.FullName.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0
                    },
                    {
                        "User Name",
                        (user, value) => !string.IsNullOrEmpty(user.Username) &&
                                         user.Username.StartsWith(value, StringComparison.OrdinalIgnoreCase)
                    },
                    {
                        "Is Active",
                        (user, value) => !string.IsNullOrEmpty(user.IsActiveText) &&
                                         user.IsActiveText.StartsWith(value, StringComparison.OrdinalIgnoreCase)
                    }
                };

            await _usersGridManager.InitializeManagerAsync(
                "Manage Users",
                () => _userService.GetUsersAsync(),
                columnHeaders,
                filterConditions,
                cmsUsers,
                user => user.Id);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void usersGridManager_OnAddNewClicked(object sender, EventArgs e)
        {
            AddEditUserForm frm = new AddEditUserForm(_userService, _personService);
            frm.ShowDialog();
            await _usersGridManager.RefreshDataAsync();
        }

        private async void usersGridManager_OnEditClicked(object sender, EventArgs e)
        {
            UserDto selectedUser = _usersGridManager.GetSelectedEntity();
            if (selectedUser == null)
                return;

            AddEditUserForm frm = new AddEditUserForm(_userService, _personService, selectedUser.Id);
            frm.ShowDialog();
            await _usersGridManager.RefreshDataAsync();
        }

        private async void usersGridManager_OnDeleteClicked(object sender, EventArgs e)
        {
            UserDto selectedUser = _usersGridManager.GetSelectedEntity();
            if (selectedUser == null)
                return;

            if (CurrentUserSession.CurrentUser != null && CurrentUserSession.CurrentUser.Id == selectedUser.Id)
            {
                MessageBox.Show("You cannot delete the currently logged-in user.", "Delete Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this user?",
                "Confirm Delete",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result != DialogResult.OK)
                return;

            try
            {
                bool isDeleted = await _userService.DeleteUserAsync(selectedUser.Id);
                if (isDeleted)
                {
                    MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _usersGridManager.RefreshDataAsync();
                }
                else
                {
                    MessageBox.Show("User could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Microsoft.Data.SqlClient.SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show(
                    "Cannot delete this user because they have related data linked in the system.",
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDto selectedUser = _usersGridManager.GetSelectedEntity();
            if (selectedUser == null)
                return;

            UserDetailsForm frm = new UserDetailsForm(_userService, _personService, selectedUser.Id);
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usersGridManager_OnEditClicked(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usersGridManager_OnDeleteClicked(sender, e);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDto selectedUser = _usersGridManager.GetSelectedEntity();
            if (selectedUser == null)
                return;

            ChangePasswordForm frm = new ChangePasswordForm(_userService, selectedUser.Id, false);
            frm.ShowDialog();
        }
    }
}
