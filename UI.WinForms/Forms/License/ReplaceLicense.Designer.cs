namespace UI.WinForms.Forms.License
{
    partial class ReplaceLicense
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
            this.lblCaptionReplaceAppID = new System.Windows.Forms.Label();
            this.lblReplaceAppID = new System.Windows.Forms.Label();
            this.lblCaptionApplicationDate = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblCaptionApplicationFees = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblCaptionReplacementFees = new System.Windows.Forms.Label();
            this.lblReplacementFees = new System.Windows.Forms.Label();
            this.lblCaptionTotalFees = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.lblCaptionReplacedLicenseID = new System.Windows.Forms.Label();
            this.lblReplacedLicenseID = new System.Windows.Forms.Label();
            this.lblCaptionOldLicenseID = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblCaptionCreatedBy = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.rbDamaged = new System.Windows.Forms.RadioButton();
            this.rbLost = new System.Windows.Forms.RadioButton();
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
            this.lblTitle.Text = "Replacement for Damaged / Lost License";
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
            this.gbApplicationInfo.Controls.Add(this.lblCaptionReplaceAppID);
            this.gbApplicationInfo.Controls.Add(this.lblReplaceAppID);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionApplicationDate);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionApplicationFees);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionReplacementFees);
            this.gbApplicationInfo.Controls.Add(this.lblReplacementFees);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionTotalFees);
            this.gbApplicationInfo.Controls.Add(this.lblTotalFees);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionReplacedLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lblReplacedLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionOldLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lblOldLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lblCaptionCreatedBy);
            this.gbApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.gbApplicationInfo.Controls.Add(this.rbDamaged);
            this.gbApplicationInfo.Controls.Add(this.rbLost);
            this.gbApplicationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbApplicationInfo.Location = new System.Drawing.Point(12, 435);
            this.gbApplicationInfo.Size = new System.Drawing.Size(900, 210);
            this.gbApplicationInfo.Text = "Application Info";
            this.gbApplicationInfo.Name = "gbApplicationInfo";
            this.gbApplicationInfo.TabIndex = 3;
            // 
            // lblCaptionReplaceAppID
            // 
            this.lblCaptionReplaceAppID.AutoSize = true;
            this.lblCaptionReplaceAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionReplaceAppID.Location = new System.Drawing.Point(15, 32);
            this.lblCaptionReplaceAppID.Size = new System.Drawing.Size(110, 20);
            this.lblCaptionReplaceAppID.Text = "L.R.App ID:";
            this.lblCaptionReplaceAppID.Name = "lblCaptionReplaceAppID";
            this.lblCaptionReplaceAppID.TabIndex = 4;
            // 
            // lblReplaceAppID
            // 
            this.lblReplaceAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplaceAppID.Location = new System.Drawing.Point(195, 32);
            this.lblReplaceAppID.Size = new System.Drawing.Size(240, 20);
            this.lblReplaceAppID.Text = "[????]";
            this.lblReplaceAppID.Name = "lblReplaceAppID";
            this.lblReplaceAppID.TabIndex = 5;
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
            // lblCaptionApplicationFees
            // 
            this.lblCaptionApplicationFees.AutoSize = true;
            this.lblCaptionApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionApplicationFees.Location = new System.Drawing.Point(15, 100);
            this.lblCaptionApplicationFees.Size = new System.Drawing.Size(170, 20);
            this.lblCaptionApplicationFees.Text = "Application Fees:";
            this.lblCaptionApplicationFees.Name = "lblCaptionApplicationFees";
            this.lblCaptionApplicationFees.TabIndex = 8;
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(195, 100);
            this.lblApplicationFees.Size = new System.Drawing.Size(240, 20);
            this.lblApplicationFees.Text = "[????]";
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.TabIndex = 9;
            // 
            // lblCaptionReplacementFees
            // 
            this.lblCaptionReplacementFees.AutoSize = true;
            this.lblCaptionReplacementFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionReplacementFees.Location = new System.Drawing.Point(15, 134);
            this.lblCaptionReplacementFees.Size = new System.Drawing.Size(170, 20);
            this.lblCaptionReplacementFees.Text = "Replacement Fees:";
            this.lblCaptionReplacementFees.Name = "lblCaptionReplacementFees";
            this.lblCaptionReplacementFees.TabIndex = 10;
            // 
            // lblReplacementFees
            // 
            this.lblReplacementFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplacementFees.Location = new System.Drawing.Point(195, 134);
            this.lblReplacementFees.Size = new System.Drawing.Size(240, 20);
            this.lblReplacementFees.Text = "[????]";
            this.lblReplacementFees.Name = "lblReplacementFees";
            this.lblReplacementFees.TabIndex = 11;
            // 
            // lblCaptionTotalFees
            // 
            this.lblCaptionTotalFees.AutoSize = true;
            this.lblCaptionTotalFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionTotalFees.Location = new System.Drawing.Point(465, 32);
            this.lblCaptionTotalFees.Size = new System.Drawing.Size(110, 20);
            this.lblCaptionTotalFees.Text = "Total Fees:";
            this.lblCaptionTotalFees.Name = "lblCaptionTotalFees";
            this.lblCaptionTotalFees.TabIndex = 12;
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFees.Location = new System.Drawing.Point(645, 32);
            this.lblTotalFees.Size = new System.Drawing.Size(240, 20);
            this.lblTotalFees.Text = "[????]";
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.TabIndex = 13;
            // 
            // lblCaptionReplacedLicenseID
            // 
            this.lblCaptionReplacedLicenseID.AutoSize = true;
            this.lblCaptionReplacedLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionReplacedLicenseID.Location = new System.Drawing.Point(465, 66);
            this.lblCaptionReplacedLicenseID.Size = new System.Drawing.Size(200, 20);
            this.lblCaptionReplacedLicenseID.Text = "Replaced License ID:";
            this.lblCaptionReplacedLicenseID.Name = "lblCaptionReplacedLicenseID";
            this.lblCaptionReplacedLicenseID.TabIndex = 14;
            // 
            // lblReplacedLicenseID
            // 
            this.lblReplacedLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplacedLicenseID.Location = new System.Drawing.Point(645, 66);
            this.lblReplacedLicenseID.Size = new System.Drawing.Size(240, 20);
            this.lblReplacedLicenseID.Text = "[????]";
            this.lblReplacedLicenseID.Name = "lblReplacedLicenseID";
            this.lblReplacedLicenseID.TabIndex = 15;
            // 
            // lblCaptionOldLicenseID
            // 
            this.lblCaptionOldLicenseID.AutoSize = true;
            this.lblCaptionOldLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionOldLicenseID.Location = new System.Drawing.Point(465, 100);
            this.lblCaptionOldLicenseID.Size = new System.Drawing.Size(150, 20);
            this.lblCaptionOldLicenseID.Text = "Old License ID:";
            this.lblCaptionOldLicenseID.Name = "lblCaptionOldLicenseID";
            this.lblCaptionOldLicenseID.TabIndex = 16;
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenseID.Location = new System.Drawing.Point(645, 100);
            this.lblOldLicenseID.Size = new System.Drawing.Size(240, 20);
            this.lblOldLicenseID.Text = "[????]";
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.TabIndex = 17;
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
            // rbDamaged
            // 
            this.rbDamaged.AutoSize = true;
            this.rbDamaged.Checked = true;
            this.rbDamaged.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDamaged.Location = new System.Drawing.Point(15, 168);
            this.rbDamaged.Size = new System.Drawing.Size(150, 24);
            this.rbDamaged.Text = "Damaged License";
            this.rbDamaged.UseVisualStyleBackColor = true;
            this.rbDamaged.Name = "rbDamaged";
            this.rbDamaged.TabIndex = 20;
            this.rbDamaged.CheckedChanged += new System.EventHandler(this.rbReplacementType_CheckedChanged);
            // 
            // rbLost
            // 
            this.rbLost.AutoSize = true;
            this.rbLost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLost.Location = new System.Drawing.Point(250, 168);
            this.rbLost.Size = new System.Drawing.Size(120, 24);
            this.rbLost.Text = "Lost License";
            this.rbLost.UseVisualStyleBackColor = true;
            this.rbLost.Name = "rbLost";
            this.rbLost.TabIndex = 21;
            this.rbLost.CheckedChanged += new System.EventHandler(this.rbReplacementType_CheckedChanged);
            // 
            // llShowLicensesHistory
            // 
            this.llShowLicensesHistory.AutoSize = true;
            this.llShowLicensesHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicensesHistory.Location = new System.Drawing.Point(12, 667);
            this.llShowLicensesHistory.Size = new System.Drawing.Size(210, 20);
            this.llShowLicensesHistory.TabStop = true;
            this.llShowLicensesHistory.Text = "Show Licenses History";
            this.llShowLicensesHistory.Name = "llShowLicensesHistory";
            this.llShowLicensesHistory.TabIndex = 22;
            this.llShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicensesHistory_LinkClicked);
            // 
            // llShowNewLicenseInfo
            // 
            this.llShowNewLicenseInfo.AutoSize = true;
            this.llShowNewLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowNewLicenseInfo.Location = new System.Drawing.Point(240, 667);
            this.llShowNewLicenseInfo.Size = new System.Drawing.Size(210, 20);
            this.llShowNewLicenseInfo.TabStop = true;
            this.llShowNewLicenseInfo.Text = "Show New License Info";
            this.llShowNewLicenseInfo.Name = "llShowNewLicenseInfo";
            this.llShowNewLicenseInfo.TabIndex = 23;
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
            this.btnIssue.Location = new System.Drawing.Point(662, 657);
            this.btnIssue.Size = new System.Drawing.Size(120, 40);
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.TabIndex = 24;
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
            this.btnClose.Location = new System.Drawing.Point(792, 657);
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Name = "btnClose";
            this.btnClose.TabIndex = 25;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ReplaceLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 755);
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
            this.Name = "ReplaceLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replacement for Damaged / Lost License";
            this.Load += new System.EventHandler(this.ReplaceLicense_Load);
            this.gbApplicationInfo.ResumeLayout(false);
            this.gbApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private UI.WinForms.UserControls.ctrlLicenseFinder ctrlLicenseFinder1;
        private System.Windows.Forms.GroupBox gbApplicationInfo;
        private System.Windows.Forms.Label lblCaptionReplaceAppID;
        private System.Windows.Forms.Label lblReplaceAppID;
        private System.Windows.Forms.Label lblCaptionApplicationDate;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblCaptionApplicationFees;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblCaptionReplacementFees;
        private System.Windows.Forms.Label lblReplacementFees;
        private System.Windows.Forms.Label lblCaptionTotalFees;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label lblCaptionReplacedLicenseID;
        private System.Windows.Forms.Label lblReplacedLicenseID;
        private System.Windows.Forms.Label lblCaptionOldLicenseID;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblCaptionCreatedBy;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.RadioButton rbDamaged;
        private System.Windows.Forms.RadioButton rbLost;
        private System.Windows.Forms.LinkLabel llShowLicensesHistory;
        private System.Windows.Forms.LinkLabel llShowNewLicenseInfo;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Button btnClose;
    }
}
