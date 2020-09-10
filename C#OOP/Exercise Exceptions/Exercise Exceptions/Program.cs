using System;
using System.Globalization;
using System.Threading;

namespace Exercise_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            try
            {
                Student student = new Student("asd3");
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
                       
        }
    }
}
