using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.DTOs;
using Application.Services;

namespace UI.WinForms.Forms.Application
{
    public partial class AddEdit_LocalLicenseApplication : Form
    {
        public enum Mode { AddNew = 0, Update = 1 }
        private Mode _mode;

        private readonly PersonService _personService;
        private readonly LocalLicenseService _localLicenseService;
        private readonly int _localLicenseAppId;
        private LocalLicenseDto _applicationDto;
        private int _selectedPersonId = -1;

        public AddEdit_LocalLicenseApplication(LocalLicenseService localLicenseService, int localLicenseAppId, PersonService personService)
        {
            InitializeComponent();
            _localLicenseService = localLicenseService;
            _localLicenseAppId = localLicenseAppId;
            _mode = (_localLicenseAppId == -1) ? Mode.AddNew : Mode.Update;
            _personService = personService;
        }

        private async void AddEdit_LocalLicenseApplication_Load(object sender, EventArgs e)
        {
            _resetDefualtValues();

            if (_mode == Mode.Update)
            {
                await _loadApplicationDataAsync();
            }
        }

        private void _resetDefualtValues()
        {
            if (_mode == Mode.AddNew)
            {
                lblTitle.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _applicationDto = new LocalLicenseDto();

                lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                lblApplicationFees.Text = "15"; // رسوم الخدمة الثابتة
                lblCreatedBy.Text = "Admin"; // المستخدم الحالي
                btnSave.Enabled = false;
                tcApplicationInfo.Enabled = false;
            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";
                btnSave.Enabled = true;
                tcApplicationInfo.Enabled = true;
            }

            _loadLicenseClassesToComboBox();
        }

        private void _loadLicenseClassesToComboBox()
        {
            // تعبئة الكومبو بوكس بالفئات (يمكن ربطها بـ LicenseClassService إذا توفرت)
            cbLicenseClasses.Items.Clear();
            cbLicenseClasses.Items.Add("Class 1 - Small Motorcycle");
            cbLicenseClasses.Items.Add("Class 2 - Heavy Motorcycle License");
            cbLicenseClasses.Items.Add("Class 3 - Ordinary driving license");
            cbLicenseClasses.Items.Add("Class 4 - Commercial");
            cbLicenseClasses.Items.Add("Class 5 - Agricultural");
            cbLicenseClasses.SelectedIndex = 2; // Class 3 افتراضياً
        }

        private async Task _loadApplicationDataAsync()
        {
            _applicationDto = await _localLicenseService.GetLocalLicenseByIdAsync(_localLicenseAppId);

            if (_applicationDto == null)
            {
                MessageBox.Show("No Application with ID = " + _localLicenseAppId, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
                return;
            }

            lblLocalLicenseAppID.Text = _applicationDto.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = _applicationDto.ApplicationDate.ToString("dd/MM/yyyy");
            cbLicenseClasses.SelectedItem = _applicationDto.ClassName;

            // كارت تفاصيل الشخص يستدعي بيانتها بالـ ID
            // ctrlPersonCardWithFilter1.LoadPersonInfo(_applicationDto.ApplicantPersonID);
        }

        // حدث اختيار الشخص من الـ UserControl الخاص ببحث الأشخاص
        private void ctrlPersonCardWithFilter1_OnPersonSelected(int personId)
        {
            _selectedPersonId = personId;

            if (_selectedPersonId == -1)
            {
                btnSave.Enabled = false;
                tcApplicationInfo.Enabled = false;
                return;
            }

            btnSave.Enabled = true;
            tcApplicationInfo.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_selectedPersonId == -1 && _mode == Mode.AddNew)
            {
                MessageBox.Show("Please Select a Person First!", "Select Person", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tcApplicationInfo.SelectedTab = tpApplicationInfo;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string selectedClass = cbLicenseClasses.SelectedItem.ToString();

            // فحص القيد: عدم السماح بإضافة طلب جديد لنفس الشخص لنفس الفئة بطلب نشط
            if (_mode == Mode.AddNew)
            {
                var allApps = await _localLicenseService.GetAllLocalLicenseAsync();
                bool hasActiveApplication = allApps.Any(a => a.NationalNo == _applicationDto.NationalNo &&
                                                              a.ClassName == selectedClass &&
                                                              a.Status == "New");

                if (hasActiveApplication)
                {
                    MessageBox.Show("Choose another License Class, the selected Person already has an active application for the selected class!",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            _applicationDto.ClassName = selectedClass;
            _applicationDto.ApplicationDate = DateTime.Now;
            _applicationDto.Status = "New";

            if (_mode == Mode.AddNew)
            {
                int newAppId = await _localLicenseService.AddLocalLicenseAsync(_applicationDto);

                if (newAppId != -1)
                {
                    lblLocalLicenseAppID.Text = newAppId.ToString();
                    _mode = Mode.Update;
                    lblTitle.Text = "Update Local Driving License Application";
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error: Data was not saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 1. حدث البحث عن شخص باستخدام زر البحث
        private async void btnFindPerson_Click(object sender, EventArgs e)
        {
            string filterValue = txtFilterValue.Text.Trim();

            if (string.IsNullOrEmpty(filterValue))
            {
                MessageBox.Show("Please enter a search value!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // هنا استدعاء خدمة البحث عن الشخص من PersonService (حسب طريقة البحث بالـ ID أو الرقم الوطني)
            // var person = await _personService.GetPersonByNationalNoAsync(filterValue);

            /* مثال توضيحي بعد جلب بيانات الشخص:
            if (person != null)
            {
                _selectedPersonId = person.PersonID;
                _loadPersonData(person);
            }
            else
            {
                MessageBox.Show("No Person Found with this criteria!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _resetPersonInfo();
            }
            */
        }

        // 2. حدث إضافة شخص جديد عند الضغط على زر (+)
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            // فتح شاشة إضافة شخص جديد
            // var frm = new AddEditPerson(-1);
            // frm.ShowDialog();

            // إذا عاد الشباك بـ PersonID جديد:
            // if (frm.PersonID != -1)
            // {
            //     _selectedPersonId = frm.PersonID;
            //     await _loadPersonDataByIdAsync(_selectedPersonId);
            // }
        }

        private async void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (_selectedPersonId == -1)
            //{
            //    MessageBox.Show("Please select a person first!", "No Person Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //// فتح شاشة تعديل الشخص المستقلة المجهزة عندك سلفاً
            //var frm = new UI.WinForms.Forms.Person.AddEdit(_personService, _selectedPersonId);
            //frm.ShowDialog();

            //// إعادة جلب بيانات الشخص المختار حالياً لتحديث الـ Labels إذا جرى تعديلها
            //await _loadPersonDataByIdAsync(_selectedPersonId);
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}