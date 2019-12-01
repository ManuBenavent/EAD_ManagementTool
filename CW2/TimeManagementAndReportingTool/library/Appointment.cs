using System;

namespace library
{
    public class Appointment : Event
    {
        public override string SQLCreateString { get { return "('" + base.Name + "','" + base.Recurring + "')"; } }
        public override string SQLGetString { get { return ""; } }
        public override string SQLUpdateString { get { return ""; } }

        public Appointment(string Name, bool Recurring) : base(Name, Recurring) { }
    }
}
