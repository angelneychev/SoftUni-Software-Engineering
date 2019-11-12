using System;

namespace Telecom.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    public class Tests
    {
        private Phone phone;
        private Dictionary<string, string> phonebook;

        [SetUp]
        public void Setup()
        {
           this.phone = new Phone("iPhone","iPhone X");
           this.phonebook = new Dictionary<string, string>();
           // this.car = new Car("Volvo", "XC70", 7, 70);
        }
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.AreEqual("iPhone", phone.Make);
            Assert.AreEqual("iPhone X", phone.Model);
            //Assert.AreEqual(7, car.FuelConsumption);
            //Assert.AreEqual(70, car.FuelCapacity);
            //Assert.AreEqual(0, car.FuelAmount);
        }
        [Test]
        public void TestIsNullOrEmptyMake()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null, "iPhone X"));
            Assert.Throws<ArgumentException>(() => new Phone(string.Empty, "iPhone X"));
        }
        [Test]
        public void TestIsNullOrEmptyModel()
        {
            Assert.Throws<ArgumentException>(() => new Phone("iPhone", null));
            Assert.Throws<ArgumentException>(() => new Phone("iPhone", string.Empty));
        }

        [Test]
        public void TestAddContact()
        {
            this.phone.AddContact("Ivan", "0888111222");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.phone.AddContact("Ivan", "0888111222");

            });
        }

        [Test]
        public void TestCountPhoneBookName()
        {
            int expectedCount = 1;
            phone.AddContact("Ivan", "0888111222");
            Assert.AreEqual(expectedCount,phone.Count);
        }
        [Test]
        public void TestCall()
        {
          this.phone.AddContact("Ivan", "0888111222");
            this.phone.Call("Ivan");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.phone.Call("Petko");

            });
        }
        [Test]
        public void CanItCall()
        {
            phone.AddContact("Pesho", "0888111222");

            string expectedReturnValue = $"Calling Pesho - 0888111222...";

            Assert.That(() => phone.Call("Pesho"), Is.EqualTo(expectedReturnValue)
                , "Cannot Call");
        }
    }
}