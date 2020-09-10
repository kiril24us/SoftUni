using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_Exceptions
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The value cannot be null or empty!", nameof(FirstName));
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The value cannot be null or empty!", nameof(LastName));
                }
                lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                age = value;
                if (age < 0 || age > 120)
                {
                    throw new ArgumentOutOfRangeException("The value must be within [0...120]", nameof(Age));
                }                
            }
        }
    }
}
