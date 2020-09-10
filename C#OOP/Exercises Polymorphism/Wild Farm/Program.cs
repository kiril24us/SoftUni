using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Wild_Farm
{
    class Program
    {        
        static void Main(string[] args)
        {
            FoodFactory foodFactory = new FoodFactory();
            List<Animal> animals = new List<Animal>();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string input;
            try
            {
                while ((input = Console.ReadLine()) != "End")
                {
                    string[] animalInfo = input.Split();
                    string type = animalInfo[0];
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);

                    string[] foodTypeAndQuantity = Console.ReadLine().Split();
                    string foodType = foodTypeAndQuantity[0];
                    double quantity = double.Parse(foodTypeAndQuantity[1]);

                    IFood food = foodFactory.ProduceFood(foodType, quantity);
                    Animal animal;
                    switch (type)
                    {
                        case "Cat":
                            string breed = animalInfo[4];
                            string livingRegion = animalInfo[3];
                            animal = new Cat(name, weight, livingRegion, breed);
                            animal.ProducingSound();
                            animal.Feed(food);
                            animals.Add(animal);
                            break;
                        case "Tiger":
                            breed = animalInfo[4];
                            livingRegion = animalInfo[3];
                            animal = new Tiger(name, weight, livingRegion, breed);
                            animal.ProducingSound();
                            animal.Feed(food);
                            animals.Add(animal);
                            break;
                        case "Dog":
                            livingRegion = animalInfo[3];
                            animal = new Dog(name, weight, livingRegion);
                            animal.ProducingSound();
                            animal.Feed(food);
                            animals.Add(animal);
                            break;
                        case "Mouse":
                            livingRegion = animalInfo[3];
                            animal = new Mouse(name, weight, livingRegion);
                            animal.ProducingSound();
                            animal.Feed(food);
                            animals.Add(animal);
                            break;
                        case "Hen":
                            double wingSize = double.Parse(animalInfo[3]);
                            animal = new Hen(name, weight, wingSize);
                            animal.ProducingSound();
                            animal.Feed(food);
                            animals.Add(animal);
                            break;
                        case "Owl":
                            wingSize = double.Parse(animalInfo[3]);
                            animal = new Owl(name, weight, wingSize);
                            animal.ProducingSound();
                            animal.Feed(food);
                            animals.Add(animal);
                            break;
                        default:
                            throw new ArgumentNullException();
                    }
                }
                PrintOutput(animals);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);                
            } 
            catch  (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintOutput(List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
