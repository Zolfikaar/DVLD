namespace UI.WinForms.Forms.License
{
    partial class RenewLicense
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
            this.lblCaptionRenewAppID = new System.Windows.Forms.Label();
            this.lblRenewAppID = new System.Windows.Forms.Label();
            this.lblCaptionApplicationDate = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblCaptionIssueDate = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.lblCaptionApplicationFees = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblCaptionLicenseFees = new System.Windows.Forms.Label();
            this.lblLicenseFees = new System.Windows.Forms.Label();
            this.lblCaptionRenewedLicenseID = new System.Windows.Forms.Label();
            this.lblRenewedLicenseID = new System.Windows.Forms.Label();
            this.lblCaptionOldLicenseID = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblCaptionExpirationDate = new System.Windows.Forms.Label();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.lblCaptionCreatedBy = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblCaptionTotalFees = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.lblCaptionNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.chkOldLicenseHandedIn = new System.Windows.Forms.CheckBox();
            this.llShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.llShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.btnRenew = new System.Windows.Forms.Button();
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
            this.lblTitle.Text = "Renew Local Driving License";
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
            this.gbApplicationInfo.Controls.Add(this.lblCaptionRenewAppID);
            this.gbApplicationInfo.Controls.Add(this.lblRenewAppID);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionApplicationDate);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionIssueDate);
            this.gbApplicationInfo.Controls.Add(this.lblIssueDate);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionApplicationFees);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionLicenseFees);
            this.gbApplicationInfo.Controls.Add(this.lblLicenseFees);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionRenewedLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lblRenewedLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionOldLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lblOldLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionExpirationDate);
            this.gbApplicationInfo.Controls.Add(this.lblExpirationDate);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionCreatedBy);
            this.gbApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionTotalFees);
            this.gbApplicationInfo.Controls.Add(this.lblTotalFees);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionNotes);
            this.gbApplicationInfo.Controls.Add(this.txtNotes);
            this.gbApplicationInfo.Controls.Add(this.chkOldLicenseHandedIn);
            this.gbApplicationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbApplicationInfo.Location = new System.Drawing.Point(12, 435);
            this.gbApplicationInfo.Size = new System.Drawing.Size(900, 300);
            this.gbApplicationInfo.Text = "Application Info";
            this.gbApplicationInfo.Name = "gbApplicationInfo";
            this.gbApplicationInfo.TabIndex = 3;
            // 
            // lblCaptionRenewAppID
            // 
            this.lblCaptionRenewAppID.AutoSize = true;
            this.lblCaptionRenewAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionRenewAppID.Location = new System.Drawing.Point(15, 32);
            this.lblCaptionRenewAppID.Size = new System.Drawing.Size(110, 20);
            this.lblCaptionRenewAppID.Text = "R.L.App ID:";
            this.lblCaptionRenewAppID.Name = "lblCaptionRenewAppID";
            this.lblCaptionRenewAppID.TabIndex = 4;
            // 
            // lblRenewAppID
            // 
            this.lblRenewAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenewAppID.Location = new System.Drawing.Point(195, 32);
            this.lblRenewAppID.Size = new System.Drawing.Size(240, 20);
            this.lblRenewAppID.Text = "[????]";
            this.lblRenewAppID.Name = "lblRenewAppID";
            this.lblRenewAppID.TabIndex = 5;
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
            // lblCaptionApplicationFees
            // 
            this.lblCaptionApplicationFees.AutoSize = true;
            this.lblCaptionApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionApplicationFees.Location = new System.Drawing.Point(15, 134);
            this.lblCaptionApplicationFees.Size = new System.Drawing.Size(170, 20);
            this.lblCaptionApplicationFees.Text = "Application Fees:";
            this.lblCaptionApplicationFees.Name = "lblCaptionApplicationFees";
            this.lblCaptionApplicationFees.TabIndex = 10;
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(195, 134);
            this.lblApplicationFees.Size = new System.Drawing.Size(240, 20);
            this.lblApplicationFees.Text = "[????]";
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.TabIndex = 11;
            // 
            // lblCaptionLicenseFees
            // 
            this.lblCaptionLicenseFees.AutoSize = true;
            this.lblCaptionLicenseFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionLicenseFees.Location = new System.Drawing.Point(15, 168);
            this.lblCaptionLicenseFees.Size = new System.Drawing.Size(130, 20);
            this.lblCaptionLicenseFees.Text = "License Fees:";
            this.lblCaptionLicenseFees.Name = "lblCaptionLicenseFees";
            this.lblCaptionLicenseFees.TabIndex = 12;
            // 
            // lblLicenseFees
            // 
            this.lblLicenseFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseFees.Location = new System.Drawing.Point(195, 168);
            this.lblLicenseFees.Size = new System.Drawing.Size(240, 20);
            this.lblLicenseFees.Text = "[????]";
            this.lblLicenseFees.Name = "lblLicenseFees";
            this.lblLicenseFees.TabIndex = 13;
            // 
            // lblCaptionRenewedLicenseID
            // 
            this.lblCaptionRenewedLicenseID.AutoSize = true;
            this.lblCaptionRenewedLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionRenewedLicenseID.Location = new System.Drawing.Point(465, 32);
            this.lblCaptionRenewedLicenseID.Size = new System.Drawing.Size(190, 20);
            this.lblCaptionRenewedLicenseID.Text = "Renewed License ID:";
            this.lblCaptionRenewedLicenseID.Name = "lblCaptionRenewedLicenseID";
            this.lblCaptionRenewedLicenseID.TabIndex = 14;
            // 
            // lblRenewedLicenseID
            // 
            this.lblRenewedLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenewedLicenseID.Location = new System.Drawing.Point(645, 32);
            this.lblRenewedLicenseID.Size = new System.Drawing.Size(240, 20);
            this.lblRenewedLicenseID.Text = "[????]";
            this.lblRenewedLicenseID.Name = "lblRenewedLicenseID";
            this.lblRenewedLicenseID.TabIndex = 15;
            // 
            // lblCaptionOldLicenseID
            // 
            this.lblCaptionOldLicenseID.AutoSize = true;
            this.lblCaptionOldLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionOldLicenseID.Location = new System.Drawing.Point(465, 66);
            this.lblCaptionOldLicenseID.Size = new System.Drawing.Size(150, 20);
            this.lblCaptionOldLicenseID.Text = "Old License ID:";
            this.lblCaptionOldLicenseID.Name = "lblCaptionOldLicenseID";
            this.lblCaptionOldLicenseID.TabIndex = 16;
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenseID.Location = new System.Drawing.Point(645, 66);
            this.lblOldLicenseID.Size = new System.Drawing.Size(240, 20);
            this.lblOldLicenseID.Text = "[????]";
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.TabIndex = 17;
            // 
            // lblCaptionExpirationDate
            // 
            this.lblCaptionExpirationDate.AutoSize = true;
            this.lblCaptionExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionExpirationDate.Location = new System.Drawing.Point(465, 100);
            this.lblCaptionExpirationDate.Size = new System.Drawing.Size(160, 20);
            this.lblCaptionExpirationDate.Text = "Expiration Date:";
            this.lblCaptionExpirationDate.Name = "lblCaptionExpirationDate";
            this.lblCaptionExpirationDate.TabIndex = 18;
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpirationDate.Location = new System.Drawing.Point(645, 100);
            this.lblExpirationDate.Size = new System.Drawing.Size(240, 20);
            this.lblExpirationDate.Text = "[????]";
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.TabIndex = 19;
            // 
            // lblCaptionCreatedBy
            // 
            this.lblCaptionCreatedBy.AutoSize = true;
            this.lblCaptionCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionCreatedBy.Location = new System.Drawing.Point(465, 134);
            this.lblCaptionCreatedBy.Size = new System.Drawing.Size(110, 20);
            this.lblCaptionCreatedBy.Text = "Created By:";
            this.lblCaptionCreatedBy.Name = "lblCaptionCreatedBy";
            this.lblCaptionCreatedBy.TabIndex = 20;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(645, 134);
            this.lblCreatedBy.Size = new System.Drawing.Size(240, 20);
            this.lblCreatedBy.Text = "[????]";
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.TabIndex = 21;
            // 
            // lblCaptionTotalFees
            // 
            this.lblCaptionTotalFees.AutoSize = true;
            this.lblCaptionTotalFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionTotalFees.Location = new System.Drawing.Point(465, 168);
            this.lblCaptionTotalFees.Size = new System.Drawing.Size(110, 20);
            this.lblCaptionTotalFees.Text = "Total Fees:";
            this.lblCaptionTotalFees.Name = "lblCaptionTotalFees";
            this.lblCaptionTotalFees.TabIndex = 22;
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFees.Location = new System.Drawing.Point(645, 168);
            this.lblTotalFees.Size = new System.Drawing.Size(240, 20);
            this.lblTotalFees.Text = "[????]";
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.TabIndex = 23;
            // 
            // lblCaptionNotes
            // 
            this.lblCaptionNotes.AutoSize = true;
            this.lblCaptionNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionNotes.Location = new System.Drawing.Point(15, 202);
            this.lblCaptionNotes.Size = new System.Drawing.Size(60, 20);
            this.lblCaptionNotes.Text = "Notes:";
            this.lblCaptionNotes.Name = "lblCaptionNotes";
            this.lblCaptionNotes.TabIndex = 24;
            // 
            // txtNotes
            // 
            this.txtNotes.Multiline = true;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(195, 200);
            this.txtNotes.Size = new System.Drawing.Size(690, 50);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.TabIndex = 25;
            // 
            // chkOldLicenseHandedIn
            // 
            this.chkOldLicenseHandedIn.AutoSize = true;
            this.chkOldLicenseHandedIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOldLicenseHandedIn.Location = new System.Drawing.Point(15, 262);
            this.chkOldLicenseHandedIn.Size = new System.Drawing.Size(350, 24);
            this.chkOldLicenseHandedIn.Text = "Applicant handed in the old license";
            this.chkOldLicenseHandedIn.UseVisualStyleBackColor = true;
            this.chkOldLicenseHandedIn.Name = "chkOldLicenseHandedIn";
            this.chkOldLicenseHandedIn.TabIndex = 26;
            // 
            // llShowLicensesHistory
            // 
            this.llShowLicensesHistory.AutoSize = true;
            this.llShowLicensesHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicensesHistory.Location = new System.Drawing.Point(12, 757);
            this.llShowLicensesHistory.Size = new System.Drawing.Size(210, 20);
            this.llShowLicensesHistory.TabStop = true;
            this.llShowLicensesHistory.Text = "Show Licenses History";
            this.llShowLicensesHistory.Name = "llShowLicensesHistory";
            this.llShowLicensesHistory.TabIndex = 27;
            this.llShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicensesHistory_LinkClicked);
            // 
            // llShowNewLicenseInfo
            // 
            this.llShowNewLicenseInfo.AutoSize = true;
            this.llShowNewLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowNewLicenseInfo.Location = new System.Drawing.Point(240, 757);
            this.llShowNewLicenseInfo.Size = new System.Drawing.Size(210, 20);
            this.llShowNewLicenseInfo.TabStop = true;
            this.llShowNewLicenseInfo.Text = "Show New License Info";
            this.llShowNewLicenseInfo.Name = "llShowNewLicenseInfo";
            this.llShowNewLicenseInfo.TabIndex = 28;
            this.llShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowNewLicenseInfo_LinkClicked);
            // 
            // btnRenew
            // 
            this.btnRenew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRenew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenew.Image = global::UI.WinForms.Properties.Resources.reload;
            this.btnRenew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRenew.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnRenew.Location = new System.Drawing.Point(662, 747);
            this.btnRenew.Size = new System.Drawing.Size(120, 40);
            this.btnRenew.Text = "Renew";
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.TabIndex = 29;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::UI.WinForms.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnClose.Location = new System.Drawing.Point(792, 747);
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Name = "btnClose";
            this.btnClose.TabIndex = 30;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // RenewLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 845);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctrlLicenseFinder1);
            this.Controls.Add(this.gbApplicationInfo);
            this.Controls.Add(this.llShowLicensesHistory);
            this.Controls.Add(this.llShowNewLicenseInfo);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RenewLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Renew Local Driving License";
            this.Load += new System.EventHandler(this.RenewLicense_Load);
            this.gbApplicationInfo.ResumeLayout(false);
            this.gbApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private UI.WinForms.UserControls.ctrlLicenseFinder ctrlLicenseFinder1;
        private System.Windows.Forms.GroupBox gbApplicationInfo;
        private System.Windows.Forms.Label lblCaptionRenewAppID;
        private System.Windows.Forms.Label lblRenewAppID;
        private System.Windows.Forms.Label lblCaptionApplicationDate;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblCaptionIssueDate;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label lblCaptionApplicationFees;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblCaptionLicenseFees;
        private System.Windows.Forms.Label lblLicenseFees;
        private System.Windows.Forms.Label lblCaptionRenewedLicenseID;
        private System.Windows.Forms.Label lblRenewedLicenseID;
        private System.Windows.Forms.Label lblCaptionOldLicenseID;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblCaptionExpirationDate;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.Label lblCaptionCreatedBy;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblCaptionTotalFees;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label lblCaptionNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.CheckBox chkOldLicenseHandedIn;
        private System.Windows.Forms.LinkLabel llShowLicensesHistory;
        private System.Windows.Forms.LinkLabel llShowNewLicenseInfo;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.Button btnClose;
    }
}
