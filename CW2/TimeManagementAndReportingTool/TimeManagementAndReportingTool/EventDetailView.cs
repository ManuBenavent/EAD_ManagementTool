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
        public EventDetailView(int Id, string type)
        {
            InitializeComponent();
            EventClass eventClass;
            switch (type)
            {
                case "Appointment":
                    eventClass = new Appointment(Id);
                    break;
                case "Tutorial":
                    eventClass = new Tutorial(Id);
                    break;
                case "Lecture":
                    eventClass = new Lecture(Id);
                    break;
                case "Task":
                    eventClass = new TaskEvent(Id);
                    break;
                default:
                    throw new ArgumentException("The type of the event is not valid");
            }

        }
    }
}
