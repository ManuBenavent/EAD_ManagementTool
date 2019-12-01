using System;

namespace library
{
    public class Lecture : Event
    {
        public override string SQLCreateString { get { return ""; } }
        public override string SQLGetString { get { return ""; } }
        public override string SQLUpdateString { get { return ""; } }
        public string Lecturer { get; set; }
        
        public Lecture(string Name, bool Recurring, string Lecturer) : base(Name, Recurring)
        {
            this.Lecturer = Lecturer;
        }
    }
}
