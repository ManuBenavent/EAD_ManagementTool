using System;
namespace library.exceptions
{
    public class WrongEmailException : Exception
    {
        private readonly string email;
        public override string Message { get { return "The email " + email + "is not a valid email format."; } }

        public WrongEmailException(string email) :base()
        {
            this.email = email;
        }
    }
}
