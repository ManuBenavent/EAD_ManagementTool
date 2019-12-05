using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeManagementAndReportingTool
{
    public partial class EventScheduleView : UserControl
    {
        private int EventId;
        public event EventHandler DetailViewClosed;
        public EventScheduleView(int EventId, string Name, string Datetime, string EventType)
        {
            InitializeComponent();
            this.Click += EventScheduleView_Click;
            NameLabel.BackColor = Color.FromArgb(0, 0, 0, 0);
            DateLabel.BackColor = Color.FromArgb(0, 0, 0, 0);
            EventTypeLabel.BackColor = Color.FromArgb(0, 0, 0, 0);
            NameLabel.Click += EventScheduleView_Click;
            DateLabel.Click += EventScheduleView_Click;
            EventTypeLabel.Click += EventScheduleView_Click;
            NameLabel.Text = Name;
            DateLabel.Text = Datetime;
            EventTypeLabel.Text = EventType;
            this.EventId = EventId;
        }

        private void EventScheduleView_Click(object sender, EventArgs e)
        {
            EventDetailView view = new EventDetailView(EventId, EventTypeLabel.Text);
            view.FormClosed += View_FormClosed;
            view.Activate();
            view.ShowDialog();
        }

        private void View_FormClosed(object sender, FormClosedEventArgs e)
        {
            DetailViewClosed.Invoke(this, e);
        }
    }
}
