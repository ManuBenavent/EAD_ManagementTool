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
    public partial class ListContactsForm : Form
    {
        public ListContactsForm()
        {
            InitializeComponent();
            Contact contact = new Contact();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = contact.ListContacts();
            ContactsDataGrid.DataSource = bindingSource;
            ContactsDataGrid.RowHeadersVisible = false;
            ContactsDataGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.Text = "Edit";
            editButton.HeaderText = "Edit";
            editButton.Name = "Edit";
            editButton.UseColumnTextForButtonValue = true;
            ContactsDataGrid.Columns.Insert(4, editButton);
            ContactsDataGrid.CellClick += ContactsDataGrid_CellClick;
        }

        private void UpdateData(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = contact.ListContacts();
            ContactsDataGrid.DataSource = bindingSource;
        }

        private void ContactsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string FirstName = (string)ContactsDataGrid[1, e.RowIndex].Value;
            string LastName = (string)ContactsDataGrid[2, e.RowIndex].Value;
            string Email = (string)ContactsDataGrid[3, e.RowIndex].Value;
            string Phone = (string)ContactsDataGrid[4, e.RowIndex].Value;
            CreateContactForm form = new CreateContactForm(FirstName, LastName, Email, Phone);
            form.FormClosed += UpdateData;
            form.Activate();
            form.ShowDialog();
        }
    }
}
