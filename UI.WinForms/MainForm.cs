using System;
using System.Windows.Forms;
using Application.Services;
using UI.WinForms.Forms;
using UI.WinForms.Forms.Application;
using UI.WinForms.Forms.User;
using UI.WinForms.Forms.Test;

namespace UI.WinForms
{
    public partial class MainForm : Form
    {
        private readonly PersonService _personService;
        private readonly UserService _userService;
        private readonly ApplicationTypeService _applicationTypeService;
        private readonly TestTypeService _testTypeService;
        private readonly LocalLicenseService _localLicenseService;

        public bool IsLogout { get; private set; }

        public MainForm(PersonService personService, UserService userService, ApplicationTypeService applicationTypeService, TestTypeService testTypeService, LocalLicenseService localLicenseService)
        {
            InitializeComponent();
            _localLicenseService = localLicenseService;
            _personService = personService;
            _userService = userService;
            _applicationTypeService = applicationTypeService;
            _testTypeService = testTypeService;
            IsLogout = false;
        }

        private void manageApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void drivingLicenseServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagePeople frm = new ManagePeople(_personService);
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUsers frm = new ManageUsers(_userService, _personService);
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentUserSession.CurrentUser == null)
                return;

            UserDetailsForm frm = new UserDetailsForm(_userService, _personService, CurrentUserSession.CurrentUser.Id);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentUserSession.CurrentUser == null)
                return;

            ChangePasswordForm frm = new ChangePasswordForm(_userService, CurrentUserSession.CurrentUser.Id, true);
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to sign out?",
                "Sign Out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            IsLogout = true;
            CurrentUserSession.SignOut();
            Close();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageApplicationTypes frm = new ManageApplicationTypes(_applicationTypeService);
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageTestTypes frm = new ManageTestTypes(_testTypeService);
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageApplications_LocalLicense frm = new ManageApplications_LocalLicense(_localLicenseService, _personService);
            frm.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageApplications_InternationalLicense frm = new ManageApplications_InternationalLicense();
            frm.ShowDialog();
        }
    }
}
