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
                List<string> weekDays = new List<string>();
                weekDays.Add("Monday");
                weekDays.Add("Tuesday");
                weekDays.Add("Wednesday");
                weekDays.Add("Thursday");
                weekDays.Add("Friday");
                weekDays.Add("Saturday");
                weekDays.Add("Sunday");
                foreach (string s in weekDays)
                {
                    Label label = new Label();
                    label.Text = s;
                    label.Font = new Font("Arial Narrow", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                    label.Size = new Size(s.Length * 9, (int)label.Font.Height);
                    label.Location = new Point(20 + 85 * weekDays.IndexOf(s), 20);
                    this.Controls.Add(label);
                    currentView.Add(label);
                }
                schedule = true;
            }
        }
    }
}
