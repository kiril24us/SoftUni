using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism
{
    public class Person : Mammal, IAnimal
    {
        public void Da()
        {
            throw new NotImplementedException();
        }

        public override int DoIt()
        {
            throw new NotImplementedException();
        }
    }
}
