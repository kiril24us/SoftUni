using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
            WeightIncreaser = 0.25;
        }
        protected override List<Type> PrefferedFoodTypes => new List<Type>
        {
            typeof(Meat),
        };

        public override void ProducingSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
