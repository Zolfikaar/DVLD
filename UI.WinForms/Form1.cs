using System;
using System.Windows.Forms;
using Application.Services;
using UI.WinForms.Forms;

namespace UI.WinForms
{
    public partial class Form1 : Form
    {
        private PersonService _personService;
        public Form1(PersonService personService)
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
