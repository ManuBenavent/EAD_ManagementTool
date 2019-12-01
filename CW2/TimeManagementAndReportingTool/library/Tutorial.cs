using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class Tutorial : Event
    {
        public override string SQLCreateString { get { return ""; } }
        public override string SQLGetString { get { return ""; } }
        public override string SQLUpdateString { get { return ""; } }
        public Tutorial(string Name, bool Recurring) : base(Name, Recurring)
        {

        }
    }
}
