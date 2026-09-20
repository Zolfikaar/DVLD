using System;
using System.Windows.Forms;
using Application.Services;
using UI.WinForms.UserControls;

namespace UI.WinForms.Forms.Person
{
    public partial class AddEditForm : Form
    {
        private readonly PersonService _personService;
        private readonly int _personId;

        public int SavedPersonId
        {
            get { return ctrlAddEditPerson1.PersonId; }
        }

        public AddEditForm(PersonService personService, int personId = -1)
        {
            InitializeComponent();
            _personService = personService;
            _personId = personId;
        }

        private async void AddEdit_Load(object sender, EventArgs e)
        {
            ctrlAddEditPerson1.ModeChanged += ctrlAddEditPerson1_ModeChanged;
            await ctrlAddEditPerson1.InitializeAsync(_personService, _personId);
            UpdateTitle();
        }

        private void ctrlAddEditPerson1_ModeChanged(object sender, EventArgs e)
        {
            UpdateTitle();
        }

        private void UpdateTitle()
        {
            Text = ctrlAddEditPerson1.IsEditMode ? "Edit Person" : "Add New Person";
        }
    }
}
