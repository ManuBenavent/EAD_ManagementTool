using library;
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
            recurringCB.Location = new Point(194, 90);
            this.Controls.Add(recurringCB);

            Label date = new Label();
            date.Text = "Date: ";
            date.Font = EventTypeTitleLabel.Font;
            date.Location = new Point(93, 120);
            this.Controls.Add(date);

            MaskedTextBox maskedTextBox = new MaskedTextBox();
            maskedTextBox.Location = new Point(194, 123);
            maskedTextBox.Width = 300;
            maskedTextBox.Mask = "00/00/00 - 00:00";
            maskedTextBox.Select(0, 0);
            this.Controls.Add(maskedTextBox);
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
                    LabTB.Width = 300;
                    this.Controls.Add(LabTB);
                    controls.Add(LabTB);
                }
            }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            switch (EventTypesComboBox.SelectedIndex)
            {
                case 0:
                    string name = this.Controls.Find("NameTextBox", false)[0].Text;
                    //int index = this.Controls.FindIndex((Control control) => { return control.Name == "NameTextBox"; });
                    //string name = this.Controls[index].Text;
                    Appointment ap = new Appointment(name,false, new DateTime(2019,12,3));
                    ap.Create();
                    break;
                /*case 1:
                    TaskEvent taskEvent = new TaskEvent();
                    taskEvent.Create();
                    break;
                case 2:
                    Lecture l = new Lecture();
                    l.Create();
                    break;
                case 3:
                    Tutorial t = new Tutorial();
                    t.Create();
                    break;*/
            }
        }
    }
}
