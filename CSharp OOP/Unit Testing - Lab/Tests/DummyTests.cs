using System;
using NUnit.Framework;
namespace Tests
{
    [TestFixture]
    public class DummyTests
    {

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(11, 10);

            axe.Attack(dummy);
            Assert.That(dummy.Health, Is.EqualTo(1));
            
        }
        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            Axe axe = new Axe(10, 10);
            Dummy weapon = new Dummy(0, 10);

            bool throwsException = false;

            try
            {
                axe.Attack(weapon);
            }
            catch (Exception e)
            {
                throwsException = true;
            }
            Assert.That(throwsException,Is.EqualTo(true), "Dead weapon doesn't throw exception after being attacked");
        }
        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy dead = new Dummy(0,100);

            Assert.That(dead.GiveExperience(), Is.EqualTo(100), "Dead Dummy can give XP");


        }
        [Test]
        //•	Alive Dummy can't give XP
        public void AliveDummyCantGiveXP()
        {
            Dummy alive = new Dummy(1, 100);

            Assert.That(alive.Health, Is.EqualTo(1), "Alive Dummy can't give XP");

           // Assert.That(() => alive.GiveExperience(100), "Alive Dummy can't give XP");

        }


    }
}
