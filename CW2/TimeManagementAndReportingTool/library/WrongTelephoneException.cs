using System;
namespace library.exceptions
{
    public class WrongTelephoneException : Exception
    {
        private readonly string PhoneNumber;
        public override string Message { get { return "The phone number " + PhoneNumber + " is not a valid phone number format."; } }

        public WrongTelephoneException(string PhoneNumber) : base()
        {
            this.PhoneNumber = PhoneNumber;
        }
    }
}
