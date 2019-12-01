using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class Tutorial : Event
    {
        public override string SQLCreateString { get { return "('" + base.Name + "','" + base.Recurring + "','" + Lecturer + "','" + Lab + "')" ; } }
        public override string SQLGetString { get { return ""; } }
        public override string SQLUpdateString { get { return ""; } }
        public string Lab { get; set; }
        public string Lecturer { get; set; }
        public Tutorial(string Name, bool Recurring, string Lab, string Lecturer) : base(Name, Recurring)
        {
            this.Lab = Lab;
            this.Lecturer = Lecturer;
        }
    }
}
