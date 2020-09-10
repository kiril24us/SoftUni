using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
            WeightIncreaser = 0.1;
        }
        protected override List<Type> PrefferedFoodTypes => new List<Type>
        {
            typeof(Vegetable),
            typeof(Fruit),
        };
        public override void ProducingSound()
        {
            Console.WriteLine("Squeak");
        }

        public override string ToString()
        {
            return $"{base.ToString()}{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
