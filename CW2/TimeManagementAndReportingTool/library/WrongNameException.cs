using System;

namespace library
{
    public class WrongNameException : Exception
    {

        private readonly string Name;
        public override string Message { get { return "The name " + Name + " is not a valid name."; } }

        public WrongNameException(string Name) : base()
        {
            this.Name = Name;
        }
    }
}
