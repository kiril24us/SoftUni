using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double airConditioner = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        public override void Drive(double distance)
        {
            if ((fuelConsumption + airConditioner) * distance <= FuelQuantity)
            {
                FuelQuantity -= (fuelConsumption + airConditioner) * distance;
                Console.WriteLine($"Car travelled {distance} km");
            }

            else
            {
                Console.WriteLine("Car needs refueling");
            }
            
        }

        public override void Refuel(double litres)
        {
            if (litres <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");                
            }
            else if (FuelQuantity + litres > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {litres} fuel in the tank");
            }
            else
            {
                FuelQuantity += litres;
            }
            
        }
    }
}
