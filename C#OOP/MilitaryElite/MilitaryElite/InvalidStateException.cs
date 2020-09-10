using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class InvalidStateException : Exception
    {
        private const string message = "Invalid mission state!";
        public InvalidStateException() : base(message)
        {
        }

        public InvalidStateException(string message) : base(message)
        {

        }
    }
}
