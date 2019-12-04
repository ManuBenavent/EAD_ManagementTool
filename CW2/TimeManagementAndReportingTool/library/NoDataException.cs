using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.exceptions
{
    public class NoDataException : Exception
    {
        public override string Message { get { return "No data stored. Unable to predict time usage."; } }
        public NoDataException() : base() { }
    }
}
