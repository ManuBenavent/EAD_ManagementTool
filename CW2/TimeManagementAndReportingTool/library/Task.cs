using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class Task : Event
    {
        public override string SQLCreateString { get { return ""; } }
        public override string SQLGetString { get { return ""; } }
        public override string SQLUpdateString { get { return ""; } }
        public bool Finished { get; set; }
        public Task(string Name, bool Recurring) : base(Name, Recurring)
        {
         
        }
    }
}
