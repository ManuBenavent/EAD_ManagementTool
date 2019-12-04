using System;

namespace library
{
    public class Lecture : EventClass
    {
        public override string SQLCreateString { 
            get { 
                return "('" + base.Name + "','" + base.Recurring + "','" + Lecturer + "','" + Date.ToString("yyyy/MM/dd HH:mm:ss") + "')"; 
            } 
        }
        public override string SQLGetString
        {
            get
            {
                return "Lecture WHERE Name = '" + Name + "' and Recurring='" + Recurring + "' and Lecturer='" + Lecturer + "' and Date='" + Date.ToString("yyyy/MM/dd HH:mm:ss") + "'";
            }
        }
        public override string SQLUpdateString
        {
            get
            {
                return "Lecture Set Name='" + Name + "', Recurring='" + Recurring + "', Lecturer='" + Lecturer + "', Date='" + Date.ToString("yyyy/MM/dd HH:mm:ss") + "'";
            }
        }
        public string Lecturer { get; set; }
        
        public Lecture(string Name, bool Recurring, string Lecturer, DateTime Date) : base(Name, Recurring, Date)
        {
            this.Lecturer = Lecturer;
        }

        internal Lecture(int Id, string Name, bool Recurring, string Lecturer, DateTime Date) : base(Id, Name, Recurring, Date)
        {
            this.Lecturer = Lecturer;
        }

        public Lecture(int Id) : base(Id) { }
    }
}
