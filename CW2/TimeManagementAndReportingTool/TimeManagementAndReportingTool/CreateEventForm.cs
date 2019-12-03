﻿using library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeManagementAndReportingTool
{
    public partial class CreateEventForm : Form
    {
        List<Control> controls;

        public CreateEventForm()
        {
            controls = new List<Control>();
            InitializeComponent();
            EventTypesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            EventTypesComboBox.Items.Add("Appointment");
            EventTypesComboBox.Items.Add("Task");
            EventTypesComboBox.Items.Add("Lecture");
            EventTypesComboBox.Items.Add("Tutorial");
            EventTypesComboBox.SelectedIndexChanged += EventTypesComboBox_SelectedIndexChanged;
            EventTypesComboBox.SelectedIndex = 0;
            
            Label name = new Label();
            name.Text = "Event name:";
            name.Font = EventTypeTitleLabel.Font;
            name.Location = new Point(93, 60);
            this.Controls.Add(name);

            TextBox NameTextBox = new TextBox();
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Location = new Point(194, 63);
            NameTextBox.Width = 300;
            this.Controls.Add(NameTextBox);

            Label recurring = new Label();
            recurring.Text = "Recurring: ";
            recurring.Font = EventTypeTitleLabel.Font;
            recurring.Location = new Point(93, 90);
            this.Controls.Add(recurring);

            CheckBox recurringCB = new CheckBox();
            recurringCB.Name = "RecurringCB";
            recurringCB.Location = new Point(194, 90);
            this.Controls.Add(recurringCB);

            Label date = new Label();
            date.Text = "Date: ";
            date.Font = EventTypeTitleLabel.Font;
            date.Location = new Point(93, 120);
            this.Controls.Add(date);

            DateTimePicker dateTime = new DateTimePicker();
            dateTime.Name = "DateTimePicker";
            dateTime.Location = new Point(194, 123);
            dateTime.Width = 300;
            dateTime.Format = DateTimePickerFormat.Custom;
            dateTime.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.Controls.Add(dateTime);
        }

        private void EventTypesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(Control c in controls)
            {
                this.Controls.Remove(c);
            }
            
            if (EventTypesComboBox.SelectedIndex == 1)
            {
                Label finished = new Label();
                finished.Text = "Finished: ";
                finished.Location = new System.Drawing.Point(93, 150);
                finished.Font = EventTypeTitleLabel.Font;
                this.Controls.Add(finished);
                controls.Add(finished);

                CheckBox checkBox = new CheckBox();
                checkBox.Name = "FinishedCB";
                checkBox.Location = new Point(194, 150);
                this.Controls.Add(checkBox);
                controls.Add(checkBox);
            }
            if(EventTypesComboBox.SelectedIndex == 2 || EventTypesComboBox.SelectedIndex == 3)
            {
                Label lecturer = new Label();
                lecturer.Text = "Lecturer: ";
                lecturer.Location = new Point(93, 150);
                lecturer.Font = EventTypeTitleLabel.Font;
                this.Controls.Add(lecturer);
                controls.Add(lecturer);

                TextBox LectTB = new TextBox();
                LectTB.Location = new Point(194, 150);
                LectTB.Name = "LecturerTB";
                LectTB.Width = 300;
                this.Controls.Add(LectTB);
                controls.Add(LectTB);

                if (EventTypesComboBox.SelectedIndex == 3)
                {
                    Label lab = new Label();
                    lab.Text = "Lab: ";
                    lab.Font = EventTypeTitleLabel.Font;
                    lab.Location = new Point(93, 180);
                    this.Controls.Add(lab);
                    controls.Add(lab);

                    TextBox LabTB = new TextBox();
                    LabTB.Location = new Point(194, 180);
                    LabTB.Name = "LabTB";
                    LabTB.Width = 300;
                    this.Controls.Add(LabTB);
                    controls.Add(LabTB);
                }
            }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show("Do you want to delete this event?", "Delete confirmation", MessageBoxButtons.OKCancel);
            if (confirmation == DialogResult.OK)
            {
                ObtainData().Delete();
                this.Close();
            }
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ObtainData().Create();
            this.Close();
        }

        private EventClass ObtainData()
        {
            EventClass eventClass=null;
            string name = this.Controls.Find("NameTextBox", false)[0].Text;
            bool recurring = ((CheckBox)this.Controls.Find("RecurringCB", false)[0]).Checked;
            DateTime date = ((DateTimePicker)this.Controls.Find("DateTimePicker",false)[0]).Value;
            switch (EventTypesComboBox.SelectedIndex)
            {
                case 0:
                    eventClass = new Appointment(name, recurring, date);
                    break;
                case 1:
                    eventClass = new TaskEvent(name, recurring, ((CheckBox)this.Controls.Find("FinishedCB", false)[0]).Checked, date);
                    break;
                case 2:
                    eventClass = new Lecture(name, recurring, this.Controls.Find("LecturerTB", false)[0].Text, date);
                    break;
                case 3:
                    eventClass = new Tutorial(name, recurring, this.Controls.Find("LabTB", false)[0].Text, this.Controls.Find("LecturerTB", false)[0].Text, date);
                    break;
            }
            return eventClass;
        }
    }
}
