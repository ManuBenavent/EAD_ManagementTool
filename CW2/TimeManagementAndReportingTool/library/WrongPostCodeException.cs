using System;
namespace library.exceptions
{
    public class WrongPostCodeException : Exception
    {
        private readonly string PostCode;
        public override string Message { get { return "The post code " + PostCode + " is not a valid post code format."; } }

        public WrongPostCodeException(string PostCode) : base();
        {
            this.PostCode = PostCode;
        }
    }
}
