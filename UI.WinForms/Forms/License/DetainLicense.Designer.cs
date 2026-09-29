namespace UI.WinForms.Forms.License
{
    partial class DetainLicense
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
            this.lblCaptionFineFees = new System.Windows.Forms.Label();
            this.txtFineFees = new System.Windows.Forms.TextBox();
            this.llShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.llShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.btnDetain = new System.Windows.Forms.Button();
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
            this.lblTitle.Text = "Detain License";
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
            this.gbApplicationInfo.Controls.Add(this.lblCaptionFineFees);
            this.gbApplicationInfo.Controls.Add(this.txtFineFees);
            this.gbApplicationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbApplicationInfo.Location = new System.Drawing.Point(12, 435);
            this.gbApplicationInfo.Size = new System.Drawing.Size(900, 110);
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
            this.lblCaptionLicenseID.Location = new System.Drawing.Point(465, 32);
            this.lblCaptionLicenseID.Size = new System.Drawing.Size(110, 20);
            this.lblCaptionLicenseID.Text = "License ID:";
            this.lblCaptionLicenseID.Name = "lblCaptionLicenseID";
            this.lblCaptionLicenseID.TabIndex = 8;
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseID.Location = new System.Drawing.Point(645, 32);
            this.lblLicenseID.Size = new System.Drawing.Size(240, 20);
            this.lblLicenseID.Text = "[????]";
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.TabIndex = 9;
            // 
            // lblCaptionCreatedBy
            // 
            this.lblCaptionCreatedBy.AutoSize = true;
            this.lblCaptionCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionCreatedBy.Location = new System.Drawing.Point(465, 66);
            this.lblCaptionCreatedBy.Size = new System.Drawing.Size(110, 20);
            this.lblCaptionCreatedBy.Text = "Created By:";
            this.lblCaptionCreatedBy.Name = "lblCaptionCreatedBy";
            this.lblCaptionCreatedBy.TabIndex = 10;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(645, 66);
            this.lblCreatedBy.Size = new System.Drawing.Size(240, 20);
            this.lblCreatedBy.Text = "[????]";
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.TabIndex = 11;
            // 
            // lblCaptionFineFees
            // 
            this.lblCaptionFineFees.AutoSize = true;
            this.lblCaptionFineFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaptionFineFees.Location = new System.Drawing.Point(465, 100);
            this.lblCaptionFineFees.Size = new System.Drawing.Size(100, 20);
            this.lblCaptionFineFees.Text = "Fine Fees:";
            this.lblCaptionFineFees.Name = "lblCaptionFineFees";
            this.lblCaptionFineFees.TabIndex = 12;
            // 
            // txtFineFees
            // 
            this.txtFineFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFineFees.Location = new System.Drawing.Point(645, 97);
            this.txtFineFees.Size = new System.Drawing.Size(160, 27);
            this.txtFineFees.Name = "txtFineFees";
            this.txtFineFees.TabIndex = 13;
            // 
            // llShowLicensesHistory
            // 
            this.llShowLicensesHistory.AutoSize = true;
            this.llShowLicensesHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicensesHistory.Location = new System.Drawing.Point(12, 567);
            this.llShowLicensesHistory.Size = new System.Drawing.Size(210, 20);
            this.llShowLicensesHistory.TabStop = true;
            this.llShowLicensesHistory.Text = "Show Licenses History";
            this.llShowLicensesHistory.Name = "llShowLicensesHistory";
            this.llShowLicensesHistory.TabIndex = 14;
            this.llShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicensesHistory_LinkClicked);
            // 
            // llShowNewLicenseInfo
            // 
            this.llShowNewLicenseInfo.AutoSize = true;
            this.llShowNewLicenseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowNewLicenseInfo.Location = new System.Drawing.Point(240, 567);
            this.llShowNewLicenseInfo.Size = new System.Drawing.Size(210, 20);
            this.llShowNewLicenseInfo.TabStop = true;
            this.llShowNewLicenseInfo.Text = "Show New License Info";
            this.llShowNewLicenseInfo.Name = "llShowNewLicenseInfo";
            this.llShowNewLicenseInfo.TabIndex = 15;
            this.llShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowNewLicenseInfo_LinkClicked);
            // 
            // btnDetain
            // 
            this.btnDetain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetain.Image = global::UI.WinForms.Properties.Resources.icons8_taxi_license_32;
            this.btnDetain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetain.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnDetain.Location = new System.Drawing.Point(662, 557);
            this.btnDetain.Size = new System.Drawing.Size(120, 40);
            this.btnDetain.Text = "Detain";
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.TabIndex = 16;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::UI.WinForms.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnClose.Location = new System.Drawing.Point(792, 557);
            this.btnClose.Size = new System.Drawing.Size(120, 40);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Name = "btnClose";
            this.btnClose.TabIndex = 17;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 655);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctrlLicenseFinder1);
            this.Controls.Add(this.gbApplicationInfo);
            this.Controls.Add(this.llShowLicensesHistory);
            this.Controls.Add(this.llShowNewLicenseInfo);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DetainLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detain License";
            this.Load += new System.EventHandler(this.DetainLicense_Load);
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
        private System.Windows.Forms.Label lblCaptionFineFees;
        private System.Windows.Forms.TextBox txtFineFees;
        private System.Windows.Forms.LinkLabel llShowLicensesHistory;
        private System.Windows.Forms.LinkLabel llShowNewLicenseInfo;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Button btnClose;
    }
}
