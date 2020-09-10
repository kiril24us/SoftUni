using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_Exceptions
{
    public class InvalidPersonNameException : Exception
    {
        private string v;      

        public InvalidPersonNameException(string message, string v) : base(message)
        {
            this.v = v;
        }
    }
}
