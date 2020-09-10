using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Exercise_Exceptions
{
    public class Student
    {
        private string name;

        public Student(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                var regexItem = new Regex("^[a-zA-Z ]*$");

                if (!regexItem.IsMatch(value)) 
                {
                    throw new InvalidPersonNameException("The value cannot be null or empty!", nameof(Name));
                }                               
            }
        }
        public string Email { get; set; }
    }
}
