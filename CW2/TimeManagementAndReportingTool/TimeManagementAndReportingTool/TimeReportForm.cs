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
            ReportChart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDotDot;
            ReportChart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDotDot;
            ReportChart.ChartAreas[0].AxisY.Title = "Hours";
            ReportChart.ChartAreas[0].AxisX.Title = "Weeks";
            ReportChart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Arial Narrow", 12F);
            ReportChart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Arial Narrow", 12F);
            ReportChart.ChartAreas[0].AxisY.LineWidth = 2;
            ReportChart.ChartAreas[0].AxisX.LineWidth = 2;
            ReportChart.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial Narrow", 12F);
            ReportChart.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Arial Narrow", 12F);
            ReportChart.Series.Clear();
            ReportChart.Series.Add("Regression line");
            ReportChart.Series["Regression line"].ChartType = SeriesChartType.Line;
            ReportChart.Series["Regression line"].BorderWidth = 3;
            ReportChart.Series["Regression line"].SetDefault(true);
            ReportChart.Series.Add("Previous Weeks");
            ReportChart.Series["Previous Weeks"].BorderWidth = 5;
            ReportChart.Series["Previous Weeks"].ChartType = SeriesChartType.Point;
            Title title = new Title();
            title.Font = new Font("Arial Bold", 15);
            title.Text = "Expected hours per week";
            ReportChart.Titles.Add(title);
            List<double> aux;
            try
            {
                double intercept, slope;
                aux = EventClass.TimeUsageReport(out slope, out intercept);//TODO ADD POINTS
                for (int i = 0; i < aux.Count+4; i++)
                {
                    ReportChart.Series["Regression line"].Points.AddXY(i - aux.Count + 1, (slope*i) + intercept);
                    if (i < aux.Count)
                        ReportChart.Series["Previous Weeks"].Points.AddXY(i - aux.Count + 1, aux[i]);
                }
            }
            catch (NoDataException) { }
            ReportChart.Show();
            Controls.Add(ReportChart);
        }
    }
}
