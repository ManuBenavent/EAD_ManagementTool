using System;

namespace library
{
    public class Appointment : EventClass
    {
        public override string SQLCreateString { 
            get {
                return "('" + base.Name + "','" + base.Recurring + "','" + Date.ToString("yyyy/MM/dd HH:mm:ss") + "')"; 
            } 
        }
        public override string SQLGetString
        {
            get
            {
                return "Appointment WHERE Name = '" + Name + "' and Recurring='" + Recurring + "' and Date='" + Date.ToString("yyyy/MM/dd HH:mm:ss") + "'";
            }
        }
        public override string SQLUpdateString { 
            get { 
                return "Appointment Set Name='" + Name + "', Recurring='" + Recurring + "', Date='" + Date.ToString("yyyy/MM/dd HH:mm:ss") + "'";
            } 
        }

        public Appointment(string Name, bool Recurring, DateTime Date) : base(Name, Recurring, Date) { }

        public Appointment(int Id, string Name, bool Recurring, DateTime Date) : base(Id, Name, Recurring, Date) { }

        public Appointment(int Id) : base(Id) { }
    }
}
