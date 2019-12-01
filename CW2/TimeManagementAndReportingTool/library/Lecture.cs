using System;

namespace library
{
    public class Lecture : Event
    {
        internal override string SQLCreateString { 
            get { 
                return "('" + base.Name + "','" + base.Recurring + "','" + Lecturer + "')"; 
            } 
        }
        internal override string SQLGetString
        {
            get
            {
                return "Lecture WHERE Name = '" + Name + "' and Recurring='" + Recurring + "' and Lecturer='" + Lecturer + "'";
            }
        }
        internal override string SQLUpdateString
        {
            get
            {
                return "Lecture Set Name='" + Name + "', Recurring='" + Recurring + "', Lecturer='" + Lecturer + "'";
            }
        }
        public string Lecturer { get; set; }
        
        public Lecture(string Name, bool Recurring, string Lecturer) : base(Name, Recurring)
        {
            this.Lecturer = Lecturer;
        }
    }
}
