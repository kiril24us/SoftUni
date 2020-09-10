using System;
using System.Globalization;
using System.Threading;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            string[] carInfo = Console.ReadLine().Split();
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            string[] truckInfo = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double trunkTankCapacity = double.Parse(truckInfo[3]);

            string[] busInfo = Console.ReadLine().Split();
            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            int n = int.Parse(Console.ReadLine());

            Vehicle car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);
            Vehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption, trunkTankCapacity);
            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();

                switch (commands[0])
                {
                    case "Drive" when commands[1] == "Car":                        
                        car.Drive(double.Parse(commands[2]));
                        break;
                    case "Drive" when commands[1] == "Truck":                        
                        truck.Drive(double.Parse(commands[2]));
                        break;
                    case "Drive" when commands[1] == "Bus":
                        bus.Drive(double.Parse(commands[2]));
                        break;
                    case "DriveEmpty" when commands[1] == "Bus":
                        bus.DriveWithPeople(double.Parse(commands[2]));
                        break;
                    case "Refuel" when commands[1] == "Car":                        
                        car.Refuel(double.Parse(commands[2]));
                        break;
                    case "Refuel" when commands[1] == "Truck":
                        truck.Refuel(double.Parse(commands[2]));
                        break;
                    case "Refuel" when commands[1] == "Bus":
                        bus.Refuel(double.Parse(commands[2]));
                        break;
                    default:
                        throw new ArgumentNullException();                        
                }          
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
