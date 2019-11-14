using System;
namespace library.exceptions
{
    public class NoDataException : Exception
    {
        public override string Message { get {return "There are not any events in the DDBB."; } }

        public NoDataException() : base()
        {
        }
    }
}
