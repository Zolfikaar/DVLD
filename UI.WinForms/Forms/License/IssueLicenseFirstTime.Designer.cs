namespace UI.WinForms.Forms.License
{
    partial class IssueLicenseFirstTime
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
            this.gbApplicationInfo = new System.Windows.Forms.GroupBox();
            this.lblCaptionLocalLicenseAppID = new System.Windows.Forms.Label();
            this.lblLocalLicenseAppID = new System.Windows.Forms.Label();
            this.lblCaptionApplicationID = new System.Windows.Forms.Label();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.lblCaptionLicenseClass = new System.Windows.Forms.Label();
            this.lblLicenseClass = new System.Windows.Forms.Label();
            this.lblCaptionApplicant = new System.Windows.Forms.Label();
            this.lblApplicant = new System.Windows.Forms.Label();
            this.lblCaptionPassedTests = new System.Windows.Forms.Label();
            this.lblPassedTests = new System.Windows.Forms.Label();
            this.lblCaptionLicenseFees = new System.Windows.Forms.Label();
            this.lblLicenseFees = new System.Windows.Forms.Label();
            this.lblCaptionValidity = new System.Windows.Forms.Label();
            this.lblValidity = new System.Windows.Forms.Label();
            this.lblCaptionNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnIssue = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Size = new System.Drawing.Size(596, 36);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "Issue Driving License (First Time)";
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 1;
            // 
            // gbApplicationInfo
            // 
            this.gbApplicationInfo.Controls.Add(this.lblCaptionLocalLicenseAppID);
            this.gbApplicationInfo.Controls.Add(this.lblLocalLicenseAppID);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionApplicationID);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationID);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionLicenseClass);
            this.gbApplicationInfo.Controls.Add(this.lblLicenseClass);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionApplicant);
            this.gbApplicationInfo.Controls.Add(this.lblApplicant);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionPassedTests);
            this.gbApplicationInfo.Controls.Add(this.lblPassedTests);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionLicenseFees);
            this.gbApplicationInfo.Controls.Add(this.lblLicenseFees);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionValidity);
            this.gbApplicationInfo.Controls.Add(this.lblValidity);
            this.gbApplicationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbApplicationInfo.Location = new System.Drawing.Point(12, 60);
            this.gbApplicationInfo.Size = new System.Drawing.Size(596, 300);
            this.gbApplicationInfo.Text = "Application Info";
            this.gbApplicationInfo.Name = "gbApplicationInfo";
            this.gbApplicationInfo.TabIndex = 2;
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
            this.lblLocalLicenseAppID.Location = new System.Drawing.Point(185, 35);
            this.lblLocalLicenseAppID.Size = new System.Drawing.Size(390, 20);
            this.lblLocalLicenseAppID.Text = "[????]";
            this.lblLocalLicenseAppID.Name = "lblLocalLicenseAppID";
            this.lblLocalLicenseAppID.TabIndex = 4;
            // 
            // lblCaptionApplicationID
            // 
            this.lblCaptionApplicationID.AutoSize = true;
            this.lblCaptionApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionApplicationID.Location = new System.Drawing.Point(15, 72);
            this.lblCaptionApplicationID.Size = new System.Drawing.Size(150, 20);
            this.lblCaptionApplicationID.Text = "Application ID:";
            this.lblCaptionApplicationID.Name = "lblCaptionApplicationID";
            this.lblCaptionApplicationID.TabIndex = 5;
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationID.Location = new System.Drawing.Point(185, 72);
            this.lblApplicationID.Size = new System.Drawing.Size(390, 20);
            this.lblApplicationID.Text = "[????]";
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.TabIndex = 6;
            // 
            // lblCaptionLicenseClass
            // 
            this.lblCaptionLicenseClass.AutoSize = true;
            this.lblCaptionLicenseClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionLicenseClass.Location = new System.Drawing.Point(15, 109);
            this.lblCaptionLicenseClass.Size = new System.Drawing.Size(120, 20);
            this.lblCaptionLicenseClass.Text = "Applied For:";
            this.lblCaptionLicenseClass.Name = "lblCaptionLicenseClass";
            this.lblCaptionLicenseClass.TabIndex = 7;
            // 
            // lblLicenseClass
            // 
            this.lblLicenseClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseClass.Location = new System.Drawing.Point(185, 109);
            this.lblLicenseClass.Size = new System.Drawing.Size(390, 20);
            this.lblLicenseClass.Text = "[????]";
            this.lblLicenseClass.Name = "lblLicenseClass";
            this.lblLicenseClass.TabIndex = 8;
            // 
            // lblCaptionApplicant
            // 
            this.lblCaptionApplicant.AutoSize = true;
            this.lblCaptionApplicant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionApplicant.Location = new System.Drawing.Point(15, 146);
            this.lblCaptionApplicant.Size = new System.Drawing.Size(100, 20);
            this.lblCaptionApplicant.Text = "Applicant:";
            this.lblCaptionApplicant.Name = "lblCaptionApplicant";
            this.lblCaptionApplicant.TabIndex = 9;
            // 
            // lblApplicant
            // 
            this.lblApplicant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicant.Location = new System.Drawing.Point(185, 146);
            this.lblApplicant.Size = new System.Drawing.Size(390, 20);
            this.lblApplicant.Text = "[????]";
            this.lblApplicant.Name = "lblApplicant";
            this.lblApplicant.TabIndex = 10;
            // 
            // lblCaptionPassedTests
            // 
            this.lblCaptionPassedTests.AutoSize = true;
            this.lblCaptionPassedTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionPassedTests.Location = new System.Drawing.Point(15, 183);
            this.lblCaptionPassedTests.Size = new System.Drawing.Size(130, 20);
            this.lblCaptionPassedTests.Text = "Passed Tests:";
            this.lblCaptionPassedTests.Name = "lblCaptionPassedTests";
            this.lblCaptionPassedTests.TabIndex = 11;
            // 
            // lblPassedTests
            // 
            this.lblPassedTests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassedTests.Location = new System.Drawing.Point(185, 183);
            this.lblPassedTests.Size = new System.Drawing.Size(390, 20);
            this.lblPassedTests.Text = "[????]";
            this.lblPassedTests.Name = "lblPassedTests";
            this.lblPassedTests.TabIndex = 12;
            // 
            // lblCaptionLicenseFees
            // 
            this.lblCaptionLicenseFees.AutoSize = true;
            this.lblCaptionLicenseFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionLicenseFees.Location = new System.Drawing.Point(15, 220);
            this.lblCaptionLicenseFees.Size = new System.Drawing.Size(130, 20);
            this.lblCaptionLicenseFees.Text = "License Fees:";
            this.lblCaptionLicenseFees.Name = "lblCaptionLicenseFees";
            this.lblCaptionLicenseFees.TabIndex = 13;
            // 
            // lblLicenseFees
            // 
            this.lblLicenseFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseFees.Location = new System.Drawing.Point(185, 220);
            this.lblLicenseFees.Size = new System.Drawing.Size(390, 20);
            this.lblLicenseFees.Text = "[????]";
            this.lblLicenseFees.Name = "lblLicenseFees";
            this.lblLicenseFees.TabIndex = 14;
            // 
            // lblCaptionValidity
            // 
            this.lblCaptionValidity.AutoSize = true;
            this.lblCaptionValidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionValidity.Location = new System.Drawing.Point(15, 257);
            this.lblCaptionValidity.Size = new System.Drawing.Size(170, 20);
            this.lblCaptionValidity.Text = "Validity (Years):";
            this.lblCaptionValidity.Name = "lblCaptionValidity";
            this.lblCaptionValidity.TabIndex = 15;
            // 
            // lblValidity
            // 
            this.lblValidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidity.Location = new System.Drawing.Point(185, 257);
            this.lblValidity.Size = new System.Drawing.Size(390, 20);
            this.lblValidity.Text = "[????]";
            this.lblValidity.Name = "lblValidity";
            this.lblValidity.TabIndex = 16;
            // 
            // lblCaptionNotes
            // 
            this.lblCaptionNotes.AutoSize = true;
            this.lblCaptionNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionNotes.Location = new System.Drawing.Point(12, 375);
            this.lblCaptionNotes.Size = new System.Drawing.Size(60, 20);
            this.lblCaptionNotes.Text = "Notes:";
            this.lblCaptionNotes.Name = "lblCaptionNotes";
            this.lblCaptionNotes.TabIndex = 17;
            // 
            // txtNotes
            // 
            this.txtNotes.Multiline = true;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(100, 372);
            this.txtNotes.Size = new System.Drawing.Size(508, 110);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.TabIndex = 18;
            // 
            // btnIssue
            // 
            this.btnIssue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Image = global::UI.WinForms.Properties.Resources.IssueDrivingLicense_32;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssue.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnIssue.Location = new System.Drawing.Point(358, 500);
            this.btnIssue.Size = new System.Drawing.Size(120, 40);
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.TabIndex = 19;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::UI.WinForms.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnClose.Location = new System.Drawing.Point(488, 500);
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Name = "btnClose";
            this.btnClose.TabIndex = 20;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // IssueLicenseFirstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 560);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbApplicationInfo);
            this.Controls.Add(this.lblCaptionNotes);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IssueLicenseFirstTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Issue Driving License (First Time)";
            this.Load += new System.EventHandler(this.IssueLicenseFirstTime_Load);
            this.gbApplicationInfo.ResumeLayout(false);
            this.gbApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbApplicationInfo;
        private System.Windows.Forms.Label lblCaptionLocalLicenseAppID;
        private System.Windows.Forms.Label lblLocalLicenseAppID;
        private System.Windows.Forms.Label lblCaptionApplicationID;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.Label lblCaptionLicenseClass;
        private System.Windows.Forms.Label lblLicenseClass;
        private System.Windows.Forms.Label lblCaptionApplicant;
        private System.Windows.Forms.Label lblApplicant;
        private System.Windows.Forms.Label lblCaptionPassedTests;
        private System.Windows.Forms.Label lblPassedTests;
        private System.Windows.Forms.Label lblCaptionLicenseFees;
        private System.Windows.Forms.Label lblLicenseFees;
        private System.Windows.Forms.Label lblCaptionValidity;
        private System.Windows.Forms.Label lblValidity;
        private System.Windows.Forms.Label lblCaptionNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnClose;
    }
}
