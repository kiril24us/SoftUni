using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
            WeightIncreaser = 1;
        }
        protected override List<Type> PrefferedFoodTypes => new List<Type>
        {
            typeof(Meat),
        };

        public override void ProducingSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
