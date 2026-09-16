using System;
using System.Windows.Forms;
using Application.Services;
using UI.WinForms.Forms;

namespace UI.WinForms
{
    public partial class MainForm : Form
    {
        private PersonService _personService;
        public MainForm(PersonService personService)
        {
            InitializeComponent();
            _personService = personService;
        }

        private void manageApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void drivingLicenseServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new ManagePeople(_personService);
            frm.ShowDialog();
        }
    }
}
