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
using library.exceptions;

namespace TimeManagementAndReportingTool
{
    public partial class TimeReportForm : Form
    {
        public TimeReportForm()
        {
            InitializeComponent();
            float aux = 0;
            try
            {
                aux = EventClass.TimeUsageReport();
            }
            catch (NoDataException) { }
        }
    }
}
