using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
            WeightIncreaser = 0.35;
        }      

        protected override List<Type> PrefferedFoodTypes => new List<Type>
        {
            typeof(Vegetable),
            typeof(Fruit),
            typeof(Meat),
            typeof(Seeds),
        };

        public override void ProducingSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
