namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        private RobotManager robotManager;

        [SetUp]
        public void Initialize()
        {
            robotManager = new RobotManager(50);
        }

        [Test]
        public void RobotConstructorShouldInitializeProperty()
        {
            var robot = new Robot("Alex", 100);
            Assert.That(robot.Name, Is.EqualTo("Alex"));
            Assert.That(robot.Battery, Is.EqualTo(100));
            Assert.That(robot.MaximumBattery, Is.EqualTo(100));
            Assert.That(robotManager.Capacity, Is.EqualTo(50));
        }

        [Test]
        public void PropertyCapacityShouldThrowExceptionWhenValueIsNegativeNumber()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-2));
        }

        [Test]
        public void CheckingPropertyCount()
        {
            CreatingAndAddingThreeRobots();
            Assert.That(robotManager.Count, Is.EqualTo(3));
        }
        
        [Test]
        public void MethodAddShouldThrowInvalidOperationExceptionWhenThereIsARobotWithSuchName()
        {
            CreatingAndAddingThreeRobots();
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("Alex", 140)));
        }

        [Test]
        public void MethodAddShouldThrowInvalidOperationExceptionWhenCountIsEqualToCapacity()
        {
            for (int i = 0; i < 50; i++)
            {
                var robot = new Robot(i.ToString(), i);
                robotManager.Add(robot);
            }
            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("Alex", 140)));
        }

        [Test]
        public void MethodRemoveShouldThrowInvalidOperationExceptionWhenThereIsNoSuchRobotName()
        {
            CreatingAndAddingThreeRobots();
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("AlexP"));
        }

        [Test]
        public void MethodRemoveShouldWorkCorrectly()
        {
            CreatingAndAddingThreeRobots();
            robotManager.Remove("Alex");
            Assert.That(robotManager.Count, Is.EqualTo(2));
        }

        [Test]
        public void MethodWorkShouldThrowInvalidOperationExceptionWhenThereIsNoSuchName()
        {
            CreatingAndAddingThreeRobots();
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("AlexP", "zaet", 140));
        }

        [Test]
        public void MethodWorkShouldThrowInvalidOperationExceptionWhenBatteryIsLessThanBatteryUsage()
        {
            CreatingAndAddingThreeRobots();
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Alex", "zaet", 140));
        }

        [Test]
        public void MethodWorkWorkingCorrectly()
        {
            var robot = new Robot("Alex", 100);
            robotManager.Add(robot);
            robotManager.Work("Alex", "zaet", 70);
            robotManager.Work("Alex", "zaet", 10);
            Assert.That(robot.Battery, Is.EqualTo(20));
        }

        [Test]
        public void MethodChargeShouldThrowInvalidOperationExceptionWhenThereIsNoSuchName()
        {
            CreatingAndAddingThreeRobots();
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("AlexP"));
        }

        [Test]
        public void MethodChargeShouldWorkingCorrectly()
        {
            var robot = new Robot("Alex", 100);
            robotManager.Add(robot);
            robotManager.Work("Alex", "zaet", 70);
            robotManager.Work("Alex", "zaet", 10);
            robotManager.Charge("Alex");
            Assert.That(robot.Battery, Is.EqualTo(100));
        }

        private void CreatingAndAddingThreeRobots()
        {
            var robot = new Robot("Alex", 100);
            var robot2 = new Robot("Robot", 150);
            var robot3 = new Robot("Georgi", 100);
            robotManager.Add(robot);
            robotManager.Add(robot2);
            robotManager.Add(robot3);
        }
    }
}
