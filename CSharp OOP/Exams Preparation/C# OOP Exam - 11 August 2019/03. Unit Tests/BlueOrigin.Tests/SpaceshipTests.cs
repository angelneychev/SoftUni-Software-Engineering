using System.Collections.Generic;

namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Astronaut astronaut1;
        private Astronaut astronaut2;
        private Astronaut astronaut3;
        private Astronaut astronaut4;
        private Spaceship spaceship;
        private ICollection<Astronaut> astronauts;

        [SetUp]
        public void Setup()
        {
            this.astronaut1 = new Astronaut("Name1", 10);
            this.astronaut2 = new Astronaut("Name2", 20);
            this.astronaut3 = new Astronaut("Name3", 30);
            this.astronaut4 = new Astronaut("Name4", 40);
            this.spaceship = new Spaceship("Ship1", 3);
           // this.astronauts = new List<Astronaut>();
        }

        [Test]
        public void TestConstructures()
        {
            Assert.AreEqual("Name1", astronaut1.Name);
            Assert.AreEqual(10, astronaut1.OxygenInPercentage);

            Assert.AreEqual("Ship1", spaceship.Name);
            Assert.AreEqual(3, spaceship.Capacity);
            Assert.AreEqual(0, spaceship.Count);
        }

        [Test]
        public void TestIsNullOrEmptyNameSpaceshipException()
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(null, 10));
            Assert.Throws<ArgumentNullException>(() => new Spaceship(string.Empty, 10));
        }
        [Test]
        public void TestCapacitySpaceshipException()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("AAA", -1));

        }

        [Test]
        public void TestAddAstronautSpaceship()
        {
            this.spaceship.Add(astronaut1);
            this.spaceship.Add(astronaut2);
            this.spaceship.Add(astronaut3);
            //throw new InvalidOperationException("Spaceship is full!");
            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(astronaut4));
        }
        [Test]
        public void TestAddAstronautSpaceshipName()
        {
            this.spaceship.Add(astronaut1);
            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(astronaut1));
        }

        [Test]
        public void TestRemoveFalse()
        {
            this.spaceship.Add(astronaut1);
            this.spaceship.Add(astronaut2);

          //  this.spaceship.Remove(astronaut1.Name);

            Assert.AreEqual(false, this.spaceship.Remove("Name4"));
        }
        [Test]
        public void TestRemoveTrue()
        {
            this.spaceship.Add(this.astronaut1);
            this.spaceship.Add(this.astronaut2);
            Assert.AreEqual(true, this.spaceship.Remove("Name1"));
        }
    }
}