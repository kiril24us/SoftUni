using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {            
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [TestCase("VW", null, 2, 100)]
        [TestCase(null, "Golf", 2, 100)]
        [TestCase("VW", "Golf", -2, 100)]
        [TestCase("VW", "Golf", 0, 100)]
        [TestCase("VW", "Golf", 2, -4)]
        [TestCase("VW", "Golf", 2, 0)]
        public void PropertiesShoulThrowArgumentExceptionsWhenAreInvalidValues(string make, string model, double fuelConsumption, double fuelCapacity)
        {           
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void ShouldRefuelNormally()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(2);
            double expectedFuelAmount = 2;
            double actualFuelAmount = car.FuelAmount;
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [Test]
        public void ShouldRefuelUntilTheTotalFuelCapacity()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(101);
            double expectedFuelAmount = 100;
            double actualFuelAmount = car.FuelAmount;
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [TestCase(0)]
        [TestCase(-100)]
        public void MethodRefuelShouldThrowArgumentExceptionWhenValueIsNegativeOrZero(double fuelToRefuel)
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);           
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }

        [Test]
        public void MethodDriveShouldThrowInvalidOperationExceptionWhenFuelNeededIsGreaterThanFuelAmount()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(0.1);            
            Assert.Throws<InvalidOperationException>(() => car.Drive(10));
        }

        [Test]
        public void ShoulDriveNormally()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(10);
            car.Drive(10);
            double expectedFuelAmount = 9.8;
            double actualFuelAmount = car.FuelAmount;           
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }
    }
}