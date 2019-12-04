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
    public partial class EventWeeklyView : UserControl
    {
        private int EventId;
        public event EventHandler DetailViewClosed;
        public EventWeeklyView(int EventId, string Name, string Datetime, string EventType)
        {
            InitializeComponent();
            this.Click += EventWeeklyView_Click;
            EventNameLabel.BackColor = Color.FromArgb(0, 0, 0, 0);
            DateTimeLabel.BackColor = Color.FromArgb(0, 0, 0, 0);
            EventTypeLabel.BackColor = Color.FromArgb(0, 0, 0, 0);
            EventNameLabel.Click += EventWeeklyView_Click;
            DateTimeLabel.Click += EventWeeklyView_Click;
            EventTypeLabel.Click += EventWeeklyView_Click;
            this.EventId = EventId;
            EventNameLabel.Text = Name;
            DateTimeLabel.Text = Datetime;
            EventTypeLabel.Text = EventType;
        }

        private void EventWeeklyView_Click(object sender, EventArgs e)
        {
            EventDetailView view = new EventDetailView(EventId, EventTypeLabel.Text);
            view.FormClosed += View_FormClosed;
            view.Activate();
            view.ShowDialog();
        }

        private void View_FormClosed(object sender, EventArgs e)
        {
             DetailViewClosed.Invoke(this, e);
        }
    }
}
