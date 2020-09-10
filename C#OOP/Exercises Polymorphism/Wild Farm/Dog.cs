using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
            WeightIncreaser = 0.4;
        }       

        protected override List<Type> PrefferedFoodTypes => new List<Type>
        {
            typeof(Meat),
        };
        public override void ProducingSound()
        {
            Console.WriteLine("Woof!");
        }

        public override string ToString()
        {
            return $"{base.ToString()}{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
