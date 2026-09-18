using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Application.DTOs.Person;
using Application.Services;
using UI.WinForms.Forms.Person;
using UI.WinForms.UserControls;

namespace UI.WinForms.Forms
{
    public partial class ManagePeople : Form
    {
        private readonly PersonService _personService;
        private readonly ctrlDataGridManager<PersonDto> _peopleGridManager;

        public ManagePeople(PersonService personService)
        {
            InitializeComponent();
            _personService = personService;

            _peopleGridManager = new ctrlDataGridManager<PersonDto>
            {
                Dock = DockStyle.Fill,
                RightToLeft = RightToLeft.Inherit,
                Name = "ctrlPeopleManager"
            };

            _peopleGridManager.OnAddNewClicked += peopleGridManager_OnAddNewClicked;
            _peopleGridManager.OnEditClicked += peopleGridManager_OnEditClicked;
            _peopleGridManager.OnDeleteClicked += peopleGridManager_OnDeleteClicked;

            Controls.Add(_peopleGridManager);
            _peopleGridManager.SendToBack();
        }

        private async void ManagePeople_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> columnHeaders = new Dictionary<string, string>
            {
                { "PersonID", "Person ID" },
                { "NationalNo", "National No" },
                { "FullName", "Full Name" },
                { "GenderText", "Gender" },
                { "DateOfBirth", "Date Of Birth" },
                { "Phone", "Phone" },
                { "Email", "Email" },
                { "Address", "Address" }
            };

            Dictionary<string, Func<PersonDto, string, bool>> filterConditions =
                new Dictionary<string, Func<PersonDto, string, bool>>
                {
                    {
                        "Person ID",
                        (person, value) => person.PersonID.ToString().StartsWith(value)
                    },
                    {
                        "National No",
                        (person, value) => !string.IsNullOrEmpty(person.NationalNo) &&
                                           person.NationalNo.StartsWith(value, StringComparison.OrdinalIgnoreCase)
                    },
                    {
                        "First Name",
                        (person, value) => !string.IsNullOrEmpty(person.FirstName) &&
                                           person.FirstName.StartsWith(value, StringComparison.OrdinalIgnoreCase)
                    },
                    {
                        "Phone",
                        (person, value) => !string.IsNullOrEmpty(person.Phone) &&
                                           person.Phone.Contains(value)
                    },
                    {
                        "Email",
                        (person, value) => !string.IsNullOrEmpty(person.Email) &&
                                           person.Email.StartsWith(value, StringComparison.OrdinalIgnoreCase)
                    }
                };

            await _peopleGridManager.InitializeManagerAsync(
                "Manage People",
                () => _personService.GetAllPeopleAsync(),
                columnHeaders,
                filterConditions,
                cmsPeople,
                person => person.PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void peopleGridManager_OnAddNewClicked(object sender, EventArgs e)
        {
            AddEditForm frm = new AddEditForm(_personService);
            frm.ShowDialog();
            await _peopleGridManager.RefreshDataAsync();
        }

        private async void peopleGridManager_OnEditClicked(object sender, EventArgs e)
        {
            PersonDto selectedPerson = _peopleGridManager.GetSelectedEntity();
            if (selectedPerson == null)
                return;

            AddEditForm frm = new AddEditForm(_personService, selectedPerson.PersonID);
            frm.ShowDialog();
            await _peopleGridManager.RefreshDataAsync();
        }

        private async void peopleGridManager_OnDeleteClicked(object sender, EventArgs e)
        {
            PersonDto selectedPerson = _peopleGridManager.GetSelectedEntity();
            if (selectedPerson == null)
                return;

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this person?",
                "Confirm Delete",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result != DialogResult.OK)
                return;

            try
            {
                bool isDeleted = await _personService.DeletePersonAsync(selectedPerson.PersonID);

                if (isDeleted)
                {
                    MessageBox.Show("Person deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await _peopleGridManager.RefreshDataAsync();
                }
                else
                {
                    MessageBox.Show("Person could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Microsoft.Data.SqlClient.SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show(
                    "Cannot delete this person because they have related data linked in the system.",
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
            PersonDto selectedPerson = _peopleGridManager.GetSelectedEntity();
            if (selectedPerson == null)
                return;

            PersonDetails frm = new PersonDetails(_personService, selectedPerson.PersonID);
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            peopleGridManager_OnEditClicked(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            peopleGridManager_OnDeleteClicked(sender, e);
        }
    }
}
