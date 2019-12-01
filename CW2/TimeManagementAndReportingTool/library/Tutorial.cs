using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class Tutorial : Event
    {
        internal override string SQLCreateString { get { return "('" + base.Name + "','" + base.Recurring + "','" + Lecturer + "','" + Lab + "')" ; } }
        internal override string SQLGetString
        {
            get
            {
                return "Tutorial WHERE Name = '" + Name + "' and Recurring='" + Recurring + "' and Lecturer='" + Lecturer + "' and Lab='" + Lab + "'";
            }
        }
        internal override string SQLUpdateString
        {
            get
            {
                return "Tutorial Set Name='" + Name + "', Recurring='" + Recurring + "', Lecturer='" + Lecturer + "', Lab='" + Lab + "'";
            }
        }
        public string Lab { get; set; }
        public string Lecturer { get; set; }
        public Tutorial(string Name, bool Recurring, string Lab, string Lecturer) : base(Name, Recurring)
        {
            this.Lab = Lab;
            this.Lecturer = Lecturer;
        }
    }
}
