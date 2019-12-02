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
    public partial class CreateContactForm : Form
    {
        private bool update;
        public CreateContactForm()
        {
            InitializeComponent();
            update = false;
            DeleteButton.Visible = false;
        }

        public CreateContactForm(string FirstName, string LastName, string Email, string Phone)
        {
            InitializeComponent();
            FirstNameTextBox.Text = FirstName;
            LastNameTextBox.Text = LastName;
            EmailTextBox.Text = Email;
            PhoneTextBox.Text = Phone;
            SaveButton.Text = "Update";
            DeleteButton.Visible = true;
            update = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact(FirstNameTextBox.Text, LastNameTextBox.Text, EmailTextBox.Text, PhoneTextBox.Text);
            if (update)
                contact.Update();
            else
                contact.Create();
            this.Close();
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact(FirstNameTextBox.Text, LastNameTextBox.Text, EmailTextBox.Text, PhoneTextBox.Text);
            var confirmation = MessageBox.Show("Do you want to delete this contact?", "Delete confirmation", MessageBoxButtons.OKCancel);
            if(confirmation == DialogResult.OK)
            {
                contact.Delete();
                this.Close();
            }
        }
    }
}
