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
    public partial class EventDetailView : Form
    {
        private EventClass eventClass;
        public EventDetailView(int Id, string type)
        {
            InitializeComponent();
            switch (type)
            {
                case "Appointment":
                    eventClass = new Appointment(Id);
                    break;
                case "Tutorial":
                    eventClass = new Tutorial(Id);
                    Label lecturer = new Label();
                    lecturer.Text = "Lecturer: " + ((Tutorial)eventClass).Lecturer;
                    lecturer.Font = NameLabel.Font;
                    lecturer.Location = new Point(NameLabel.Location.X, RecurringLabel.Location.Y + 35);
                    this.Controls.Add(lecturer);
                    Label lab = new Label();
                    lab.Text = "Lab: " + ((Tutorial)eventClass).Lab;
                    lab.Font = NameLabel.Font;
                    lab.Location = new Point(NameLabel.Location.X, lecturer.Location.Y + 35);
                    this.Controls.Add(lab);
                    break;
                case "Lecture":
                    eventClass = new Lecture(Id);
                    Label lecturer2 = new Label();
                    lecturer2.Text = "Lecturer: " + ((Lecture)eventClass).Lecturer;
                    lecturer2.Font = NameLabel.Font;
                    lecturer2.Location = new Point(NameLabel.Location.X, RecurringLabel.Location.Y + 35);
                    this.Controls.Add(lecturer2);
                    break;
                case "Task":
                    Label finished = new Label();
                    eventClass = new TaskEvent(Id);
                    finished.Text = "Finished: " + (((TaskEvent)eventClass).Finished ? "Yes" : "No");
                    finished.Font = NameLabel.Font;
                    finished.Location = new Point(NameLabel.Location.X, RecurringLabel.Location.Y + 35);
                    this.Controls.Add(finished);
                    break;
                default:
                    throw new ArgumentException("The type of the event is not valid");
            }
            TypeLabel.Text = type;
            NameLabel.Text = "Event name: " + eventClass.Name;
            DateLabel.Text = "Date: " + eventClass.Date.ToString("MM/dd/yyyy h:mm tt");
            RecurringLabel.Text = "Recurring: " + (eventClass.Recurring ? "Yes" : "No");

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            CreateEventForm createEventForm = new CreateEventForm(eventClass);
            createEventForm.FormClosed += CreateEventForm_FormClosed;
            createEventForm.Activate();
            createEventForm.ShowDialog();
        }

        private void CreateEventForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void DeleteEventButton_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show("Do you want to delete this event?", "Delete confirmation", MessageBoxButtons.OKCancel);
            if (confirmation == DialogResult.OK)
            {
                this.eventClass.Delete();
                this.Close();
            }
        }
    }
}
