using System;
using System.Windows.Forms;
using Application.Services;
using UI.WinForms.UserControls;

namespace UI.WinForms.Forms.Person
{
    public partial class PersonDetails : Form
    {
        private readonly PersonService _personService;
        private readonly int _personId;

        public PersonDetails(PersonService personService, int personId)
        {
            InitializeComponent();
            _personService = personService;
            _personId = personId;
        }

        private async void PersonDetailsForm_Shown(object sender, EventArgs e)
        {
            await ctrlPersonCard1.LoadPersonAsync(_personService, _personId);
        }

        private async void ctrlPersonCard1_OnEditClicked(object sender, EventArgs e)
        {
            AddEditForm frm = new AddEditForm(_personService, ctrlPersonCard1.PersonId);
            frm.ShowDialog();
            await ctrlPersonCard1.RefreshDataAsync();
        }
    }
}
