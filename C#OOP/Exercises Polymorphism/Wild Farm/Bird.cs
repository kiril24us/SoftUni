using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()}{this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
