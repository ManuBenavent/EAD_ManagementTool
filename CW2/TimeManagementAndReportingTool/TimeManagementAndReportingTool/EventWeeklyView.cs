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
        public EventWeeklyView(int EventId, string Name, string Datetime, string EventType)
        {
            InitializeComponent();
            this.Click += EventWeeklyView_Click;
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
            view.Activate();
            view.ShowDialog();
        }
    }
}
