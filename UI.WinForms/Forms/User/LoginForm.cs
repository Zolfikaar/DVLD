using System;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.Forms.User
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;

        public UserDto LoggedInUser { get; private set; }

        public LoginForm(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text != null ? txtUsername.Text.Trim() : string.Empty;
            string password = txtPassword.Text ?? string.Empty;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter username and password.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLogin.Enabled = false;
            try
            {
                UserDto user = await _userService.GetUserByUsernameAsync(username);
                if (user == null || !string.Equals(user.PasswordHash, password, StringComparison.Ordinal))
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!user.IsActive)
                {
                    MessageBox.Show("Your account is inactive. Contact the administrator.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoggedInUser = user;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }
    }
}
