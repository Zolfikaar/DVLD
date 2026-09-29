namespace UI.WinForms.Forms.License
{
    partial class ReleaseDetainedLicense
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
            this.ctrlLicenseFinder1 = new UI.WinForms.UserControls.ctrlLicenseFinder();
            this.gbApplicationInfo = new System.Windows.Forms.GroupBox();
            this.lblCaptionDetainID = new System.Windows.Forms.Label();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.lblCaptionDetainDate = new System.Windows.Forms.Label();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.lblCaptionLicenseID = new System.Windows.Forms.Label();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.lblCaptionCreatedBy = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblCaptionApplicationFees = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblCaptionFineFees = new System.Windows.Forms.Label();
            this.lblFineFees = new System.Windows.Forms.Label();
            this.lblCaptionTotalFees = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.lblCaptionApplicationID = new System.Windows.Forms.Label();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.llShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.llShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Size = new System.Drawing.Size(900, 36);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "Release Detained License";
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 1;
            // 
            // ctrlLicenseFinder1
            // 
            this.ctrlLicenseFinder1.Location = new System.Drawing.Point(12, 55);
            this.ctrlLicenseFinder1.Size = new System.Drawing.Size(900, 375);
            this.ctrlLicenseFinder1.Name = "ctrlLicenseFinder1";
            this.ctrlLicenseFinder1.TabIndex = 2;
            // 
            // gbApplicationInfo
            // 
            this.gbApplicationInfo.Controls.Add(this.lblCaptionDetainID);
            this.gbApplicationInfo.Controls.Add(this.lblDetainID);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionDetainDate);
            this.gbApplicationInfo.Controls.Add(this.lblDetainDate);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lblLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionCreatedBy);
            this.gbApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionApplicationFees);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionFineFees);
            this.gbApplicationInfo.Controls.Add(this.lblFineFees);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionTotalFees);
            this.gbApplicationInfo.Controls.Add(this.lblTotalFees);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionApplicationID);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationID);
            this.gbApplicationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbApplicationInfo.Location = new System.Drawing.Point(12, 435);
            this.gbApplicationInfo.Size = new System.Drawing.Size(900, 170);
            this.gbApplicationInfo.Text = "Application Info";
            this.gbApplicationInfo.Name = "gbApplicationInfo";
            this.gbApplicationInfo.TabIndex = 3;
            // 
            // lblCaptionDetainID
            // 
            this.lblCaptionDetainID.AutoSize = true;
            this.lblCaptionDetainID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionDetainID.Location = new System.Drawing.Point(15, 32);
            this.lblCaptionDetainID.Size = new System.Drawing.Size(100, 20);
            this.lblCaptionDetainID.Text = "Detain ID:";
            this.lblCaptionDetainID.Name = "lblCaptionDetainID";
            this.lblCaptionDetainID.TabIndex = 4;
            // 
            // lblDetainID
            // 
            this.lblDetainID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainID.Location = new System.Drawing.Point(195, 32);
            this.lblDetainID.Size = new System.Drawing.Size(240, 20);
            this.lblDetainID.Text = "[????]";
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.TabIndex = 5;
            // 
            // lblCaptionDetainDate
            // 
            this.lblCaptionDetainDate.AutoSize = true;
            this.lblCaptionDetainDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionDetainDate.Location = new System.Drawing.Point(15, 66);
            this.lblCaptionDetainDate.Size = new System.Drawing.Size(120, 20);
            this.lblCaptionDetainDate.Text = "Detain Date:";
            this.lblCaptionDetainDate.Name = "lblCaptionDetainDate";
            this.lblCaptionDetainDate.TabIndex = 6;
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainDate.Location = new System.Drawing.Point(195, 66);
            this.lblDetainDate.Size = new System.Drawing.Size(240, 20);
            this.lblDetainDate.Text = "[????]";
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.TabIndex = 7;
            // 
            // lblCaptionLicenseID
            // 
            this.lblCaptionLicenseID.AutoSize = true;
            this.lblCaptionLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionLicenseID.Location = new System.Drawing.Point(15, 100);
            this.lblCaptionLicenseID.Size = new System.Drawing.Size(110, 20);
            this.lblCaptionLicenseID.Text = "License ID:";
            this.lblCaptionLicenseID.Name = "lblCaptionLicenseID";
            this.lblCaptionLicenseID.TabIndex = 8;
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseID.Location = new System.Drawing.Point(195, 100);
            this.lblLicenseID.Size = new System.Drawing.Size(240, 20);
            this.lblLicenseID.Text = "[????]";
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.TabIndex = 9;
            // 
            // lblCaptionCreatedBy
            // 
            this.lblCaptionCreatedBy.AutoSize = true;
            this.lblCaptionCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionCreatedBy.Location = new System.Drawing.Point(15, 134);
            this.lblCaptionCreatedBy.Size = new System.Drawing.Size(110, 20);
            this.lblCaptionCreatedBy.Text = "Created By:";
            this.lblCaptionCreatedBy.Name = "lblCaptionCreatedBy";
            this.lblCaptionCreatedBy.TabIndex = 10;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(195, 134);
            this.lblCreatedBy.Size = new System.Drawing.Size(240, 20);
            this.lblCreatedBy.Text = "[????]";
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.TabIndex = 11;
            // 
            // lblCaptionApplicationFees
            // 
            this.lblCaptionApplicationFees.AutoSize = true;
            this.lblCaptionApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionApplicationFees.Location = new System.Drawing.Point(465, 32);
            this.lblCaptionApplicationFees.Size = new System.Drawing.Size(170, 20);
            this.lblCaptionApplicationFees.Text = "Application Fees:";
            this.lblCaptionApplicationFees.Name = "lblCaptionApplicationFees";
            this.lblCaptionApplicationFees.TabIndex = 12;
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(645, 32);
            this.lblApplicationFees.Size = new System.Drawing.Size(240, 20);
            this.lblApplicationFees.Text = "[????]";
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.TabIndex = 13;
            // 
            // lblCaptionFineFees
            // 
            this.lblCaptionFineFees.AutoSize = true;
            this.lblCaptionFineFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionFineFees.Location = new System.Drawing.Point(465, 66);
            this.lblCaptionFineFees.Size = new System.Drawing.Size(100, 20);
            this.lblCaptionFineFees.Text = "Fine Fees:";
            this.lblCaptionFineFees.Name = "lblCaptionFineFees";
            this.lblCaptionFineFees.TabIndex = 14;
            // 
            // lblFineFees
            // 
            this.lblFineFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFineFees.Location = new System.Drawing.Point(645, 66);
            this.lblFineFees.Size = new System.Drawing.Size(240, 20);
            this.lblFineFees.Text = "[????]";
            this.lblFineFees.Name = "lblFineFees";
            this.lblFineFees.TabIndex = 15;
            // 
            // lblCaptionTotalFees
            // 
            this.lblCaptionTotalFees.AutoSize = true;
            this.lblCaptionTotalFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionTotalFees.Location = new System.Drawing.Point(465, 100);
            this.lblCaptionTotalFees.Size = new System.Drawing.Size(110, 20);
            this.lblCaptionTotalFees.Text = "Total Fees:";
            this.lblCaptionTotalFees.Name = "lblCaptionTotalFees";
            this.lblCaptionTotalFees.TabIndex = 16;
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFees.Location = new System.Drawing.Point(645, 100);
            this.lblTotalFees.Size = new System.Drawing.Size(240, 20);
            this.lblTotalFees.Text = "[????]";
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.TabIndex = 17;
            // 
            // lblCaptionApplicationID
            // 
            this.lblCaptionApplicationID.AutoSize = true;
            this.lblCaptionApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionApplicationID.Location = new System.Drawing.Point(465, 134);
            this.lblCaptionApplicationID.Size = new System.Drawing.Size(150, 20);
            this.lblCaptionApplicationID.Text = "Application ID:";
            this.lblCaptionApplicationID.Name = "lblCaptionApplicationID";
            this.lblCaptionApplicationID.TabIndex = 18;
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationID.Location = new System.Drawing.Point(645, 134);
            this.lblApplicationID.Size = new System.Drawing.Size(240, 20);
            this.lblApplicationID.Text = "[????]";
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.TabIndex = 19;
            // 
            // llShowLicensesHistory
            // 
            this.llShowLicensesHistory.AutoSize = true;
            this.llShowLicensesHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicensesHistory.Location = new System.Drawing.Point(12, 627);
            this.llShowLicensesHistory.Size = new System.Drawing.Size(210, 20);
            this.llShowLicensesHistory.TabStop = true;
            this.llShowLicensesHistory.Text = "Show Licenses History";
            this.llShowLicensesHistory.Name = "llShowLicensesHistory";
            this.llShowLicensesHistory.TabIndex = 20;
            this.llShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicensesHistory_LinkClicked);
            // 
            // llShowNewLicenseInfo
            // 
            this.llShowNewLicenseInfo.AutoSize = true;
            this.llShowNewLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowNewLicenseInfo.Location = new System.Drawing.Point(240, 627);
            this.llShowNewLicenseInfo.Size = new System.Drawing.Size(210, 20);
            this.llShowNewLicenseInfo.TabStop = true;
            this.llShowNewLicenseInfo.Text = "Show New License Info";
            this.llShowNewLicenseInfo.Name = "llShowNewLicenseInfo";
            this.llShowNewLicenseInfo.TabIndex = 21;
            this.llShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowNewLicenseInfo_LinkClicked);
            // 
            // btnRelease
            // 
            this.btnRelease.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRelease.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelease.Image = global::UI.WinForms.Properties.Resources.Release2;
            this.btnRelease.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelease.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRelease.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnRelease.Location = new System.Drawing.Point(662, 617);
            this.btnRelease.Size = new System.Drawing.Size(120, 40);
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.TabIndex = 22;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::UI.WinForms.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnClose.Location = new System.Drawing.Point(792, 617);
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Name = "btnClose";
            this.btnClose.TabIndex = 23;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ReleaseDetainedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 715);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctrlLicenseFinder1);
            this.Controls.Add(this.gbApplicationInfo);
            this.Controls.Add(this.llShowLicensesHistory);
            this.Controls.Add(this.llShowNewLicenseInfo);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReleaseDetainedLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Release Detained License";
            this.Load += new System.EventHandler(this.ReleaseDetainedLicense_Load);
            this.gbApplicationInfo.ResumeLayout(false);
            this.gbApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private UI.WinForms.UserControls.ctrlLicenseFinder ctrlLicenseFinder1;
        private System.Windows.Forms.GroupBox gbApplicationInfo;
        private System.Windows.Forms.Label lblCaptionDetainID;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.Label lblCaptionDetainDate;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.Label lblCaptionLicenseID;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label lblCaptionCreatedBy;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblCaptionApplicationFees;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblCaptionFineFees;
        private System.Windows.Forms.Label lblFineFees;
        private System.Windows.Forms.Label lblCaptionTotalFees;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label lblCaptionApplicationID;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.LinkLabel llShowLicensesHistory;
        private System.Windows.Forms.LinkLabel llShowNewLicenseInfo;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Button btnClose;
    }
}
