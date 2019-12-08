namespace TimeManagementAndReportingTool
{
    partial class EventDetailView
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
            this.TypeLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.RecurringLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteEventButton = new System.Windows.Forms.Button();
            this.ContactsLB = new System.Windows.Forms.ListBox();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold);
            this.TypeLabel.Location = new System.Drawing.Point(301, 47);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(64, 29);
            this.TypeLabel.TabIndex = 0;
            this.TypeLabel.Text = "TYPE";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(201, 90);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(52, 24);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "label2";
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.DateLabel.Location = new System.Drawing.Point(201, 125);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(52, 24);
            this.DateLabel.TabIndex = 2;
            this.DateLabel.Text = "label3";
            // 
            // RecurringLabel
            // 
            this.RecurringLabel.AutoSize = true;
            this.RecurringLabel.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.RecurringLabel.Location = new System.Drawing.Point(201, 160);
            this.RecurringLabel.Name = "RecurringLabel";
            this.RecurringLabel.Size = new System.Drawing.Size(52, 24);
            this.RecurringLabel.TabIndex = 3;
            this.RecurringLabel.Text = "label4";
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.CloseButton.Location = new System.Drawing.Point(598, 360);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 31);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.EditButton.Location = new System.Drawing.Point(598, 323);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 31);
            this.EditButton.TabIndex = 5;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteEventButton
            // 
            this.DeleteEventButton.Font = new System.Drawing.Font("Arial Narrow", 12F);
            this.DeleteEventButton.Location = new System.Drawing.Point(598, 286);
            this.DeleteEventButton.Name = "DeleteEventButton";
            this.DeleteEventButton.Size = new System.Drawing.Size(75, 31);
            this.DeleteEventButton.TabIndex = 6;
            this.DeleteEventButton.Text = "Delete";
            this.DeleteEventButton.UseVisualStyleBackColor = true;
            this.DeleteEventButton.Click += new System.EventHandler(this.DeleteEventButton_Click);
            // 
            // ContactsLB
            // 
            this.ContactsLB.FormattingEnabled = true;
            this.ContactsLB.ItemHeight = 16;
            this.ContactsLB.Location = new System.Drawing.Point(20, 306);
            this.ContactsLB.Name = "ContactsLB";
            this.ContactsLB.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.ContactsLB.Size = new System.Drawing.Size(233, 116);
            this.ContactsLB.TabIndex = 7;
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(310, 313);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(89, 17);
            this.LocationLabel.TabIndex = 8;
            this.LocationLabel.Text = "Location info";
            // 
            // EventDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 450);
            this.Controls.Add(this.LocationLabel);
            this.Controls.Add(this.ContactsLB);
            this.Controls.Add(this.DeleteEventButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.RecurringLabel);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.TypeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EventDetailView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label RecurringLabel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteEventButton;
        private System.Windows.Forms.ListBox ContactsLB;
        private System.Windows.Forms.Label LocationLabel;
    }
}