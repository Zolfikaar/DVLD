using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.Forms.Test
{
    public partial class EditTestType : Form
    {
        private readonly TestTypeService _testTypeService;
        private readonly int _testTypeId;
        private TestTypeDto _testTypeDto;

        public EditTestType(TestTypeService testTypeService, int testTypeId)
        {
            InitializeComponent();
            _testTypeService = testTypeService;
            _testTypeId = testTypeId;
        }

        private async void EditTestTypeForm_Load(object sender, EventArgs e)
        {
            await _loadTestTypeDataAsync();
        }

        private async Task _loadTestTypeDataAsync()
        {
            _testTypeDto = await _testTypeService.GetTestTypeByIdAsync(_testTypeId);

            if (_testTypeDto == null)
            {
                MessageBox.Show("Test Type not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            lblIDValue.Text = _testTypeDto.TestTypeID.ToString();
            txtTitle.Text = _testTypeDto.TestTypeTitle;
            rtbDesc.Text = _testTypeDto.TestTypeDescription;
            txtFees.Text = _testTypeDto.TestTypeFees.ToString("0.0000");
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid! Put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _testTypeDto.TestTypeTitle = txtTitle.Text.Trim();
            _testTypeDto.TestTypeDescription = rtbDesc.Text.Trim();
            _testTypeDto.TestTypeFees = decimal.Parse(txtFees.Text.Trim());

            bool isUpdated = await _testTypeService.UpdateTestTypeAsync(_testTypeId, _testTypeDto);

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