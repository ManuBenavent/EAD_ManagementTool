using System;

namespace library
{
    public class Appointment : Event
    {
        internal override string SQLCreateString { 
            get { 
                return "('" + base.Name + "','" + base.Recurring + "')"; 
            } 
        }
        internal override string SQLGetString
        {
            get
            {
                return "Appointment WHERE Name = '" + Name + "' and Recurring='" + Recurring + "'";
            }
        }
        internal override string SQLUpdateString { 
            get { 
                return "Appointment Set Name='" + Name + "', Recurring='" + Recurring + "'"; 
            } 
        }

        public Appointment(string Name, bool Recurring) : base(Name, Recurring) { }
    }
}
