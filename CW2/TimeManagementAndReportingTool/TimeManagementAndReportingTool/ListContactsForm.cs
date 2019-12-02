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

        private void ContactsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CreateContactForm form = new CreateContactForm();
            form.Activate();
            form.ShowDialog();
        }
    }
}
