using System;
using System.Windows.Forms;
using Application.Services;
using UI.WinForms.Forms;
using UI.WinForms.Forms.Application;
using UI.WinForms.Forms.License;
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
        private readonly TestAppointmentService _testAppointmentService;
        private readonly LicenseService _licenseService;

        public bool IsLogout { get; private set; }

        public MainForm(PersonService personService, UserService userService, ApplicationTypeService applicationTypeService, TestTypeService testTypeService, LocalLicenseService localLicenseService,
            TestAppointmentService testAppointmentService, LicenseService licenseService)
        {
            InitializeComponent();
            _testAppointmentService = testAppointmentService;
            _licenseService = licenseService;
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
            ManageApplications_LocalLicense frm = _createLocalLicenseApplicationsForm();
            frm.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageApplications_InternationalLicense frm = new ManageApplications_InternationalLicense(_licenseService, _personService, _applicationTypeService);
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddEdit_LocalLicenseApplication(_localLicenseService, -1, _personService).ShowDialog();
        }

        private ManageApplications_LocalLicense _createLocalLicenseApplicationsForm()
        {
            return new ManageApplications_LocalLicense(_localLicenseService, _personService, _testAppointmentService,
                _testTypeService, _applicationTypeService, _licenseService);
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new IssueInternationalLicense(_licenseService, _personService, _applicationTypeService).ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RenewLicense(_licenseService, _personService, _applicationTypeService).ShowDialog();
        }

        private void replacmentForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ReplaceLicense(_licenseService, _personService, _applicationTypeService).ShowDialog();
        }

        private void manageDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ManageDetainedLicenses(_licenseService, _personService, _applicationTypeService).ShowDialog();
        }

        private void detainLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new DetainLicense(_licenseService, _personService).ShowDialog();
        }

        private void releaseDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ReleaseDetainedLicense(_licenseService, _personService, _applicationTypeService).ShowDialog();
        }
    }
}
