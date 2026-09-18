namespace UI.WinForms.Forms.Person
{
    partial class AddEditForm
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
            this.ctrlAddEditPerson1 = new UI.WinForms.UserControls.ctrlAddEditPerson();
            this.SuspendLayout();
            // 
            // ctrlAddEditPerson1
            // 
            this.ctrlAddEditPerson1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditPerson1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditPerson1.Name = "ctrlAddEditPerson1";
            this.ctrlAddEditPerson1.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            this.ctrlAddEditPerson1.Size = new System.Drawing.Size(761, 738);
            this.ctrlAddEditPerson1.TabIndex = 0;
            // 
            // AddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 738);
            this.Controls.Add(this.ctrlAddEditPerson1);
            this.Name = "AddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddEdit";
            this.Load += new System.EventHandler(this.AddEdit_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private UI.WinForms.UserControls.ctrlAddEditPerson ctrlAddEditPerson1;
    }
}
