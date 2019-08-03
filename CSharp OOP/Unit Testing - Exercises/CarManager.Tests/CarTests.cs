using System;
using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
           this.car = new Car("Volvo", "XC70", 7, 70);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.AreEqual("Volvo", car.Make);
            Assert.AreEqual("XC70", car.Model);
            Assert.AreEqual(7, car.FuelConsumption);
            Assert.AreEqual(70, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void TestIsNullOrEmptyMake()
        {
            Assert.Throws<ArgumentException>(() => new Car(null, "XC70", 7, 70));
            Assert.Throws<ArgumentException>(() => new Car(string.Empty, "XC70", 7, 70));
        }
        [Test]
        public void TestIsNullOrEmptyModel()
        {
            Assert.Throws<ArgumentException>(() => new Car("Volvo", null, 7, 7));
            Assert.Throws<ArgumentException>(() => new Car("Volvo", string.Empty, 7, 70));
        }

        [Test]
        public void TestCarFuelConsumption()
        {
            Assert.Throws<ArgumentException>(() => new Car("Volvo", "XC70", 0, 70));
        }
        [Test]
        public void TestCarFuelCapacity()
        {

            Assert.Throws<ArgumentException>(() => new Car("Volvo", "XC70", 7, 0));
        }
        [Test]
        public void TestCarRefuelException()
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(0));
        }

        [Test]
        public void TestCarRefuel()
        {
            this.car.Refuel(1);
            Assert.AreEqual(1,this.car.FuelAmount);
        }
        [Test]
        public void TestRefuelIfDiff()
        {
            this.car.Refuel(71);
            Assert.AreEqual(70, this.car.FuelAmount);
        }
        [Test]
        public void TestDriveException()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(100));
        }

        [Test]
        public void Test_Drive()
        {
            this.car.Refuel(7);
            this.car.Drive(100);

            Assert.AreEqual(0, this.car.FuelAmount);
        }
    }
}