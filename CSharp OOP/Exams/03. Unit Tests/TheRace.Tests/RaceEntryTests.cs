using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitMotorcycle unitMotorcycle;
        private UnitRider unitRider;
        private Dictionary<string, UnitRider> riders;

        [SetUp]
        public void Setup()
        {
            this.riders = new Dictionary<string, UnitRider>();
            this.raceEntry = new RaceEntry();
            this.unitMotorcycle = new UnitMotorcycle("Model", 100, 200);
            this.unitRider = new UnitRider("Name", unitMotorcycle);

        }

        [Test]
        public void TestRaceEntryConstructor()
        {
            this.raceEntry.AddRider(unitRider);
            Assert.Throws<InvalidOperationException>(() => { this.raceEntry.AddRider(unitRider); });
        }

        [Test]
        public void TestRaceEntryCount()
        {
            int expectedCount = 1;

            UnitRider rider = new UnitRider("Pesho", unitMotorcycle);

            this.raceEntry.AddRider(rider);

            Assert.AreEqual(expectedCount, this.raceEntry.Counter);
        }

        [Test]
        public void TestRiderNull()
        {
            UnitRider rider = null;

            Assert.Throws<InvalidOperationException>(() => { this.raceEntry.AddRider(rider); });
        }

        [Test]
        public void TestCalculateAverageHorsePower()
        {
            int expectedRealRider = this.raceEntry.Counter;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.raceEntry.CalculateAverageHorsePower(); 

            });

        }

        [Test]
        public void TestAverageHorsePower()
        {
            UnitRider peshoRider = new UnitRider("Pesho", unitMotorcycle);
            UnitRider ivanRider = new UnitRider("Ivan", unitMotorcycle);

            this.raceEntry.AddRider(peshoRider);
            this.raceEntry.AddRider(ivanRider);
            List<double> averageHorsePower = new List<double> {100,100};
            double expetedAverage = averageHorsePower.Average();
            Assert.AreEqual(expetedAverage,raceEntry.CalculateAverageHorsePower());

        }
    }
}