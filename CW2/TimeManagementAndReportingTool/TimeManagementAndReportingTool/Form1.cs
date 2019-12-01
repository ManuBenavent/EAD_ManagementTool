using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using library;

namespace TimeManagementAndReportingTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Contact con = new Contact("Manu", "BLL", "asdf", "asdf");
            con.Create();
            //con.Delete();
            con.FirstName = "Manuel";
            con.LastName = "Benavent";
            con.Email = "";
            con.Phone = "12345";
            con.Update();
        }
    }
}
