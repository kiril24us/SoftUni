using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected double fuelConsumption;
        protected double tankCapacity;
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
            this.tankCapacity = tankCapacity;
        }

        public double TankCapacity
        {
            get => tankCapacity;
            protected set
            {
                if (FuelQuantity > value)
                {
                    tankCapacity = 0;
                }
                tankCapacity = value;
            }
        }
        public double FuelQuantity { get; protected set; }

        public abstract void Drive(double distance);

        public abstract void Refuel(double litres);

    }
}
