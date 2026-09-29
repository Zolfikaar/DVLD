namespace UI.WinForms.Forms.Test
{
    partial class TakeTest
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
            this.lblCaptionAppointmentDate = new System.Windows.Forms.Label();
            this.lblAppointmentDate = new System.Windows.Forms.Label();
            this.lblCaptionTestFees = new System.Windows.Forms.Label();
            this.lblTestFees = new System.Windows.Forms.Label();
            this.lblCaptionTestID = new System.Windows.Forms.Label();
            this.lblTestID = new System.Windows.Forms.Label();
            this.gbResult = new System.Windows.Forms.GroupBox();
            this.rbPass = new System.Windows.Forms.RadioButton();
            this.rbFail = new System.Windows.Forms.RadioButton();
            this.lblCaptionNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbTestInfo.SuspendLayout();
            this.gbResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Size = new System.Drawing.Size(536, 36);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "Take Test";
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
            this.gbTestInfo.Controls.Add(this.lblCaptionAppointmentDate);
            this.gbTestInfo.Controls.Add(this.lblAppointmentDate);
            this.gbTestInfo.Controls.Add(this.lblCaptionTestFees);
            this.gbTestInfo.Controls.Add(this.lblTestFees);
            this.gbTestInfo.Controls.Add(this.lblCaptionTestID);
            this.gbTestInfo.Controls.Add(this.lblTestID);
            this.gbTestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTestInfo.Location = new System.Drawing.Point(12, 60);
            this.gbTestInfo.Size = new System.Drawing.Size(536, 320);
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
            // lblCaptionAppointmentDate
            // 
            this.lblCaptionAppointmentDate.AutoSize = true;
            this.lblCaptionAppointmentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionAppointmentDate.Location = new System.Drawing.Point(15, 195);
            this.lblCaptionAppointmentDate.Size = new System.Drawing.Size(50, 20);
            this.lblCaptionAppointmentDate.Text = "Date:";
            this.lblCaptionAppointmentDate.Name = "lblCaptionAppointmentDate";
            this.lblCaptionAppointmentDate.TabIndex = 11;
            // 
            // lblAppointmentDate
            // 
            this.lblAppointmentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentDate.Location = new System.Drawing.Point(165, 195);
            this.lblAppointmentDate.Size = new System.Drawing.Size(350, 20);
            this.lblAppointmentDate.Text = "[????]";
            this.lblAppointmentDate.Name = "lblAppointmentDate";
            this.lblAppointmentDate.TabIndex = 12;
            // 
            // lblCaptionTestFees
            // 
            this.lblCaptionTestFees.AutoSize = true;
            this.lblCaptionTestFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionTestFees.Location = new System.Drawing.Point(15, 235);
            this.lblCaptionTestFees.Size = new System.Drawing.Size(50, 20);
            this.lblCaptionTestFees.Text = "Fees:";
            this.lblCaptionTestFees.Name = "lblCaptionTestFees";
            this.lblCaptionTestFees.TabIndex = 13;
            // 
            // lblTestFees
            // 
            this.lblTestFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestFees.Location = new System.Drawing.Point(165, 235);
            this.lblTestFees.Size = new System.Drawing.Size(350, 20);
            this.lblTestFees.Text = "[????]";
            this.lblTestFees.Name = "lblTestFees";
            this.lblTestFees.TabIndex = 14;
            // 
            // lblCaptionTestID
            // 
            this.lblCaptionTestID.AutoSize = true;
            this.lblCaptionTestID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionTestID.Location = new System.Drawing.Point(15, 275);
            this.lblCaptionTestID.Size = new System.Drawing.Size(80, 20);
            this.lblCaptionTestID.Text = "Test ID:";
            this.lblCaptionTestID.Name = "lblCaptionTestID";
            this.lblCaptionTestID.TabIndex = 15;
            // 
            // lblTestID
            // 
            this.lblTestID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestID.Location = new System.Drawing.Point(165, 275);
            this.lblTestID.Size = new System.Drawing.Size(350, 20);
            this.lblTestID.Text = "[????]";
            this.lblTestID.Name = "lblTestID";
            this.lblTestID.TabIndex = 16;
            // 
            // gbResult
            // 
            this.gbResult.Controls.Add(this.rbPass);
            this.gbResult.Controls.Add(this.rbFail);
            this.gbResult.Controls.Add(this.lblCaptionNotes);
            this.gbResult.Controls.Add(this.txtNotes);
            this.gbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbResult.Location = new System.Drawing.Point(12, 390);
            this.gbResult.Size = new System.Drawing.Size(536, 175);
            this.gbResult.Text = "Result";
            this.gbResult.Name = "gbResult";
            this.gbResult.TabIndex = 17;
            // 
            // rbPass
            // 
            this.rbPass.AutoSize = true;
            this.rbPass.Checked = true;
            this.rbPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPass.Location = new System.Drawing.Point(20, 32);
            this.rbPass.Size = new System.Drawing.Size(40, 24);
            this.rbPass.Text = "Pass";
            this.rbPass.UseVisualStyleBackColor = true;
            this.rbPass.Name = "rbPass";
            this.rbPass.TabIndex = 18;
            // 
            // rbFail
            // 
            this.rbFail.AutoSize = true;
            this.rbFail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFail.Location = new System.Drawing.Point(140, 32);
            this.rbFail.Size = new System.Drawing.Size(40, 24);
            this.rbFail.Text = "Fail";
            this.rbFail.UseVisualStyleBackColor = true;
            this.rbFail.Name = "rbFail";
            this.rbFail.TabIndex = 19;
            // 
            // lblCaptionNotes
            // 
            this.lblCaptionNotes.AutoSize = true;
            this.lblCaptionNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionNotes.Location = new System.Drawing.Point(20, 70);
            this.lblCaptionNotes.Size = new System.Drawing.Size(60, 20);
            this.lblCaptionNotes.Text = "Notes:";
            this.lblCaptionNotes.Name = "lblCaptionNotes";
            this.lblCaptionNotes.TabIndex = 20;
            // 
            // txtNotes
            // 
            this.txtNotes.Multiline = true;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(100, 67);
            this.txtNotes.Size = new System.Drawing.Size(415, 95);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.TabIndex = 21;
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
            this.btnSave.TabIndex = 22;
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
            this.btnClose.TabIndex = 23;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TakeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 640);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbTestInfo);
            this.Controls.Add(this.gbResult);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TakeTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Take Test";
            this.Load += new System.EventHandler(this.TakeTest_Load);
            this.gbTestInfo.ResumeLayout(false);
            this.gbTestInfo.PerformLayout();
            this.gbResult.ResumeLayout(false);
            this.gbResult.PerformLayout();
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
        private System.Windows.Forms.Label lblCaptionAppointmentDate;
        private System.Windows.Forms.Label lblAppointmentDate;
        private System.Windows.Forms.Label lblCaptionTestFees;
        private System.Windows.Forms.Label lblTestFees;
        private System.Windows.Forms.Label lblCaptionTestID;
        private System.Windows.Forms.Label lblTestID;
        private System.Windows.Forms.GroupBox gbResult;
        private System.Windows.Forms.RadioButton rbPass;
        private System.Windows.Forms.RadioButton rbFail;
        private System.Windows.Forms.Label lblCaptionNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}
