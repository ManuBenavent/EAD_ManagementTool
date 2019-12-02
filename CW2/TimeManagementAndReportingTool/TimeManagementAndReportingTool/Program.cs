using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeManagementAndReportingTool
{
    static class Program
    {
        /// <summary>
        /// Start point for the app.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf(@"\bin\Debug")));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CreateEventForm());
        }
    }
}
