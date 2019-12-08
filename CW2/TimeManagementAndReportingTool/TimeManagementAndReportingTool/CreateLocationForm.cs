using library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeManagementAndReportingTool
{
    public partial class CreateLocationForm : Form
    {
        private bool saved;
        private CreateEventForm form;
        private bool delete;
        public CreateLocationForm(CreateEventForm form)
        {
            this.form = form;
            InitializeComponent();
            saved = false;
            if (!form.location.IsNull())
            {
                NameTextBox.Text = form.location.Name;
                AddrLine1TextBox.Text = form.location.AddressLine1;
                AddrLine2TextBox.Text = form.location.AddressLine2;
                CityTextBox.Text = form.location.City;
                PostCodeTextBox.Text = form.location.PostCode;
                CountryTextBox.Text = form.location.Country;
                DeleteButton.Visible = true;
            }
            PostCodeTextBox.Select(0, 0);
            this.FormClosing += CreateLocationForm_FormClosing;
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            saved = false;
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
            if (Name == "" || AddrLine1 == "" || City == "" || PostCode == "" || Country == "" || !Regex.IsMatch(PostCodeTextBox.Text, @"^[a-zA-Z0-9][a-zA-Z0-9]\s[a-zA-Z0-9][a-zA-Z0-9][a-zA-Z0-9]"))
            {
                ErrorLabel.Visible = true;
                return;
            }

            form.location.Name = Name;
            form.location.AddressLine1 = AddrLine1;
            form.location.AddressLine2 = AddrLine2;
            form.location.Country = Country;
            form.location.City = City;
            form.location.PostCode = PostCode;
            saved = true;
            if (form.updating)
                form.location.Update();
            this.Close();
        }

        private void CreateLocationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
                form.location = new Location();
            else if (!saved && form.updating && form.eventClass.location != null)
            {
                form.location = form.eventClass.location;
            }
            else if (delete)
                form.location = null;

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            delete = true;
            form.location.Delete();
            this.Close();
        }
    }
}
