using System;

namespace library
{
    public class Lecture : EventClass
    {
        internal override string SQLCreateString { 
            get { 
                return "('" + base.Name + "','" + base.Recurring + "','" + Lecturer + "','" + Date + "')"; 
            } 
        }
        internal override string SQLGetString
        {
            get
            {
                return "Lecture WHERE Name = '" + Name + "' and Recurring='" + Recurring + "' and Lecturer='" + Lecturer + "' and Date='" + Date + "'";
            }
        }
        internal override string SQLUpdateString
        {
            get
            {
                return "Lecture Set Name='" + Name + "', Recurring='" + Recurring + "', Lecturer='" + Lecturer + "', Date='" + Date + "'";
            }
        }
        public string Lecturer { get; set; }
        
        public Lecture(string Name, bool Recurring, string Lecturer) : base(Name, Recurring)
        {
            this.Lecturer = Lecturer;
        }
    }
}
