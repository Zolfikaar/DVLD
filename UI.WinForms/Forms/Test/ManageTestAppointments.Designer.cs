namespace UI.WinForms.Forms.Test
{
    partial class ManageTestAppointments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbApplication = new System.Windows.Forms.GroupBox();
            this.lblCaptionLocalLicenseAppID = new System.Windows.Forms.Label();
            this.lblLocalLicenseAppID = new System.Windows.Forms.Label();
            this.lblCaptionLicenseClass = new System.Windows.Forms.Label();
            this.lblLicenseClass = new System.Windows.Forms.Label();
            this.lblCaptionApplicant = new System.Windows.Forms.Label();
            this.lblApplicant = new System.Windows.Forms.Label();
            this.lblCaptionPassedTests = new System.Windows.Forms.Label();
            this.lblPassedTests = new System.Windows.Forms.Label();
            this.lblCaptionStatus = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCaptionTestFees = new System.Windows.Forms.Label();
            this.lblTestFees = new System.Windows.Forms.Label();
            this.lblAppointments = new System.Windows.Forms.Label();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.lblCaptionRecords = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmsAppointments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbApplication.SuspendLayout();
            this.cmsAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Size = new System.Drawing.Size(876, 36);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "Test Appointments";
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 1;
            // 
            // gbApplication
            // 
            this.gbApplication.Controls.Add(this.lblCaptionLocalLicenseAppID);
            this.gbApplication.Controls.Add(this.lblLocalLicenseAppID);
            this.gbApplication.Controls.Add(this.lblCaptionLicenseClass);
            this.gbApplication.Controls.Add(this.lblLicenseClass);
            this.gbApplication.Controls.Add(this.lblCaptionApplicant);
            this.gbApplication.Controls.Add(this.lblApplicant);
            this.gbApplication.Controls.Add(this.lblCaptionPassedTests);
            this.gbApplication.Controls.Add(this.lblPassedTests);
            this.gbApplication.Controls.Add(this.lblCaptionStatus);
            this.gbApplication.Controls.Add(this.lblStatus);
            this.gbApplication.Controls.Add(this.lblCaptionTestFees);
            this.gbApplication.Controls.Add(this.lblTestFees);
            this.gbApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbApplication.Location = new System.Drawing.Point(12, 60);
            this.gbApplication.Size = new System.Drawing.Size(876, 150);
            this.gbApplication.Text = "Application Info";
            this.gbApplication.Name = "gbApplication";
            this.gbApplication.TabIndex = 2;
            // 
            // lblCaptionLocalLicenseAppID
            // 
            this.lblCaptionLocalLicenseAppID.AutoSize = true;
            this.lblCaptionLocalLicenseAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionLocalLicenseAppID.Location = new System.Drawing.Point(15, 35);
            this.lblCaptionLocalLicenseAppID.Size = new System.Drawing.Size(130, 20);
            this.lblCaptionLocalLicenseAppID.Text = "L.D.L.App ID:";
            this.lblCaptionLocalLicenseAppID.Name = "lblCaptionLocalLicenseAppID";
            this.lblCaptionLocalLicenseAppID.TabIndex = 3;
            // 
            // lblLocalLicenseAppID
            // 
            this.lblLocalLicenseAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalLicenseAppID.Location = new System.Drawing.Point(155, 35);
            this.lblLocalLicenseAppID.Size = new System.Drawing.Size(250, 20);
            this.lblLocalLicenseAppID.Text = "[????]";
            this.lblLocalLicenseAppID.Name = "lblLocalLicenseAppID";
            this.lblLocalLicenseAppID.TabIndex = 4;
            // 
            // lblCaptionLicenseClass
            // 
            this.lblCaptionLicenseClass.AutoSize = true;
            this.lblCaptionLicenseClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionLicenseClass.Location = new System.Drawing.Point(15, 70);
            this.lblCaptionLicenseClass.Size = new System.Drawing.Size(120, 20);
            this.lblCaptionLicenseClass.Text = "Applied For:";
            this.lblCaptionLicenseClass.Name = "lblCaptionLicenseClass";
            this.lblCaptionLicenseClass.TabIndex = 5;
            // 
            // lblLicenseClass
            // 
            this.lblLicenseClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseClass.Location = new System.Drawing.Point(155, 70);
            this.lblLicenseClass.Size = new System.Drawing.Size(250, 20);
            this.lblLicenseClass.Text = "[????]";
            this.lblLicenseClass.Name = "lblLicenseClass";
            this.lblLicenseClass.TabIndex = 6;
            // 
            // lblCaptionApplicant
            // 
            this.lblCaptionApplicant.AutoSize = true;
            this.lblCaptionApplicant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionApplicant.Location = new System.Drawing.Point(15, 105);
            this.lblCaptionApplicant.Size = new System.Drawing.Size(100, 20);
            this.lblCaptionApplicant.Text = "Applicant:";
            this.lblCaptionApplicant.Name = "lblCaptionApplicant";
            this.lblCaptionApplicant.TabIndex = 7;
            // 
            // lblApplicant
            // 
            this.lblApplicant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicant.Location = new System.Drawing.Point(155, 105);
            this.lblApplicant.Size = new System.Drawing.Size(250, 20);
            this.lblApplicant.Text = "[????]";
            this.lblApplicant.Name = "lblApplicant";
            this.lblApplicant.TabIndex = 8;
            // 
            // lblCaptionPassedTests
            // 
            this.lblCaptionPassedTests.AutoSize = true;
            this.lblCaptionPassedTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionPassedTests.Location = new System.Drawing.Point(450, 35);
            this.lblCaptionPassedTests.Size = new System.Drawing.Size(130, 20);
            this.lblCaptionPassedTests.Text = "Passed Tests:";
            this.lblCaptionPassedTests.Name = "lblCaptionPassedTests";
            this.lblCaptionPassedTests.TabIndex = 9;
            // 
            // lblPassedTests
            // 
            this.lblPassedTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassedTests.Location = new System.Drawing.Point(600, 35);
            this.lblPassedTests.Size = new System.Drawing.Size(250, 20);
            this.lblPassedTests.Text = "[????]";
            this.lblPassedTests.Name = "lblPassedTests";
            this.lblPassedTests.TabIndex = 10;
            // 
            // lblCaptionStatus
            // 
            this.lblCaptionStatus.AutoSize = true;
            this.lblCaptionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionStatus.Location = new System.Drawing.Point(450, 70);
            this.lblCaptionStatus.Size = new System.Drawing.Size(70, 20);
            this.lblCaptionStatus.Text = "Status:";
            this.lblCaptionStatus.Name = "lblCaptionStatus";
            this.lblCaptionStatus.TabIndex = 11;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(600, 70);
            this.lblStatus.Size = new System.Drawing.Size(250, 20);
            this.lblStatus.Text = "[????]";
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.TabIndex = 12;
            // 
            // lblCaptionTestFees
            // 
            this.lblCaptionTestFees.AutoSize = true;
            this.lblCaptionTestFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionTestFees.Location = new System.Drawing.Point(450, 105);
            this.lblCaptionTestFees.Size = new System.Drawing.Size(100, 20);
            this.lblCaptionTestFees.Text = "Test Fees:";
            this.lblCaptionTestFees.Name = "lblCaptionTestFees";
            this.lblCaptionTestFees.TabIndex = 13;
            // 
            // lblTestFees
            // 
            this.lblTestFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestFees.Location = new System.Drawing.Point(600, 105);
            this.lblTestFees.Size = new System.Drawing.Size(250, 20);
            this.lblTestFees.Text = "[????]";
            this.lblTestFees.Name = "lblTestFees";
            this.lblTestFees.TabIndex = 14;
            // 
            // lblAppointments
            // 
            this.lblAppointments.AutoSize = true;
            this.lblAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointments.Location = new System.Drawing.Point(12, 228);
            this.lblAppointments.Size = new System.Drawing.Size(130, 20);
            this.lblAppointments.Text = "Appointments:";
            this.lblAppointments.Name = "lblAppointments";
            this.lblAppointments.TabIndex = 15;
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAppointment.Image = global::UI.WinForms.Properties.Resources.icons8_schedule_48;
            this.btnAddAppointment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddAppointment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddAppointment.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnAddAppointment.Location = new System.Drawing.Point(748, 218);
            this.btnAddAppointment.Size = new System.Drawing.Size(140, 40);
            this.btnAddAppointment.Text = "Schedule";
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.TabIndex = 16;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AllowUserToDeleteRows = false;
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.BackgroundColor = System.Drawing.Color.White;
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.ContextMenuStrip = this.cmsAppointments;
            this.dgvAppointments.Location = new System.Drawing.Point(12, 265);
            this.dgvAppointments.MultiSelect = false;
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.RowHeadersWidth = 51;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.Size = new System.Drawing.Size(876, 300);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.TabIndex = 17;
            // 
            // lblCaptionRecords
            // 
            this.lblCaptionRecords.AutoSize = true;
            this.lblCaptionRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionRecords.Location = new System.Drawing.Point(12, 590);
            this.lblCaptionRecords.Size = new System.Drawing.Size(90, 20);
            this.lblCaptionRecords.Text = "#Records:";
            this.lblCaptionRecords.Name = "lblCaptionRecords";
            this.lblCaptionRecords.TabIndex = 18;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(115, 590);
            this.lblRecordsCount.Size = new System.Drawing.Size(10, 20);
            this.lblRecordsCount.Text = "0";
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.TabIndex = 19;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::UI.WinForms.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnClose.Location = new System.Drawing.Point(768, 585);
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Name = "btnClose";
            this.btnClose.TabIndex = 20;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmsAppointments
            // 
            this.cmsAppointments.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsAppointments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editAppointmentToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.cmsAppointments.Name = "cmsAppointments";
            this.cmsAppointments.Size = new System.Drawing.Size(261, 56);
            this.cmsAppointments.Opening += new System.ComponentModel.CancelEventHandler(this.cmsAppointments_Opening);
            // 
            // editAppointmentToolStripMenuItem
            // 
            this.editAppointmentToolStripMenuItem.Image = global::UI.WinForms.Properties.Resources.edit_32;
            this.editAppointmentToolStripMenuItem.Name = "editAppointmentToolStripMenuItem";
            this.editAppointmentToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.editAppointmentToolStripMenuItem.Text = "Edit Appointment";
            this.editAppointmentToolStripMenuItem.Click += new System.EventHandler(this.editAppointmentToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::UI.WinForms.Properties.Resources.exam;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // ManageTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 640);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbApplication);
            this.Controls.Add(this.lblAppointments);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.dgvAppointments);
            this.Controls.Add(this.lblCaptionRecords);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageTestAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Test Appointments";
            this.Load += new System.EventHandler(this.ManageTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.cmsAppointments.ResumeLayout(false);
            this.gbApplication.ResumeLayout(false);
            this.gbApplication.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbApplication;
        private System.Windows.Forms.Label lblCaptionLocalLicenseAppID;
        private System.Windows.Forms.Label lblLocalLicenseAppID;
        private System.Windows.Forms.Label lblCaptionLicenseClass;
        private System.Windows.Forms.Label lblLicenseClass;
        private System.Windows.Forms.Label lblCaptionApplicant;
        private System.Windows.Forms.Label lblApplicant;
        private System.Windows.Forms.Label lblCaptionPassedTests;
        private System.Windows.Forms.Label lblPassedTests;
        private System.Windows.Forms.Label lblCaptionStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCaptionTestFees;
        private System.Windows.Forms.Label lblTestFees;
        private System.Windows.Forms.Label lblAppointments;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Label lblCaptionRecords;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmsAppointments;
        private System.Windows.Forms.ToolStripMenuItem editAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}
