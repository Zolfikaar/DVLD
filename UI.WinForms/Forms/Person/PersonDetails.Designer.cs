namespace UI.WinForms.Forms.Person
{
    partial class PersonDetails
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.ctrlPersonCard1 = new UI.WinForms.UserControls.ctrlPersonCard();
            this.SuspendLayout();
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPersonCard1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            this.ctrlPersonCard1.Size = new System.Drawing.Size(673, 584);
            this.ctrlPersonCard1.TabIndex = 0;
            this.ctrlPersonCard1.OnEditClicked += new System.EventHandler(this.ctrlPersonCard1_OnEditClicked);
            // 
            // PersonDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 584);
            this.Controls.Add(this.ctrlPersonCard1);
            this.Name = "PersonDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Person Details";
            this.Shown += new System.EventHandler(this.PersonDetailsForm_Shown);
            this.ResumeLayout(false);
        }

        #endregion

        private UI.WinForms.UserControls.ctrlPersonCard ctrlPersonCard1;
    }
}
