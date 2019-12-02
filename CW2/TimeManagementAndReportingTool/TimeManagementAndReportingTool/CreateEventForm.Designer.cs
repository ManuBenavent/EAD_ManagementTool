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
            this.SuspendLayout();
            // 
            // EventTypesComboBox
            // 
            this.EventTypesComboBox.FormattingEnabled = true;
            this.EventTypesComboBox.Location = new System.Drawing.Point(240, 31);
            this.EventTypesComboBox.Name = "EventTypesComboBox";
            this.EventTypesComboBox.Size = new System.Drawing.Size(247, 24);
            this.EventTypesComboBox.TabIndex = 0;
            // 
            // EventTypeTitleLabel
            // 
            this.EventTypeTitleLabel.AutoSize = true;
            this.EventTypeTitleLabel.Location = new System.Drawing.Point(93, 34);
            this.EventTypeTitleLabel.Name = "EventTypeTitleLabel";
            this.EventTypeTitleLabel.Size = new System.Drawing.Size(121, 17);
            this.EventTypeTitleLabel.TabIndex = 1;
            this.EventTypeTitleLabel.Text = "Select event type:";
            // 
            // CreateEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}