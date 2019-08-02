using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy weapon;

        [SetUp]
        public void TestInit()
        {
            axe = new Axe(2, 2);
            weapon = new Dummy(100, 100);
        }

        [Test]
        public void AxeLosesDurabilityAfter()
        {
 
            axe.Attack(weapon);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(1), "Axe Durability doesn't change  after attack");
        }
        [Test]
        public void BrokenWeaponCannotAttack()
        {
            axe.Attack(weapon);
            axe.Attack(weapon);

            Assert.That(() => axe.Attack(weapon), Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."));
        }
    }
}
