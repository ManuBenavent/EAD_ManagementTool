namespace TimeManagementAndReportingTool
{
    partial class CreateEventForm
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
            this.EventTypesComboBox = new System.Windows.Forms.ComboBox();
            this.EventTypeTitleLabel = new System.Windows.Forms.Label();
            this.DismissButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.AddLocationButton = new System.Windows.Forms.Button();
            this.NewContactButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ContactsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // EventTypesComboBox
            // 
            this.EventTypesComboBox.FormattingEnabled = true;
            this.EventTypesComboBox.Location = new System.Drawing.Point(254, 31);
            this.EventTypesComboBox.Name = "EventTypesComboBox";
            this.EventTypesComboBox.Size = new System.Drawing.Size(247, 24);
            this.EventTypesComboBox.TabIndex = 0;
            // 
            // EventTypeTitleLabel
            // 
            this.EventTypeTitleLabel.AutoSize = true;
            this.EventTypeTitleLabel.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.EventTypeTitleLabel.Location = new System.Drawing.Point(91, 28);
            this.EventTypeTitleLabel.Name = "EventTypeTitleLabel";
            this.EventTypeTitleLabel.Size = new System.Drawing.Size(143, 24);
            this.EventTypeTitleLabel.TabIndex = 1;
            this.EventTypeTitleLabel.Text = "Select event type:";
            // 
            // DismissButton
            // 
            this.DismissButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.DismissButton.Location = new System.Drawing.Point(664, 271);
            this.DismissButton.Name = "DismissButton";
            this.DismissButton.Size = new System.Drawing.Size(120, 67);
            this.DismissButton.TabIndex = 3;
            this.DismissButton.Text = "Dismiss";
            this.DismissButton.UseVisualStyleBackColor = true;
            this.DismissButton.Click += new System.EventHandler(this.DismissButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.SaveButton.Location = new System.Drawing.Point(664, 344);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(122, 78);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(181, 271);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(462, 24);
            this.ErrorLabel.TabIndex = 5;
            this.ErrorLabel.Text = "Input data error. Please review you input and try again.";
            this.ErrorLabel.Visible = false;
            // 
            // AddLocationButton
            // 
            this.AddLocationButton.Location = new System.Drawing.Point(330, 298);
            this.AddLocationButton.Name = "AddLocationButton";
            this.AddLocationButton.Size = new System.Drawing.Size(89, 58);
            this.AddLocationButton.TabIndex = 6;
            this.AddLocationButton.Text = "Add Location";
            this.AddLocationButton.UseVisualStyleBackColor = true;
            this.AddLocationButton.Click += new System.EventHandler(this.AddLocationButton_Click);
            // 
            // NewContactButton
            // 
            this.NewContactButton.Location = new System.Drawing.Point(330, 372);
            this.NewContactButton.Name = "NewContactButton";
            this.NewContactButton.Size = new System.Drawing.Size(89, 58);
            this.NewContactButton.TabIndex = 7;
            this.NewContactButton.Text = "New Contact";
            this.NewContactButton.UseVisualStyleBackColor = true;
            this.NewContactButton.Click += new System.EventHandler(this.NewContactButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.label1.Location = new System.Drawing.Point(12, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select contacts:";
            // 
            // ContactsListBox
            // 
            this.ContactsListBox.FormattingEnabled = true;
            this.ContactsListBox.ItemHeight = 16;
            this.ContactsListBox.Location = new System.Drawing.Point(16, 298);
            this.ContactsListBox.Name = "ContactsListBox";
            this.ContactsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ContactsListBox.Size = new System.Drawing.Size(308, 132);
            this.ContactsListBox.TabIndex = 10;
            // 
            // CreateEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ContactsListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NewContactButton);
            this.Controls.Add(this.AddLocationButton);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DismissButton);
            this.Controls.Add(this.EventTypeTitleLabel);
            this.Controls.Add(this.EventTypesComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CreateEventForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Event";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox EventTypesComboBox;
        private System.Windows.Forms.Label EventTypeTitleLabel;
        private System.Windows.Forms.Button DismissButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Button AddLocationButton;
        private System.Windows.Forms.Button NewContactButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox ContactsListBox;
    }
}