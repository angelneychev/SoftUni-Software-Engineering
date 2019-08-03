using System;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void TestIFEnrollWorksCorrectly()
        {
            Warrior warrior = new Warrior("Pesho", 10, 100);

            this.arena.Enroll(warrior);

            Assert.That(this.arena.Warriors, Has.Member(warrior));
        }

        [Test]
        public void TestIFEnrollingExistingWorrior()
        {
            Warrior warrior = new Warrior("Pesho", 10, 100);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior);
            });
        }

        [Test]
        public void TestIFCountWorkCorrectly()
        {
            int ecpectedCount = 1;

            Warrior warrior = new Warrior("Pesho", 10, 100);

            this.arena.Enroll(warrior);

            Assert.AreEqual(ecpectedCount,this.arena.Count);
        }

        [Test]
        public void TestFightWorkCorrectly()
        {
            int expectedAttHp = 95;
            int expectedDefHp = 40;

            Warrior attacer = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 50);

            this.arena.Enroll(attacer);
            this.arena.Enroll(defender);

            this.arena.Fight(attacer.Name, defender.Name);

            Assert.AreEqual(expectedAttHp,attacer.HP);
            Assert.AreEqual(expectedDefHp, defender.HP);
        }

        [Test]
        public void TestFightMissingWarrior()
        {
            Warrior attacer = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 50);

            this.arena.Enroll(attacer);
            //Missing enroll on defender

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(attacer.Name,defender.Name);
            });
        }
    }
}
