using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name { get; private set; }

        public double Weight { get; private set; }

        public double FoodEaten { get; private set; }

        public double WeightIncreaser { get; protected set; }

        protected abstract List<Type> PrefferedFoodTypes { get; }

        public abstract void ProducingSound();

        public void Feed(IFood food)
        {
            if (!PrefferedFoodTypes.Contains(food.GetType()))
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            else
            {
                Weight += food.Quantity * WeightIncreaser;
                FoodEaten += food.Quantity;
            }           
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
