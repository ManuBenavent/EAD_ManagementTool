using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class Tutorial : EventClass
    {
        public override string SQLCreateString { 
            get 
            { 
                return "('" + base.Name + "','" + base.Recurring + "','" + Lecturer + "','" + Lab + "','" + Date.ToString("yyyy/MM/dd HH:mm:ss") + "'" + (location==null ? ")" : "," + location.Id.ToString() + ")") ; 
            } 
        }
        public override string SQLGetString
        {
            get
            {
                return "Tutorial WHERE Name = '" + Name + "' and Recurring='" + Recurring + "' and Lecturer='" + Lecturer + "' and Lab='" + Lab + "' and Date='" + Date.ToString("yyyy/MM/dd HH:mm:ss") + "'" + (location == null ? "" : " and FK_Location=" + location.Id.ToString());
            }
        }
        public override string SQLUpdateString
        {
            get
            {
                return "Tutorial Set Name='" + Name + "', Recurring='" + Recurring + "', Lecturer='" + Lecturer + "', Lab='" + Lab + "', Date='" + Date.ToString("yyyy/MM/dd HH:mm:ss") + "'" + (location == null ? "" : ", FK_Location=" + location.Id.ToString());
            }
        }
        public string Lab { get; set; }
        public string Lecturer { get; set; }
        public Tutorial(string Name, bool Recurring, string Lab, string Lecturer, DateTime Date) : base(Name, Recurring, Date)
        {
            this.Lab = Lab;
            this.Lecturer = Lecturer;
        }

        internal Tutorial(int Id, string Name, bool Recurring, string Lab, string Lecturer, DateTime Date, Location location) : base(Id, Name, Recurring, Date, location)
        {
            this.Lab = Lab;
            this.Lecturer = Lecturer;
        }

        public Tutorial(int Id) : base(Id) { }
    }
}
