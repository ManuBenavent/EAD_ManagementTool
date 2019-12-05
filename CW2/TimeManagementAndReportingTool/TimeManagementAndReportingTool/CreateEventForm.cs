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
        List<Control> recurringControls;
        private bool updating;
        private EventClass eventClass;
        private Location location;

        public CreateEventForm()
        {
            Initialize();
            updating = false;
        }

        public CreateEventForm(EventClass eventClass)
        {
            this.eventClass = eventClass;
            this.location = eventClass.location;
            updating = true;
            Initialize();
            EventTypesComboBox.Enabled = false;
            ((CheckBox)this.Controls.Find("RecurringCB", false)[0]).Enabled=false;
            SaveButton.Text = "Update";
            ((CheckBox)this.Controls.Find("RecurringCB", false)[0]).Checked = eventClass.Recurring;
            this.Controls.Find("NameTextBox", false)[0].Text = eventClass.Name;
            ((DateTimePicker)this.Controls.Find("DateTimePicker", false)[0]).Value = eventClass.Date;
            switch (eventClass)
            {
                case Appointment ap:
                    EventTypesComboBox.SelectedIndex = 0;
                    break;
                case Lecture lec:
                    EventTypesComboBox.SelectedIndex = 2;
                    this.Controls.Find("LecturerTB", false)[0].Text = lec.Lecturer;
                    break;
                case Tutorial tut:
                    EventTypesComboBox.SelectedIndex = 3;
                    this.Controls.Find("LabTB", false)[0].Text = tut.Lab;
                    this.Controls.Find("LecturerTB", false)[0].Text = tut.Lecturer;
                    break;
                case TaskEvent t:
                    EventTypesComboBox.SelectedIndex = 1;
                    ((CheckBox)this.Controls.Find("FinishedCB", false)[0]).Checked = t.Finished;
                    break;
            }
        }

        private void Initialize()
        {
            controls = new List<Control>();
            recurringControls = new List<Control>();
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
            recurringCB.CheckedChanged += RecurringCB_CheckedChanged;
            recurringCB.Location = new Point(194, 90);
            recurringCB.Size = new Size(20, 20);
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
            dateTime.CustomFormat = "dd/MM/yyyy hh:mm";
            this.Controls.Add(dateTime);
        }

        private void RecurringCB_CheckedChanged(object sender, EventArgs e)
        {
            if (!updating && ((CheckBox)sender).Checked)
            {
                Label label = new Label();
                label.Text = "Recurrent for:";
                label.Font = EventTypeTitleLabel.Font;
                label.Location = new Point(210, 90);
                this.Controls.Add(label);
                recurringControls.Add(label);

                TextBox textBox = new TextBox();
                textBox.Location = new Point(310, 90);
                textBox.Width = 35;
                textBox.Text = "0";
                textBox.Name = "RecurringTimesTB";
                this.Controls.Add(textBox);
                recurringControls.Add(textBox);

                ComboBox comboBox = new ComboBox();
                comboBox.Location = new Point(350, 90);
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.Items.Add("Days");
                comboBox.Items.Add("Weeks");
                comboBox.Items.Add("Months");
                comboBox.Name = "RecurringComboBox";
                comboBox.Width = 90;
                comboBox.SelectedIndex = 0;
                this.Controls.Add(comboBox);
                recurringControls.Add(comboBox);
            }
            else
            {
                foreach (Control c in recurringControls)
                {
                    this.Controls.Remove(c);
                }
            }
            
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

        private void DismissButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            EventClass data = ObtainData();

            if (location!=null && (location.IsNull() || !location.Equals(data.location)))
            {
                location.Create();
                data.location = location;
            }
            if (updating)
            {
                if (data == null)
                    return;
                eventClass.Name = data.Name;
                eventClass.Date = data.Date;
                eventClass.location = data.location;
                switch (data)
                {
                    case Lecture l:
                        ((Lecture)eventClass).Lecturer = l.Lecturer;
                        break;
                    case Tutorial t:
                        ((Tutorial)eventClass).Lecturer = t.Lecturer;
                        ((Tutorial)eventClass).Lab = t.Lab;
                        break;
                    case TaskEvent task:
                        ((TaskEvent)eventClass).Finished = task.Finished;
                        break;
                }
                this.Close();
                eventClass.Update();
            }
            else if (((CheckBox)this.Controls.Find("RecurringCB", false)[0]).Checked)
            {
                if (data == null)
                    return;
                this.Close();
                int times = Int32.Parse(this.Controls.Find("RecurringTimesTB", false)[0].Text);
                for (int i = 0; i < times; i++)
                {
                    if (i + 1 == times)
                        data.Recurring = false;
                    if (i != 0)
                    {
                        TimeSpan timeSpan;
                        switch (((ComboBox)this.Controls.Find("RecurringComboBox", false)[0]).SelectedIndex)
                        {
                            case 0:
                                timeSpan = new TimeSpan(1, 0, 0, 0);
                                break;
                            case 1:
                                timeSpan = new TimeSpan(7, 0, 0, 0);
                                break;
                            case 2:
                                timeSpan = new TimeSpan(30, 0, 0, 0);
                                break;
                            default:
                                timeSpan = new TimeSpan(0, 0, 0, 0);
                                break;
                        }
                        data.Date = data.Date.Add(timeSpan);
                    }
                    data.Create();
                }
            }
            else
            {
                if (data == null)
                    return;
                this.Close();
                data.Create();
            }
        }

        private EventClass ObtainData()
        {
            EventClass eventClass=null;
            string name = this.Controls.Find("NameTextBox", false)[0].Text;
            bool recurring = ((CheckBox)this.Controls.Find("RecurringCB", false)[0]).Checked;
            if (name == "" || (recurring && !NumberIsValid(this.Controls.Find("RecurringTimesTB", false)[0].Text)))
            {
                ErrorLabel.Visible = true;
                return null;
            }
           
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

        private bool NumberIsValid(string number)
        {
            try
            {
                if (Int32.Parse(number) == 0)
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void AddLocationButton_Click(object sender, EventArgs e)
        {
            if (location == null)
                location = new Location();
            CreateLocationForm createLocationForm = new CreateLocationForm(location);
            createLocationForm.Activate();
            createLocationForm.ShowDialog();
        }
    }
}
