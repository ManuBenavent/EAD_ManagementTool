using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.exceptions
{
    class DDBBException : Exception
    {
        private string origin;

        public override string Message { get { return "The origin was " + origin; } }
        public DDBBException(string origin) : base(origin)
        {
            this.origin = origin;
        }
    }
}
