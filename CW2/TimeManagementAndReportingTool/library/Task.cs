using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class Task : Event
    {
        public bool Finished { get; set; }
        public Task(string Name, bool Recurring) : base(Name, Recurring)
        {
         
        }
    }
}
