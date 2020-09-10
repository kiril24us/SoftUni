using System;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            IAnimal animal = new Person();
            Mammal mamal = new Person();
            Person person = new Person();

            animal.Da();
            mamal.DoIt();
            person.Da();
            person.DoIt();
        }
    }
}
