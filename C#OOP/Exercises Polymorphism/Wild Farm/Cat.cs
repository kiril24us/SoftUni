using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
            WeightIncreaser = 0.3;
        }
        
        protected override List<Type> PrefferedFoodTypes => new List<Type>
        {
            typeof(Vegetable),
            typeof(Meat),
        };

        public override void ProducingSound()
        {
            Console.WriteLine("Meow");
        }       
    }
}
