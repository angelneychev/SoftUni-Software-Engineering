using System;
using System.Security.Cryptography.X509Certificates;
using ExtendedDatabase;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person person100;
        private Person person101;
        private Person person102;
        private ExtendedDatabase.ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            this.person100 = new Person(100, "Name_100");
            this.person101 = new Person(101, "Name_101");
            this.person102 = new Person(102, "Name_102");
            this.database = new ExtendedDatabase.ExtendedDatabase(this.person100, this.person101);

        }

        [Test]
        public void TestPersonConstructor()
        {
            Assert.AreEqual(100, this.person100.Id);
            Assert.AreEqual("Name_100", this.person100.UserName);
        }

        [Test]
        public void TestDatabaseConstructor()
        {
            Assert.AreEqual(2,this.database.Count);
        }

        [Test]
        public void TestAddRengExceptionCount()
        {
            Person[] person = new Person[17];

            for (int i = 0; i < person.Length; i++)
            {
                person[i] = new Person(i, $"Name_ + {100 + i}");
            }

            Assert.Throws<ArgumentException>(() => this.database = new ExtendedDatabase.ExtendedDatabase(person));
        }
        [Test]
        public void TestAddPersonCorrectly()
        {
            this.database.Add(person102);
            Assert.AreEqual(3,this.database.Count);
        }
        [Test]
        public void TestAddUserExceptionCount()
        {
            for (int i = 0; i < 14; i++)
            {
                database.Add(new Person(i, $"Name_ + {100 + i}"));
            }

            Assert.That(() => database.Add(new Person(51446, "Ivane")),
                Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
            //Assert.Throws<InvalidOperationException>(() => this.database = new ExtendedDatabase.ExtendedDatabase(person));
        }
        [Test]
        public void TestAddPersonWithExistingUsername()
        {
            Person person = new Person(101,"Name_101");

            Assert.Throws<InvalidOperationException>(() => this.database.Add(person));
        }

        [Test]
        public void TestAddPersonWithExistingID()
        {
            Person person = new Person(101, "Name_105");

            Assert.Throws<InvalidOperationException>(() => this.database.Add(person));
        }

        [Test]
        public void TestAddPersonFullDatabase()
        {
            Person[] person = new Person[16];

            for (int i = 0; i < person.Length; i++)
            {
                person[i] = new Person(i, $"Name_ + {100+i}");
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Add(person100));

        }

        [Test]
        public void TestRemovePersonDatabaseCorrectly()
        {
            this.database.Remove();

            Assert.AreEqual(1,this.database.Count);
        }

        [Test]
        public void TestRemovePersonEmptyDatabase()
        {
            this.database = new ExtendedDatabase.ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void TestFindByUsername()
        {
            Person person = this.database.FindByUsername(person100.UserName);

            Assert.AreEqual(person,person100);
        }

        [Test]
        public void TestFindByInvalidUsername()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername(this.person102.UserName));
        }
        [Test]
        public void TestFindByNullUsername()
        {
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(null));
        }

        [Test]
        public void TestFindById()
        {
            Person person = this.database.FindById(100);

            Assert.AreEqual(person, person100);


        }
        [Test]
        public void TestFindByNoId()
        {
            Assert.That(() => database.FindById(-15),
                Throws.Exception.With.Message.Contains("Id should be a positive number!"));

            Assert.Throws<InvalidOperationException>(() => this.database.FindById(102));
        }
        //[Test]
        //public void TestPersonConstructor()
        //{
        //    Assert.AreEqual(100, this.person1001.Id);
        //    Assert.AreEqual("Name_1001", this.person1001.UserName);
        //}

        //[Test]
        //public void DoesAddUser()
        //{
        //List<string> listName = new  List<string>();

        //for (int i = 1005; i < 1023; i++)
        //{
        //    name = new Person(i, $"{"Name_" + i}");
        //    listName.Add($"{"Name_" + i}");
        //}
        //Assert.AreEqual(this.name.UserName, listName.FirstOrDefault(x => x.Contains(name.UserName)),"Brabo");
        //}
    }
}