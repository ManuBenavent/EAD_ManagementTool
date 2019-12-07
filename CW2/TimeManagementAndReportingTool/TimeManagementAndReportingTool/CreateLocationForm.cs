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
        private Location location;
        public CreateLocationForm(Location location)
        {
            InitializeComponent();
            this.location = location;
            if (!location.IsNull())
            {
                NameTextBox.Text = location.Name;
                AddrLine1TextBox.Text = location.AddressLine1;
                AddrLine2TextBox.Text = location.AddressLine2;
                CityTextBox.Text = location.City;
                PostCodeTextBox.Text = location.PostCode;
                CountryTextBox.Text = location.Country;
            }
            PostCodeTextBox.Select(0, 0);
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            location = null;
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
            if (Name == "" || AddrLine1 == "" || City == "" || PostCode == "" || Country == "")
            {
                ErrorLabel.Visible = true;
                return;
            }

            location.Name = Name;
            location.AddressLine1 = AddrLine1;
            location.AddressLine2 = AddrLine2;
            location.Country = Country;
            location.City = City;
            location.PostCode = PostCode;
            this.Close();
        }
    }
}
