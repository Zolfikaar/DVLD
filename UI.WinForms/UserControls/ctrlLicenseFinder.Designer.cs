namespace UI.WinForms.UserControls
{
    partial class ctrlLicenseFinder
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.lblFindBy = new System.Windows.Forms.Label();
            this.cbFindBy = new System.Windows.Forms.ComboBox();
            this.txtFindValue = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.ctrlLicenseCard1 = new UI.WinForms.UserControls.ctrlLicenseCard();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.lblFindBy);
            this.gbFilter.Controls.Add(this.cbFindBy);
            this.gbFilter.Controls.Add(this.txtFindValue);
            this.gbFilter.Controls.Add(this.btnFind);
            this.gbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(0, 0);
            this.gbFilter.Size = new System.Drawing.Size(895, 75);
            this.gbFilter.Text = "Filter";
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.TabIndex = 1;
            // 
            // lblFindBy
            // 
            this.lblFindBy.AutoSize = true;
            this.lblFindBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFindBy.Location = new System.Drawing.Point(15, 33);
            this.lblFindBy.Size = new System.Drawing.Size(80, 20);
            this.lblFindBy.Text = "Find By:";
            this.lblFindBy.Name = "lblFindBy";
            this.lblFindBy.TabIndex = 2;
            // 
            // cbFindBy
            // 
            this.cbFindBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFindBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFindBy.FormattingEnabled = true;
            this.cbFindBy.Location = new System.Drawing.Point(100, 30);
            this.cbFindBy.Size = new System.Drawing.Size(150, 28);
            this.cbFindBy.Name = "cbFindBy";
            this.cbFindBy.TabIndex = 3;
            this.cbFindBy.SelectedIndexChanged += new System.EventHandler(this.cbFindBy_SelectedIndexChanged);
            // 
            // txtFindValue
            // 
            this.txtFindValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFindValue.Location = new System.Drawing.Point(265, 30);
            this.txtFindValue.Size = new System.Drawing.Size(220, 27);
            this.txtFindValue.Name = "txtFindValue";
            this.txtFindValue.TabIndex = 4;
            this.txtFindValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFindValue_KeyDown);
            // 
            // btnFind
            // 
            this.btnFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Image = global::UI.WinForms.Properties.Resources.icons8_search_24;
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFind.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnFind.Location = new System.Drawing.Point(500, 25);
            this.btnFind.Size = new System.Drawing.Size(110, 38);
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Name = "btnFind";
            this.btnFind.TabIndex = 5;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // ctrlLicenseCard1
            // 
            this.ctrlLicenseCard1.Location = new System.Drawing.Point(0, 82);
            this.ctrlLicenseCard1.Size = new System.Drawing.Size(900, 290);
            this.ctrlLicenseCard1.Name = "ctrlLicenseCard1";
            this.ctrlLicenseCard1.TabIndex = 6;
            // 
            // ctrlLicenseFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(900, 375);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.ctrlLicenseCard1);
            this.Name = "ctrlLicenseFinder";
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label lblFindBy;
        private System.Windows.Forms.ComboBox cbFindBy;
        private System.Windows.Forms.TextBox txtFindValue;
        private System.Windows.Forms.Button btnFind;
        private UI.WinForms.UserControls.ctrlLicenseCard ctrlLicenseCard1;
    }
}
