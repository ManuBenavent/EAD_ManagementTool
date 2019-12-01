using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class Task : Event
    {
        public override string SQLCreateString { get { return "('" + base.Name + "','" + base.Recurring + "','" + Finished + "')"; } }
        public override string SQLGetString { get { return "Task WHERE Name = '" ; } }
        public override string SQLUpdateString { get { return ""; } }
        public bool Finished { get; set; }
        public Task(string Name, bool Recurring, bool Finished) : base(Name, Recurring)
        {
            this.Finished = Finished; 
        }
    }
}
