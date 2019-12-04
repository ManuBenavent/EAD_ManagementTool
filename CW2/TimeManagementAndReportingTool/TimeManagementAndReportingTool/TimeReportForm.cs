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
using System.Windows.Forms.DataVisualization.Charting;

namespace TimeManagementAndReportingTool
{
    public partial class TimeReportForm : Form
    {
        public TimeReportForm()
        {
            InitializeComponent();
            ReportChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            ReportChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            ReportChart.Series.Clear();
            ReportChart.Series.Add("Next Weeks");
            ReportChart.Series["Next Weeks"].ChartType = SeriesChartType.Line;
            ReportChart.Series["Next Weeks"].SetDefault(true);

            List<double> aux;
            try
            {
                aux = EventClass.TimeUsageReport();
                for(int i=-3; i < 4; i++)
                {
                    ReportChart.Series["Next Weeks"].Points.AddXY(i, aux[i+3]);
                }
            }
            catch (NoDataException) { }
            ReportChart.Show();
            Controls.Add(ReportChart);
        }
    }
}
