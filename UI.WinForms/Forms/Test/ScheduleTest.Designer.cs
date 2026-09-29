namespace UI.WinForms.Forms.Test
{
    partial class ScheduleTest
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbTestInfo = new System.Windows.Forms.GroupBox();
            this.lblCaptionLocalLicenseAppID = new System.Windows.Forms.Label();
            this.lblLocalLicenseAppID = new System.Windows.Forms.Label();
            this.lblCaptionLicenseClass = new System.Windows.Forms.Label();
            this.lblLicenseClass = new System.Windows.Forms.Label();
            this.lblCaptionApplicant = new System.Windows.Forms.Label();
            this.lblApplicant = new System.Windows.Forms.Label();
            this.lblCaptionTrial = new System.Windows.Forms.Label();
            this.lblTrial = new System.Windows.Forms.Label();
            this.lblCaptionTestFees = new System.Windows.Forms.Label();
            this.lblTestFees = new System.Windows.Forms.Label();
            this.lblCaptionDate = new System.Windows.Forms.Label();
            this.dtpAppointmentDate = new System.Windows.Forms.DateTimePicker();
            this.gbRetakeTest = new System.Windows.Forms.GroupBox();
            this.lblCaptionRetakeAppFees = new System.Windows.Forms.Label();
            this.lblRetakeAppFees = new System.Windows.Forms.Label();
            this.lblCaptionTotalFees = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.lblCaptionRetakeTestAppID = new System.Windows.Forms.Label();
            this.lblRetakeTestAppID = new System.Windows.Forms.Label();
            this.lblUserMessage = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbTestInfo.SuspendLayout();
            this.gbRetakeTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Size = new System.Drawing.Size(536, 36);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "Schedule Test";
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 1;
            // 
            // gbTestInfo
            // 
            this.gbTestInfo.Controls.Add(this.lblCaptionLocalLicenseAppID);
            this.gbTestInfo.Controls.Add(this.lblLocalLicenseAppID);
            this.gbTestInfo.Controls.Add(this.lblCaptionLicenseClass);
            this.gbTestInfo.Controls.Add(this.lblLicenseClass);
            this.gbTestInfo.Controls.Add(this.lblCaptionApplicant);
            this.gbTestInfo.Controls.Add(this.lblApplicant);
            this.gbTestInfo.Controls.Add(this.lblCaptionTrial);
            this.gbTestInfo.Controls.Add(this.lblTrial);
            this.gbTestInfo.Controls.Add(this.lblCaptionTestFees);
            this.gbTestInfo.Controls.Add(this.lblTestFees);
            this.gbTestInfo.Controls.Add(this.lblCaptionDate);
            this.gbTestInfo.Controls.Add(this.dtpAppointmentDate);
            this.gbTestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTestInfo.Location = new System.Drawing.Point(12, 60);
            this.gbTestInfo.Size = new System.Drawing.Size(536, 290);
            this.gbTestInfo.Text = "Test Info";
            this.gbTestInfo.Name = "gbTestInfo";
            this.gbTestInfo.TabIndex = 2;
            // 
            // lblCaptionLocalLicenseAppID
            // 
            this.lblCaptionLocalLicenseAppID.AutoSize = true;
            this.lblCaptionLocalLicenseAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionLocalLicenseAppID.Location = new System.Drawing.Point(15, 35);
            this.lblCaptionLocalLicenseAppID.Size = new System.Drawing.Size(110, 20);
            this.lblCaptionLocalLicenseAppID.Text = "D.L.App ID:";
            this.lblCaptionLocalLicenseAppID.Name = "lblCaptionLocalLicenseAppID";
            this.lblCaptionLocalLicenseAppID.TabIndex = 3;
            // 
            // lblLocalLicenseAppID
            // 
            this.lblLocalLicenseAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalLicenseAppID.Location = new System.Drawing.Point(165, 35);
            this.lblLocalLicenseAppID.Size = new System.Drawing.Size(350, 20);
            this.lblLocalLicenseAppID.Text = "[????]";
            this.lblLocalLicenseAppID.Name = "lblLocalLicenseAppID";
            this.lblLocalLicenseAppID.TabIndex = 4;
            // 
            // lblCaptionLicenseClass
            // 
            this.lblCaptionLicenseClass.AutoSize = true;
            this.lblCaptionLicenseClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionLicenseClass.Location = new System.Drawing.Point(15, 75);
            this.lblCaptionLicenseClass.Size = new System.Drawing.Size(120, 20);
            this.lblCaptionLicenseClass.Text = "Applied For:";
            this.lblCaptionLicenseClass.Name = "lblCaptionLicenseClass";
            this.lblCaptionLicenseClass.TabIndex = 5;
            // 
            // lblLicenseClass
            // 
            this.lblLicenseClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseClass.Location = new System.Drawing.Point(165, 75);
            this.lblLicenseClass.Size = new System.Drawing.Size(350, 20);
            this.lblLicenseClass.Text = "[????]";
            this.lblLicenseClass.Name = "lblLicenseClass";
            this.lblLicenseClass.TabIndex = 6;
            // 
            // lblCaptionApplicant
            // 
            this.lblCaptionApplicant.AutoSize = true;
            this.lblCaptionApplicant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionApplicant.Location = new System.Drawing.Point(15, 115);
            this.lblCaptionApplicant.Size = new System.Drawing.Size(50, 20);
            this.lblCaptionApplicant.Text = "Name:";
            this.lblCaptionApplicant.Name = "lblCaptionApplicant";
            this.lblCaptionApplicant.TabIndex = 7;
            // 
            // lblApplicant
            // 
            this.lblApplicant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicant.Location = new System.Drawing.Point(165, 115);
            this.lblApplicant.Size = new System.Drawing.Size(350, 20);
            this.lblApplicant.Text = "[????]";
            this.lblApplicant.Name = "lblApplicant";
            this.lblApplicant.TabIndex = 8;
            // 
            // lblCaptionTrial
            // 
            this.lblCaptionTrial.AutoSize = true;
            this.lblCaptionTrial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionTrial.Location = new System.Drawing.Point(15, 155);
            this.lblCaptionTrial.Size = new System.Drawing.Size(60, 20);
            this.lblCaptionTrial.Text = "Trial:";
            this.lblCaptionTrial.Name = "lblCaptionTrial";
            this.lblCaptionTrial.TabIndex = 9;
            // 
            // lblTrial
            // 
            this.lblTrial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrial.Location = new System.Drawing.Point(165, 155);
            this.lblTrial.Size = new System.Drawing.Size(350, 20);
            this.lblTrial.Text = "[????]";
            this.lblTrial.Name = "lblTrial";
            this.lblTrial.TabIndex = 10;
            // 
            // lblCaptionTestFees
            // 
            this.lblCaptionTestFees.AutoSize = true;
            this.lblCaptionTestFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionTestFees.Location = new System.Drawing.Point(15, 195);
            this.lblCaptionTestFees.Size = new System.Drawing.Size(50, 20);
            this.lblCaptionTestFees.Text = "Fees:";
            this.lblCaptionTestFees.Name = "lblCaptionTestFees";
            this.lblCaptionTestFees.TabIndex = 11;
            // 
            // lblTestFees
            // 
            this.lblTestFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestFees.Location = new System.Drawing.Point(165, 195);
            this.lblTestFees.Size = new System.Drawing.Size(350, 20);
            this.lblTestFees.Text = "[????]";
            this.lblTestFees.Name = "lblTestFees";
            this.lblTestFees.TabIndex = 12;
            // 
            // lblCaptionDate
            // 
            this.lblCaptionDate.AutoSize = true;
            this.lblCaptionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionDate.Location = new System.Drawing.Point(15, 238);
            this.lblCaptionDate.Size = new System.Drawing.Size(50, 20);
            this.lblCaptionDate.Text = "Date:";
            this.lblCaptionDate.Name = "lblCaptionDate";
            this.lblCaptionDate.TabIndex = 13;
            // 
            // dtpAppointmentDate
            // 
            this.dtpAppointmentDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpAppointmentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAppointmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAppointmentDate.Location = new System.Drawing.Point(165, 235);
            this.dtpAppointmentDate.Size = new System.Drawing.Size(250, 27);
            this.dtpAppointmentDate.Name = "dtpAppointmentDate";
            this.dtpAppointmentDate.TabIndex = 14;
            // 
            // gbRetakeTest
            // 
            this.gbRetakeTest.Controls.Add(this.lblCaptionRetakeAppFees);
            this.gbRetakeTest.Controls.Add(this.lblRetakeAppFees);
            this.gbRetakeTest.Controls.Add(this.lblCaptionTotalFees);
            this.gbRetakeTest.Controls.Add(this.lblTotalFees);
            this.gbRetakeTest.Controls.Add(this.lblCaptionRetakeTestAppID);
            this.gbRetakeTest.Controls.Add(this.lblRetakeTestAppID);
            this.gbRetakeTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRetakeTest.Location = new System.Drawing.Point(12, 360);
            this.gbRetakeTest.Size = new System.Drawing.Size(536, 150);
            this.gbRetakeTest.Text = "Retake Test Info";
            this.gbRetakeTest.Name = "gbRetakeTest";
            this.gbRetakeTest.TabIndex = 15;
            // 
            // lblCaptionRetakeAppFees
            // 
            this.lblCaptionRetakeAppFees.AutoSize = true;
            this.lblCaptionRetakeAppFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionRetakeAppFees.Location = new System.Drawing.Point(15, 35);
            this.lblCaptionRetakeAppFees.Size = new System.Drawing.Size(110, 20);
            this.lblCaptionRetakeAppFees.Text = "R.App Fees:";
            this.lblCaptionRetakeAppFees.Name = "lblCaptionRetakeAppFees";
            this.lblCaptionRetakeAppFees.TabIndex = 16;
            // 
            // lblRetakeAppFees
            // 
            this.lblRetakeAppFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetakeAppFees.Location = new System.Drawing.Point(165, 35);
            this.lblRetakeAppFees.Size = new System.Drawing.Size(350, 20);
            this.lblRetakeAppFees.Text = "[????]";
            this.lblRetakeAppFees.Name = "lblRetakeAppFees";
            this.lblRetakeAppFees.TabIndex = 17;
            // 
            // lblCaptionTotalFees
            // 
            this.lblCaptionTotalFees.AutoSize = true;
            this.lblCaptionTotalFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionTotalFees.Location = new System.Drawing.Point(15, 70);
            this.lblCaptionTotalFees.Size = new System.Drawing.Size(110, 20);
            this.lblCaptionTotalFees.Text = "Total Fees:";
            this.lblCaptionTotalFees.Name = "lblCaptionTotalFees";
            this.lblCaptionTotalFees.TabIndex = 18;
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFees.Location = new System.Drawing.Point(165, 70);
            this.lblTotalFees.Size = new System.Drawing.Size(350, 20);
            this.lblTotalFees.Text = "[????]";
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.TabIndex = 19;
            // 
            // lblCaptionRetakeTestAppID
            // 
            this.lblCaptionRetakeTestAppID.AutoSize = true;
            this.lblCaptionRetakeTestAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionRetakeTestAppID.Location = new System.Drawing.Point(15, 105);
            this.lblCaptionRetakeTestAppID.Size = new System.Drawing.Size(140, 20);
            this.lblCaptionRetakeTestAppID.Text = "R.Test App ID:";
            this.lblCaptionRetakeTestAppID.Name = "lblCaptionRetakeTestAppID";
            this.lblCaptionRetakeTestAppID.TabIndex = 20;
            // 
            // lblRetakeTestAppID
            // 
            this.lblRetakeTestAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetakeTestAppID.Location = new System.Drawing.Point(165, 105);
            this.lblRetakeTestAppID.Size = new System.Drawing.Size(350, 20);
            this.lblRetakeTestAppID.Text = "[????]";
            this.lblRetakeTestAppID.Name = "lblRetakeTestAppID";
            this.lblRetakeTestAppID.TabIndex = 21;
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMessage.ForeColor = System.Drawing.Color.Red;
            this.lblUserMessage.Location = new System.Drawing.Point(12, 520);
            this.lblUserMessage.Size = new System.Drawing.Size(536, 40);
            this.lblUserMessage.Text = "";
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.TabIndex = 22;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::UI.WinForms.Properties.Resources.icons8_save_24;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnSave.Location = new System.Drawing.Point(298, 580);
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Name = "btnSave";
            this.btnSave.TabIndex = 23;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::UI.WinForms.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnClose.Location = new System.Drawing.Point(428, 580);
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Name = "btnClose";
            this.btnClose.TabIndex = 24;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 640);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbTestInfo);
            this.Controls.Add(this.gbRetakeTest);
            this.Controls.Add(this.lblUserMessage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScheduleTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Schedule Test";
            this.Load += new System.EventHandler(this.ScheduleTest_Load);
            this.gbTestInfo.ResumeLayout(false);
            this.gbTestInfo.PerformLayout();
            this.gbRetakeTest.ResumeLayout(false);
            this.gbRetakeTest.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbTestInfo;
        private System.Windows.Forms.Label lblCaptionLocalLicenseAppID;
        private System.Windows.Forms.Label lblLocalLicenseAppID;
        private System.Windows.Forms.Label lblCaptionLicenseClass;
        private System.Windows.Forms.Label lblLicenseClass;
        private System.Windows.Forms.Label lblCaptionApplicant;
        private System.Windows.Forms.Label lblApplicant;
        private System.Windows.Forms.Label lblCaptionTrial;
        private System.Windows.Forms.Label lblTrial;
        private System.Windows.Forms.Label lblCaptionTestFees;
        private System.Windows.Forms.Label lblTestFees;
        private System.Windows.Forms.Label lblCaptionDate;
        private System.Windows.Forms.DateTimePicker dtpAppointmentDate;
        private System.Windows.Forms.GroupBox gbRetakeTest;
        private System.Windows.Forms.Label lblCaptionRetakeAppFees;
        private System.Windows.Forms.Label lblRetakeAppFees;
        private System.Windows.Forms.Label lblCaptionTotalFees;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label lblCaptionRetakeTestAppID;
        private System.Windows.Forms.Label lblRetakeTestAppID;
        private System.Windows.Forms.Label lblUserMessage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}
