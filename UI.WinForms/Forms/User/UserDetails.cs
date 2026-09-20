using System;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;
using UI.WinForms.Forms.Person;

namespace UI.WinForms.Forms.User
{
    public partial class UserDetailsForm : Form
    {
        private readonly UserService _userService;
        private readonly PersonService _personService;
        private readonly int _userId;

        public UserDetailsForm(UserService userService, PersonService personService, int userId)
        {
            InitializeComponent();
            _userService = userService;
            _personService = personService;
            _userId = userId;
        }

        private async void UserDetailsForm_Shown(object sender, EventArgs e)
        {
            await LoadUserAsync();
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

            lblUserIdValue.Text = user.Id.ToString();
            lblUsernameValue.Text = user.Username;
            lblIsActiveValue.Text = user.IsActive ? "Yes" : "No";
            await ctrlPersonCard1.LoadPersonAsync(_personService, user.PersonId);
        }

        private async void ctrlPersonCard1_OnEditClicked(object sender, EventArgs e)
        {
            AddEditForm frm = new AddEditForm(_personService, ctrlPersonCard1.PersonId);
            frm.ShowDialog();
            await ctrlPersonCard1.RefreshDataAsync();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
