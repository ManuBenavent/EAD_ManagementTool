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
    public partial class CreateEventForm : Form
    {
        List<Control> controls;

        public CreateEventForm()
        {
            controls = new List<Control>();
            InitializeComponent();
            EventTypesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            EventTypesComboBox.Items.Add("Appointment");
            EventTypesComboBox.Items.Add("Task");
            EventTypesComboBox.Items.Add("Lecture");
            EventTypesComboBox.Items.Add("Tutorial");
            EventTypesComboBox.SelectedIndexChanged += EventTypesComboBox_SelectedIndexChanged;
            EventTypesComboBox.SelectedIndex = 0;
        }

        private void EventTypesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(Control c in controls)
            {
                this.Controls.Remove(c);
            }
            Label name = new Label();
            name.Text = "Event name: ";
            name.Location = new System.Drawing.Point(93, 54);
            this.Controls.Add(name);
            controls.Add(name);

            Label recurring = new Label();
            recurring.Text = "Recurring: ";
            recurring.Location = new System.Drawing.Point(93, 74);
            this.Controls.Add(recurring);
            controls.Add(recurring);
            if (EventTypesComboBox.SelectedIndex == 1)
            {
                Label finished = new Label();
                finished.Text = "Finished";
                finished.Location = new System.Drawing.Point(93, 94);
                this.Controls.Add(finished);
                controls.Add(finished);
            }
            if(EventTypesComboBox.SelectedIndex == 2 || EventTypesComboBox.SelectedIndex == 3)
            {
                Label lecturer = new Label();
                lecturer.Text = "Lecturer";
                lecturer.Location = new Point(93, 94);
                this.Controls.Add(lecturer);
                controls.Add(lecturer);
                if (EventTypesComboBox.SelectedIndex == 3)
                {
                    Label lab = new Label();
                    lab.Text = "Lab";
                    lab.Location = new Point(93, 114);
                    this.Controls.Add(lab);
                    controls.Add(lab);
                }
            }

        }
    }
}
