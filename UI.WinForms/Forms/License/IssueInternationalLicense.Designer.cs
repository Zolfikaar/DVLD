namespace UI.WinForms.Forms.License
{
    partial class IssueInternationalLicense
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
            this.lblCaptionInternationalAppID = new System.Windows.Forms.Label();
            this.lblInternationalAppID = new System.Windows.Forms.Label();
            this.lblCaptionApplicationDate = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblCaptionIssueDate = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.lblCaptionFees = new System.Windows.Forms.Label();
            this.lblFees = new System.Windows.Forms.Label();
            this.lblCaptionInternationalLicenseID = new System.Windows.Forms.Label();
            this.lblInternationalLicenseID = new System.Windows.Forms.Label();
            this.lblCaptionLocalLicenseID = new System.Windows.Forms.Label();
            this.lblLocalLicenseID = new System.Windows.Forms.Label();
            this.lblCaptionExpirationDate = new System.Windows.Forms.Label();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.lblCaptionCreatedBy = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.llShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.llShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
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
            this.lblTitle.Size = new System.Drawing.Size(900, 36);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "International License Application";
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
            this.gbApplicationInfo.Controls.Add(this.lblCaptionInternationalAppID);
            this.gbApplicationInfo.Controls.Add(this.lblInternationalAppID);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionApplicationDate);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionIssueDate);
            this.gbApplicationInfo.Controls.Add(this.lblIssueDate);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionFees);
            this.gbApplicationInfo.Controls.Add(this.lblFees);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionInternationalLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lblInternationalLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionLocalLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lblLocalLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionExpirationDate);
            this.gbApplicationInfo.Controls.Add(this.lblExpirationDate);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionCreatedBy);
            this.gbApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.gbApplicationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbApplicationInfo.Location = new System.Drawing.Point(12, 435);
            this.gbApplicationInfo.Size = new System.Drawing.Size(900, 170);
            this.gbApplicationInfo.Text = "Application Info";
            this.gbApplicationInfo.Name = "gbApplicationInfo";
            this.gbApplicationInfo.TabIndex = 3;
            // 
            // lblCaptionInternationalAppID
            // 
            this.lblCaptionInternationalAppID.AutoSize = true;
            this.lblCaptionInternationalAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionInternationalAppID.Location = new System.Drawing.Point(15, 32);
            this.lblCaptionInternationalAppID.Size = new System.Drawing.Size(110, 20);
            this.lblCaptionInternationalAppID.Text = "I.L.App ID:";
            this.lblCaptionInternationalAppID.Name = "lblCaptionInternationalAppID";
            this.lblCaptionInternationalAppID.TabIndex = 4;
            // 
            // lblInternationalAppID
            // 
            this.lblInternationalAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationalAppID.Location = new System.Drawing.Point(195, 32);
            this.lblInternationalAppID.Size = new System.Drawing.Size(240, 20);
            this.lblInternationalAppID.Text = "[????]";
            this.lblInternationalAppID.Name = "lblInternationalAppID";
            this.lblInternationalAppID.TabIndex = 5;
            // 
            // lblCaptionApplicationDate
            // 
            this.lblCaptionApplicationDate.AutoSize = true;
            this.lblCaptionApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionApplicationDate.Location = new System.Drawing.Point(15, 66);
            this.lblCaptionApplicationDate.Size = new System.Drawing.Size(170, 20);
            this.lblCaptionApplicationDate.Text = "Application Date:";
            this.lblCaptionApplicationDate.Name = "lblCaptionApplicationDate";
            this.lblCaptionApplicationDate.TabIndex = 6;
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(195, 66);
            this.lblApplicationDate.Size = new System.Drawing.Size(240, 20);
            this.lblApplicationDate.Text = "[????]";
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.TabIndex = 7;
            // 
            // lblCaptionIssueDate
            // 
            this.lblCaptionIssueDate.AutoSize = true;
            this.lblCaptionIssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionIssueDate.Location = new System.Drawing.Point(15, 100);
            this.lblCaptionIssueDate.Size = new System.Drawing.Size(110, 20);
            this.lblCaptionIssueDate.Text = "Issue Date:";
            this.lblCaptionIssueDate.Name = "lblCaptionIssueDate";
            this.lblCaptionIssueDate.TabIndex = 8;
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueDate.Location = new System.Drawing.Point(195, 100);
            this.lblIssueDate.Size = new System.Drawing.Size(240, 20);
            this.lblIssueDate.Text = "[????]";
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.TabIndex = 9;
            // 
            // lblCaptionFees
            // 
            this.lblCaptionFees.AutoSize = true;
            this.lblCaptionFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionFees.Location = new System.Drawing.Point(15, 134);
            this.lblCaptionFees.Size = new System.Drawing.Size(50, 20);
            this.lblCaptionFees.Text = "Fees:";
            this.lblCaptionFees.Name = "lblCaptionFees";
            this.lblCaptionFees.TabIndex = 10;
            // 
            // lblFees
            // 
            this.lblFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFees.Location = new System.Drawing.Point(195, 134);
            this.lblFees.Size = new System.Drawing.Size(240, 20);
            this.lblFees.Text = "[????]";
            this.lblFees.Name = "lblFees";
            this.lblFees.TabIndex = 11;
            // 
            // lblCaptionInternationalLicenseID
            // 
            this.lblCaptionInternationalLicenseID.AutoSize = true;
            this.lblCaptionInternationalLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionInternationalLicenseID.Location = new System.Drawing.Point(465, 32);
            this.lblCaptionInternationalLicenseID.Size = new System.Drawing.Size(150, 20);
            this.lblCaptionInternationalLicenseID.Text = "I.L.License ID:";
            this.lblCaptionInternationalLicenseID.Name = "lblCaptionInternationalLicenseID";
            this.lblCaptionInternationalLicenseID.TabIndex = 12;
            // 
            // lblInternationalLicenseID
            // 
            this.lblInternationalLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationalLicenseID.Location = new System.Drawing.Point(645, 32);
            this.lblInternationalLicenseID.Size = new System.Drawing.Size(240, 20);
            this.lblInternationalLicenseID.Text = "[????]";
            this.lblInternationalLicenseID.Name = "lblInternationalLicenseID";
            this.lblInternationalLicenseID.TabIndex = 13;
            // 
            // lblCaptionLocalLicenseID
            // 
            this.lblCaptionLocalLicenseID.AutoSize = true;
            this.lblCaptionLocalLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionLocalLicenseID.Location = new System.Drawing.Point(465, 66);
            this.lblCaptionLocalLicenseID.Size = new System.Drawing.Size(170, 20);
            this.lblCaptionLocalLicenseID.Text = "Local License ID:";
            this.lblCaptionLocalLicenseID.Name = "lblCaptionLocalLicenseID";
            this.lblCaptionLocalLicenseID.TabIndex = 14;
            // 
            // lblLocalLicenseID
            // 
            this.lblLocalLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalLicenseID.Location = new System.Drawing.Point(645, 66);
            this.lblLocalLicenseID.Size = new System.Drawing.Size(240, 20);
            this.lblLocalLicenseID.Text = "[????]";
            this.lblLocalLicenseID.Name = "lblLocalLicenseID";
            this.lblLocalLicenseID.TabIndex = 15;
            // 
            // lblCaptionExpirationDate
            // 
            this.lblCaptionExpirationDate.AutoSize = true;
            this.lblCaptionExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionExpirationDate.Location = new System.Drawing.Point(465, 100);
            this.lblCaptionExpirationDate.Size = new System.Drawing.Size(160, 20);
            this.lblCaptionExpirationDate.Text = "Expiration Date:";
            this.lblCaptionExpirationDate.Name = "lblCaptionExpirationDate";
            this.lblCaptionExpirationDate.TabIndex = 16;
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpirationDate.Location = new System.Drawing.Point(645, 100);
            this.lblExpirationDate.Size = new System.Drawing.Size(240, 20);
            this.lblExpirationDate.Text = "[????]";
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.TabIndex = 17;
            // 
            // lblCaptionCreatedBy
            // 
            this.lblCaptionCreatedBy.AutoSize = true;
            this.lblCaptionCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionCreatedBy.Location = new System.Drawing.Point(465, 134);
            this.lblCaptionCreatedBy.Size = new System.Drawing.Size(110, 20);
            this.lblCaptionCreatedBy.Text = "Created By:";
            this.lblCaptionCreatedBy.Name = "lblCaptionCreatedBy";
            this.lblCaptionCreatedBy.TabIndex = 18;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(645, 134);
            this.lblCreatedBy.Size = new System.Drawing.Size(240, 20);
            this.lblCreatedBy.Text = "[????]";
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.TabIndex = 19;
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
            // btnIssue
            // 
            this.btnIssue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Image = global::UI.WinForms.Properties.Resources.IssueDrivingLicense_32;
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIssue.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnIssue.Location = new System.Drawing.Point(662, 617);
            this.btnIssue.Size = new System.Drawing.Size(120, 40);
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.TabIndex = 22;
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
            this.btnClose.Location = new System.Drawing.Point(792, 617);
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Name = "btnClose";
            this.btnClose.TabIndex = 23;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // IssueInternationalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 715);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctrlLicenseFinder1);
            this.Controls.Add(this.gbApplicationInfo);
            this.Controls.Add(this.llShowLicensesHistory);
            this.Controls.Add(this.llShowNewLicenseInfo);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IssueInternationalLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "International License Application";
            this.Load += new System.EventHandler(this.IssueInternationalLicense_Load);
            this.gbApplicationInfo.ResumeLayout(false);
            this.gbApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private UI.WinForms.UserControls.ctrlLicenseFinder ctrlLicenseFinder1;
        private System.Windows.Forms.GroupBox gbApplicationInfo;
        private System.Windows.Forms.Label lblCaptionInternationalAppID;
        private System.Windows.Forms.Label lblInternationalAppID;
        private System.Windows.Forms.Label lblCaptionApplicationDate;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblCaptionIssueDate;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label lblCaptionFees;
        private System.Windows.Forms.Label lblFees;
        private System.Windows.Forms.Label lblCaptionInternationalLicenseID;
        private System.Windows.Forms.Label lblInternationalLicenseID;
        private System.Windows.Forms.Label lblCaptionLocalLicenseID;
        private System.Windows.Forms.Label lblLocalLicenseID;
        private System.Windows.Forms.Label lblCaptionExpirationDate;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.Label lblCaptionCreatedBy;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.LinkLabel llShowLicensesHistory;
        private System.Windows.Forms.LinkLabel llShowNewLicenseInfo;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnClose;
    }
}
