using System;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.Forms.User
{
    public partial class ChangePasswordForm : Form
    {
        private readonly UserService _userService;
        private readonly int _userId;
        private readonly bool _requireCurrentPassword;

        public ChangePasswordForm(UserService userService, int userId, bool requireCurrentPassword)
        {
            InitializeComponent();
            _userService = userService;
            _userId = userId;
            _requireCurrentPassword = requireCurrentPassword;
        }

        private async void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            lblCurrentPassword.Visible = _requireCurrentPassword;
            txtCurrentPassword.Visible = _requireCurrentPassword;

            UserDto user = await _userService.GetUserByIdAsync(_userId);
            if (user == null)
            {
                MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            lblUsernameValue.Text = user.Username;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text ?? string.Empty;
            string newPassword = txtNewPassword.Text ?? string.Empty;
            string confirmPassword = txtConfirmPassword.Text ?? string.Empty;

            if (_requireCurrentPassword && string.IsNullOrWhiteSpace(currentPassword))
            {
                MessageBox.Show("Current password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("New password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.Equals(newPassword, confirmPassword, StringComparison.Ordinal))
            {
                MessageBox.Show("New password and confirmation do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool changed = await _userService.ChangePasswordAsync(
                    _userId,
                    newPassword,
                    _requireCurrentPassword ? currentPassword : null);

                if (!changed)
                {
                    MessageBox.Show(_requireCurrentPassword
                        ? "Current password is incorrect."
                        : "Password could not be changed.",
                        "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
