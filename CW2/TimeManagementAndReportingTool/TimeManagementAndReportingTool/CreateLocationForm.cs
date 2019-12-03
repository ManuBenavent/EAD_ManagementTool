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
    public partial class CreateLocationForm : Form
    {
        public CreateLocationForm()
        {
            InitializeComponent();
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string Name = NameTextBox.Text;
            string AddrLine1 = AddrLine1TextBox.Text;
            string AddrLine2 = AddrLine2TextBox.Text;
            string City = CityTextBox.Text;
            string PostCode = PostCodeTextBox.Text;
            string Country = CountryTextBox.Text;
            if (Name=="" || AddrLine1=="" || City == "" || PostCode == "" || Country == "")
            {
                ErrorLabel.Visible = true;
            }
            Location location = new Location(Name,AddrLine1,AddrLine2,City,PostCode,Country);
            location.Create();
            this.Close();
        }
    }
}
