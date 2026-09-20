using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.Forms.Application
{
    public partial class EditApplicationType : Form
    {
        private readonly ApplicationTypeService _applicationTypeService;
        private readonly int _applicationTypeId;
        private ApplicationTypeDto _applicationTypeDto;

        public EditApplicationType(ApplicationTypeService applicationTypeService, int applicationTypeId)
        {
            InitializeComponent();
            _applicationTypeService = applicationTypeService;
            _applicationTypeId = applicationTypeId;
        }

        private async void EditApplicationTypeForm_Load(object sender, EventArgs e)
        {
            await _loadApplicationTypeDataAsync();
        }

        private async Task _loadApplicationTypeDataAsync()
        {
            _applicationTypeDto = await _applicationTypeService.GetApplicationTypeByIdAsync(_applicationTypeId);

            if (_applicationTypeDto == null)
            {
                MessageBox.Show("Application Type not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            lblIDValue.Text = _applicationTypeDto.ApplicationTypeID.ToString();
            txtTitle.Text = _applicationTypeDto.ApplicationTypeTitle;
            txtFees.Text = _applicationTypeDto.ApplicationFees.ToString("0.0000");
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid! Put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _applicationTypeDto.ApplicationTypeTitle = txtTitle.Text.Trim();
            _applicationTypeDto.ApplicationFees = decimal.Parse(txtFees.Text.Trim());

            bool isUpdated = await _applicationTypeService.UpdateApplicationTypeAsync(_applicationTypeId,_applicationTypeDto);

            if (isUpdated)
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Error: Data was not saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title cannot be empty!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTitle, "");
            }
        }

        private void txtFees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFees.Text) || !decimal.TryParse(txtFees.Text, out decimal fees) || fees < 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Fees Amount!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFees, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}