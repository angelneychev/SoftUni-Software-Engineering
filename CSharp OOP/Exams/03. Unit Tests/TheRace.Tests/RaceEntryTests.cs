using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitRider rider;
        private UnitMotorcycle motorcycle;
        private RaceEntry race;
        private Dictionary<string, UnitRider> riders;
        [SetUp]
        public void Setup()
        {
            this.riders = new Dictionary<string, UnitRider>();
            this.motorcycle = new UnitMotorcycle("Honda", 100, 500);
            this.rider = new UnitRider("Angel",motorcycle);
            this.race = new RaceEntry();
        }

        [Test]
        public void AddRiderCorrectlyWorks()
        {
            Assert.Throws<InvalidOperationException>(() => { this.race.AddRider(null); });

            this.race.AddRider(rider);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.race.AddRider(rider);
            });
        }

        [Test]
        public void TestCounterRiders()
        {
            this.race.AddRider(rider);

            Assert.AreEqual(1,this.race.Counter);
        }

        [Test]
        public void TestCalculateAverageHorsePower()
        {
            UnitRider peshoRider = new UnitRider("Pesho", motorcycle);
            UnitRider ivanRider = new UnitRider("Ivan", motorcycle);

            this.race.AddRider(peshoRider);
            this.race.AddRider(ivanRider);
            List<double> averageHorsePower = new List<double> { 100, 100 };
            double expetedAverage = averageHorsePower.Average();
            Assert.AreEqual(expetedAverage, race.CalculateAverageHorsePower());

        }
        [Test]
        public void TestAverageHorsePower()
        {
            //int expectedRealRider = this.raceEntry.Counter;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.race.CalculateAverageHorsePower();

            });

        }
    }
}