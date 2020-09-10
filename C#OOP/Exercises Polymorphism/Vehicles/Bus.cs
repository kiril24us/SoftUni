using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double airConditioner = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        public override void Drive(double distance)
        {
            double fuelNeeded = (fuelConsumption + airConditioner) * distance;
            CalculatingFuelQuantity(distance, fuelNeeded);
        }

        public void DriveWithPeople(double distance)
        {
            double fuelNeeded = fuelConsumption * distance;
            CalculatingFuelQuantity(distance, fuelNeeded);
        }

        private void CalculatingFuelQuantity(double distance, double fuelNeeded)
        {
            if (fuelNeeded <= FuelQuantity)
            {
                FuelQuantity -= fuelNeeded;
                Console.WriteLine($"Bus travelled {distance} km");
            }

            else
            {
                Console.WriteLine("Bus needs refueling");
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
                FuelQuantity += litres * 0.95;
            }
        }
    }
}
