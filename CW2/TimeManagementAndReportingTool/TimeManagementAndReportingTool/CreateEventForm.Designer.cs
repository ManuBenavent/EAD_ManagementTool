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
            this.DeleteButton = new System.Windows.Forms.Button();
            this.DismissButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
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
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(221, 341);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(89, 41);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // DismissButton
            // 
            this.DismissButton.Location = new System.Drawing.Point(332, 341);
            this.DismissButton.Name = "DismissButton";
            this.DismissButton.Size = new System.Drawing.Size(89, 41);
            this.DismissButton.TabIndex = 3;
            this.DismissButton.Text = "Dismiss";
            this.DismissButton.UseVisualStyleBackColor = true;
            this.DismissButton.Click += new System.EventHandler(this.DismissButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(452, 341);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(89, 41);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CreateEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DismissButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EventTypeTitleLabel);
            this.Controls.Add(this.EventTypesComboBox);
            this.Name = "CreateEventForm";
            this.Text = "CreateEventForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox EventTypesComboBox;
        private System.Windows.Forms.Label EventTypeTitleLabel;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button DismissButton;
        private System.Windows.Forms.Button SaveButton;
    }
}