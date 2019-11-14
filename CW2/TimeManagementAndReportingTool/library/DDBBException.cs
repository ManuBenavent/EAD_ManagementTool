using System;
namespace library.exceptions
{
    public class DDBBException : Exception
    {
        private readonly string source;
        public override string Message { get { return "The source of this exception was: " + source; } }

        public DDBBException(string source)
        {
            this.source = source;
        }

    }
}
