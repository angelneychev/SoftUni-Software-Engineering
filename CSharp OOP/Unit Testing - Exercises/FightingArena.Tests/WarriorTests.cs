using System;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedName = "Pesho";
            int expectedDmg = 15;
            int ecpectedHp = 100;

            Warrior warrior = new Warrior("Pesho",15,100);
            Assert.AreEqual(expectedName,warrior.Name);
            Assert.AreEqual(expectedDmg, warrior.Damage);
            Assert.AreEqual(ecpectedHp, warrior.HP);
        }

        [Test]
        public void TestWithLikeEmptyName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("   ", 25, 5);
            });
        }

        [Test]
        public void TestWithLikeZeroDamage()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 0, 10);
            });
        }

        [Test]
        public void TestWithLikeNegativeDamage()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", -10, 10);
            });
        }

        [Test]
        public void TestWithLikeNegativeHP()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 15, -10);
            });
        }

        [Test]
        public void TestWithAttackWorksCorrectly()
        {
            int expecterAttHP = 95;
            int expecterDefHP = 80;

            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Pesho", 5, 90);

            attacker.Attack((defender));

            Assert.AreEqual(expecterAttHP,attacker.HP);
            Assert.AreEqual(expecterDefHP,defender.HP);
        }

        [Test]
        public void TestAttackWithLowHp()
        {
            Warrior attacker = new Warrior("Pesho", 10, 25);
            Warrior defender = new Warrior("Gosho", 5, 45);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void TestAttackEnemyWithLowHp()
        {
            Warrior attacker = new Warrior("Pesho", 10, 45);
            Warrior defender = new Warrior("Gosho", 5, 25);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void TestAttackingStrongerEnemy()
        {
            Warrior attacker = new Warrior("Pesho", 10, 35);
            Warrior defender = new Warrior("Gosho", 40, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void TestKillingEnemy()
        {
            int expectedAttHp = 55;
            int expectedDefHp = 0;

            Warrior attacker = new Warrior("Pesho", 50, 100);
            Warrior defender = new Warrior("Gosho", 45, 40);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttHp,attacker.HP);
            Assert.AreEqual(expectedDefHp,defender.HP);

        }
    }
}