using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;

namespace HeroRepository.Tests
{
    public class Tests
    {
       // private HeroRepository heroRepository;
        private Hero hero1;
        private Hero hero2;
        private HeroRepository heroRepository;
        [SetUp]
        public void Setup()
        {
            this.hero1 = new Hero("name1", 10);
            this.heroRepository = new HeroRepository();
        }

        [Test]
        public void TestCreateHeroRepository()
        {
            Assert.That(() => heroRepository.Create(hero1), Is.EqualTo($"Successfully added hero {hero1.Name} with level {hero1.Level}"));
        }

        [Test]
        public void TestCreateHeroRepositoryNullName()
        {
            Hero hero = null;
            Assert.Throws<ArgumentNullException>(()=> this.heroRepository.Create(hero));
        }
        [Test]
        public void TestCreateHeroRepositoryAlready()
        {
            this.heroRepository.Create(hero1);

            Assert.Throws<InvalidOperationException>(() => this.heroRepository.Create(hero1));
        }
        // Assert.Throws<ArgumentNullException>(() => this.heroRepository.Remove(null));
        [Test]
        public void TestRemoveIsNullOrWhiteSpace()
        {
            Assert.Throws<ArgumentNullException>(() => this.heroRepository.Remove(null));
            Assert.Throws<ArgumentNullException>(() => this.heroRepository.Remove(string.Empty));
        }
        [Test]
        public void TestRemoveNameTrue()
        {
            this.heroRepository.Create(hero1);
            Assert.AreEqual(true, heroRepository.Remove(hero1.Name));
        }
        [Test]
        public void TestRemoveHeroRepositoryFalse()
        {
            this.heroRepository.Create(hero1);
            Assert.AreEqual(false, heroRepository.Remove("name5"));
        }
        [Test]
        public void TestGetHero()
        {
            var expName = this.heroRepository.GetHero(hero1.Name);
            Assert.AreEqual("name1", hero1.Name);
        }
        [Test]
        public void TestGetHeroWithHighestLevel()
        {
            hero2 = new Hero("name2", 10);
            this.heroRepository.Create(hero1);
            this.heroRepository.Create(hero2);
            var expName = this.heroRepository.GetHeroWithHighestLevel();
            Assert.AreEqual(expName, this.heroRepository.GetHeroWithHighestLevel());
            //  Assert.AreEqual(10,this.heroRepository.GetHeroWithHighestLevel());

        }
        [Test]
        public void TestIReadOnlyCollection()
        {
            this.heroRepository.Heroes.GetEnumerator();
        }
    }
}

