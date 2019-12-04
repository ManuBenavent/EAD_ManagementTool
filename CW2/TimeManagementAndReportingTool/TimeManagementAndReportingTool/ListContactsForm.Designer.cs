namespace TimeManagementAndReportingTool
{
    partial class ListContactsForm
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
            this.ContactsDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ContactsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ContactsDataGrid
            // 
            this.ContactsDataGrid.AllowUserToAddRows = false;
            this.ContactsDataGrid.AllowUserToDeleteRows = false;
            this.ContactsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ContactsDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContactsDataGrid.Location = new System.Drawing.Point(0, 0);
            this.ContactsDataGrid.Name = "ContactsDataGrid";
            this.ContactsDataGrid.ReadOnly = true;
            this.ContactsDataGrid.RowHeadersWidth = 51;
            this.ContactsDataGrid.RowTemplate.Height = 24;
            this.ContactsDataGrid.Size = new System.Drawing.Size(674, 450);
            this.ContactsDataGrid.TabIndex = 0;
            // 
            // ListContactsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 450);
            this.Controls.Add(this.ContactsDataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ListContactsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contacts List";
            ((System.ComponentModel.ISupportInitialize)(this.ContactsDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ContactsDataGrid;
    }
}