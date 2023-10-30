using System;

namespace TravelPal.Utilities
{
    public class InvalidUsernameException : ApplicationException
    {
        public InvalidUsernameException(string message) : base(message)
        {

        }
    }
}
