namespace ParkingSystem.Tests
{
    using System;
    using NUnit.Framework;

    public class SoftParkTest
    {
        private Car car;
        private SoftPark parking;
        [SetUp]
        public void Setup()
        {
            this.car = new Car("Volvo", "CA88888BH");
            this.parking = new SoftPark();
        }

        [Test]
        public void TestCarConstructor()
        {
            Assert.AreEqual("Volvo", this.car.Make);
            Assert.AreEqual("CA88888BH", this.car.RegistrationNumber);
        }
        [Test]
        public void TestParkConstructor()
        {
            Assert.AreEqual(12, this.parking.Parking.Count);
        }
        [Test]
        public void TestAddCarSpotDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => this.parking.ParkCar("Z3", this.car));
        }
        [Test]
        public void TestAddCarSpot_Taken()
        {
            this.parking.ParkCar("A1", this.car);

            Car newCar = new Car("Reno", "VB01111OP");

            Assert.Throws<ArgumentException>(() => this.parking.ParkCar("A1", this.car));
        }
        [Test]
        public void TestAddCarCarExist()
        {
            this.parking.ParkCar("A1", this.car);

            Assert.Throws<InvalidOperationException>(() => this.parking.ParkCar("A2", this.car));
        }
        [Test]
        public void TestParkCar()
        {
            Assert.AreEqual($"Car:{this.car.RegistrationNumber} parked successfully!", this.parking.ParkCar("A1", this.car));
        }
        [Test]
        public void TestRemoveCarInvalidSpot()
        {
            Assert.Throws<ArgumentException>(() => this.parking.RemoveCar("Z1", this.car));
        }
        [Test]
        public void TestRemoveCarInvalidCar()
        {
            Car newCar = new Car("Make1", "Number1");

            Assert.Throws<ArgumentException>(() => this.parking.RemoveCar("A1", newCar));
        }
        [Test]
        public void TestRemoveCar()
        {
            this.parking.ParkCar("A1", this.car);

            Assert.AreEqual($"Remove car:{car.RegistrationNumber} successfully!", this.parking.RemoveCar("A1", this.car));
        }
    }
}