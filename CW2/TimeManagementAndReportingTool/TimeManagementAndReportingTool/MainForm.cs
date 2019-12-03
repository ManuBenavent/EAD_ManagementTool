using library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeManagementAndReportingTool
{
    public partial class MainForm : Form
    {
        private bool schedule;
        private List<Control> currentView;
        public MainForm()
        {
            schedule = false;
            currentView = new List<Control>();
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ChangeView();
        }

        private void NewEventButton_Click(object sender, EventArgs e)
        {
            CreateEventForm form = new CreateEventForm();
            form.Activate();
            form.ShowDialog();
        }

        private void NewContactButton_Click(object sender, EventArgs e)
        {
            CreateContactForm form = new CreateContactForm();
            form.Activate();
            form.ShowDialog();
        }

        private void ListContactsButton_Click(object sender, EventArgs e)
        {
            ListContactsForm form = new ListContactsForm();
            form.Activate();
            form.ShowDialog();
        }

        private void TimeReportButton_Click(object sender, EventArgs e)
        {
            TimeReportForm form = new TimeReportForm();
            form.Activate();
            form.ShowDialog();
        }

        private void ChangeViewButton_Click(object sender, EventArgs e)
        {
            ChangeView();
        }

        private void ChangeView()
        {
            foreach (Control c in currentView)
            {
                this.Controls.Remove(c);
            }
            if (schedule)
            {
                currentView.Clear();
                Label title = new Label();
                title.Text = "Schedule";
                title.Font = new Font("Arial Narrow", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                title.Location = new Point(20, 20);
                this.Controls.Add(title);
                currentView.Add(title);
                schedule = false;
            }
            else
            {
                schedule = true;
                List<string> weekDays = new List<string>();
                weekDays.Add("Monday");
                weekDays.Add("Tuesday");
                weekDays.Add("Wednesday");
                weekDays.Add("Thursday");
                weekDays.Add("Friday");
                weekDays.Add("Saturday");
                weekDays.Add("Sunday");
                int[] XPositions = new int[7];
                foreach (string s in weekDays)
                {
                    Label label = new Label();
                    label.Text = s;
                    label.Font = new Font("Arial Narrow", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    label.Size = new Size(s.Length * 9, (int)label.Font.Height);
                    label.Location = new Point(20 + 85 * weekDays.IndexOf(s), 20);
                    XPositions[weekDays.IndexOf(s)] = (20 + 85 * weekDays.IndexOf(s));
                    this.Controls.Add(label);
                    currentView.Add(label);
                }
                //List<EventClass> events = EventClass.ListWeekEvents();
                List<EventClass> events = new List<EventClass>();
                Appointment ap = new Appointment("Ap", false);
                ap.Date = new DateTime(2019, 12, 2, 10, 0, 0);
                Appointment ap1 = new Appointment("Ap1", false);
                ap1.Date = new DateTime(2019, 12, 2, 11, 0, 0);
                Appointment ap2 = new Appointment("Ap2", false);
                ap2.Date = new DateTime(2019, 12, 4, 10, 0, 0);
                Appointment ap3 = new Appointment("Ap3", false);
                ap3.Date = new DateTime(2019, 12, 3, 10, 0, 0);
                Appointment ap4 = new Appointment("Ap4", false);
                ap4.Date = new DateTime(2019, 12, 3, 11, 0, 0);
                Appointment ap5 = new Appointment("Ap5", false);
                ap5.Date = new DateTime(2019, 12, 2, 12, 0, 0);
                events.Add(ap);
                events.Add(ap1);
                events.Add(ap2);
                events.Add(ap3);
                events.Add(ap4);
                events.Add(ap5);
                int[] DayOfWeekHeight = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
                foreach (EventClass e in events) {
                    string type="";
                    switch (e)
                    {
                        case Appointment a:
                            type = "Appointment";
                            break;
                        case Lecture l:
                            type = "Lecture";
                            break;
                        case TaskEvent t:
                            type = "Task";
                            break;
                        case Tutorial t:
                            type = "Tutorial";
                            break;
                    }
                    EventWeeklyView eventControl = new EventWeeklyView(e.Id, e.Name, e.DateTimeString, type);
                    int i=0;
                    switch (e.Date.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            i = 0;
                            break;
                        case DayOfWeek.Tuesday:
                            i = 1;
                            break;
                        case DayOfWeek.Wednesday:
                            i = 2;
                            break;
                        case DayOfWeek.Thursday:
                            i = 3;
                            break;
                        case DayOfWeek.Friday:
                            i = 4;
                            break;
                        case DayOfWeek.Saturday:
                            i = 5;
                            break;
                        case DayOfWeek.Sunday:
                            i = 6;
                            break;
                    }
                    eventControl.Location = new Point(XPositions[i], 40 + 58*DayOfWeekHeight[i]);
                    DayOfWeekHeight[i]++;
                    this.Controls.Add(eventControl);
                    currentView.Add(eventControl);
                }
            }
        }
    }
}
