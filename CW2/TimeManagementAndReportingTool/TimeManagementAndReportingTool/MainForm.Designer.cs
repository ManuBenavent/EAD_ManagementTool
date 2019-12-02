﻿namespace TimeManagementAndReportingTool
{
    partial class MainForm
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
            this.NewEventButton = new System.Windows.Forms.Button();
            this.NewContactButton = new System.Windows.Forms.Button();
            this.ListContactsButton = new System.Windows.Forms.Button();
            this.TimeReportButton = new System.Windows.Forms.Button();
            this.ChangeViewButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewEventButton
            // 
            this.NewEventButton.Location = new System.Drawing.Point(829, 30);
            this.NewEventButton.Name = "NewEventButton";
            this.NewEventButton.Size = new System.Drawing.Size(155, 41);
            this.NewEventButton.TabIndex = 0;
            this.NewEventButton.Text = "New Event";
            this.NewEventButton.UseVisualStyleBackColor = true;
            this.NewEventButton.Click += new System.EventHandler(this.NewEventButton_Click);
            // 
            // NewContactButton
            // 
            this.NewContactButton.Location = new System.Drawing.Point(829, 77);
            this.NewContactButton.Name = "NewContactButton";
            this.NewContactButton.Size = new System.Drawing.Size(155, 41);
            this.NewContactButton.TabIndex = 1;
            this.NewContactButton.Text = "New Contact";
            this.NewContactButton.UseVisualStyleBackColor = true;
            this.NewContactButton.Click += new System.EventHandler(this.NewContactButton_Click);
            // 
            // ListContactsButton
            // 
            this.ListContactsButton.Location = new System.Drawing.Point(829, 124);
            this.ListContactsButton.Name = "ListContactsButton";
            this.ListContactsButton.Size = new System.Drawing.Size(155, 41);
            this.ListContactsButton.TabIndex = 2;
            this.ListContactsButton.Text = "Show Contacts";
            this.ListContactsButton.UseVisualStyleBackColor = true;
            this.ListContactsButton.Click += new System.EventHandler(this.ListContactsButton_Click);
            // 
            // TimeReportButton
            // 
            this.TimeReportButton.Location = new System.Drawing.Point(829, 171);
            this.TimeReportButton.Name = "TimeReportButton";
            this.TimeReportButton.Size = new System.Drawing.Size(155, 41);
            this.TimeReportButton.TabIndex = 3;
            this.TimeReportButton.Text = "Time Usage Report";
            this.TimeReportButton.UseVisualStyleBackColor = true;
            this.TimeReportButton.Click += new System.EventHandler(this.TimeReportButton_Click);
            // 
            // ChangeViewButton
            // 
            this.ChangeViewButton.Location = new System.Drawing.Point(829, 218);
            this.ChangeViewButton.Name = "ChangeViewButton";
            this.ChangeViewButton.Size = new System.Drawing.Size(155, 41);
            this.ChangeViewButton.TabIndex = 4;
            this.ChangeViewButton.Text = "Change View";
            this.ChangeViewButton.UseVisualStyleBackColor = true;
            this.ChangeViewButton.Click += new System.EventHandler(this.ChangeViewButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 539);
            this.Controls.Add(this.ChangeViewButton);
            this.Controls.Add(this.TimeReportButton);
            this.Controls.Add(this.ListContactsButton);
            this.Controls.Add(this.NewContactButton);
            this.Controls.Add(this.NewEventButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewEventButton;
        private System.Windows.Forms.Button NewContactButton;
        private System.Windows.Forms.Button ListContactsButton;
        private System.Windows.Forms.Button TimeReportButton;
        private System.Windows.Forms.Button ChangeViewButton;
    }
}