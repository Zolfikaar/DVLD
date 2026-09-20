namespace UI.WinForms.Forms.User
{
    partial class UserDetailsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.ctrlPersonCard1 = new UI.WinForms.UserControls.ctrlPersonCard();
            this.gbUserInfo = new System.Windows.Forms.GroupBox();
            this.lblIsActiveValue = new System.Windows.Forms.Label();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.lblUsernameValue = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblUserIdValue = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbUserInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlPersonCard1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(673, 500);
            this.ctrlPersonCard1.TabIndex = 0;
            this.ctrlPersonCard1.OnEditClicked += new System.EventHandler(this.ctrlPersonCard1_OnEditClicked);
            // 
            // gbUserInfo
            // 
            this.gbUserInfo.Controls.Add(this.btnClose);
            this.gbUserInfo.Controls.Add(this.lblIsActiveValue);
            this.gbUserInfo.Controls.Add(this.lblIsActive);
            this.gbUserInfo.Controls.Add(this.lblUsernameValue);
            this.gbUserInfo.Controls.Add(this.lblUsername);
            this.gbUserInfo.Controls.Add(this.lblUserIdValue);
            this.gbUserInfo.Controls.Add(this.lblUserId);
            this.gbUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbUserInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.gbUserInfo.Location = new System.Drawing.Point(0, 500);
            this.gbUserInfo.Name = "gbUserInfo";
            this.gbUserInfo.Size = new System.Drawing.Size(673, 140);
            this.gbUserInfo.TabIndex = 1;
            this.gbUserInfo.TabStop = false;
            this.gbUserInfo.Text = "User Information";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(28, 32);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(60, 20);
            this.lblUserId.TabIndex = 0;
            this.lblUserId.Text = "User ID";
            // 
            // lblUserIdValue
            // 
            this.lblUserIdValue.AutoSize = true;
            this.lblUserIdValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUserIdValue.Location = new System.Drawing.Point(180, 32);
            this.lblUserIdValue.Name = "lblUserIdValue";
            this.lblUserIdValue.Size = new System.Drawing.Size(25, 20);
            this.lblUserIdValue.TabIndex = 1;
            this.lblUserIdValue.Text = "???";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(28, 62);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(81, 20);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username";
            // 
            // lblUsernameValue
            // 
            this.lblUsernameValue.AutoSize = true;
            this.lblUsernameValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsernameValue.Location = new System.Drawing.Point(180, 62);
            this.lblUsernameValue.Name = "lblUsernameValue";
            this.lblUsernameValue.Size = new System.Drawing.Size(25, 20);
            this.lblUsernameValue.TabIndex = 3;
            this.lblUsernameValue.Text = "???";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Location = new System.Drawing.Point(28, 92);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(70, 20);
            this.lblIsActive.TabIndex = 4;
            this.lblIsActive.Text = "Is Active";
            // 
            // lblIsActiveValue
            // 
            this.lblIsActiveValue.AutoSize = true;
            this.lblIsActiveValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIsActiveValue.Location = new System.Drawing.Point(180, 92);
            this.lblIsActiveValue.Name = "lblIsActiveValue";
            this.lblIsActiveValue.Size = new System.Drawing.Size(25, 20);
            this.lblIsActiveValue.TabIndex = 5;
            this.lblIsActiveValue.Text = "???";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(531, 88);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // UserDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 640);
            this.Controls.Add(this.gbUserInfo);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Name = "UserDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Details";
            this.Shown += new System.EventHandler(this.UserDetailsForm_Shown);
            this.gbUserInfo.ResumeLayout(false);
            this.gbUserInfo.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private UI.WinForms.UserControls.ctrlPersonCard ctrlPersonCard1;
        private System.Windows.Forms.GroupBox gbUserInfo;
        private System.Windows.Forms.Label lblIsActiveValue;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label lblUsernameValue;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblUserIdValue;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Button btnClose;
    }
}
