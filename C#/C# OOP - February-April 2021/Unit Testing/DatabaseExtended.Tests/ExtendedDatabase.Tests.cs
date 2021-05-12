using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        ExtendedDatabase.ExtendedDatabase d;

        [SetUp]
        public void Setup() { d = new ExtendedDatabase.ExtendedDatabase(); }

        //_____________Ctor______________

        [Test]
        public void Ctor_Valid()
        {
            ExtendedDatabase.Person[] people = new ExtendedDatabase.Person[2]
            {
               new ExtendedDatabase.Person(25, "User25"),
               new ExtendedDatabase.Person(17, "User17")
            };
            d = new ExtendedDatabase.ExtendedDatabase(people);
            Assert.That(d.Count == 2);
            Assert.AreEqual("User25", d.FindById(25).UserName);
            Assert.AreEqual(17, d.FindByUsername("User17").Id);
        }

        [Test]
        public void Ctor_Throws_Exception_If_Over_Capacity()
        {
            ExtendedDatabase.Person[] people = new ExtendedDatabase.Person[17];
            for (int i = 0; i < 17; i++) { people[i] = new ExtendedDatabase.Person(i, $"Username{i}"); }
            Assert.Throws<ArgumentException>(() => { d = new ExtendedDatabase.ExtendedDatabase(people); });
        }

        //_____________Add______________

        [Test]
        public void Add_Correct()
        {
            d.Add(new ExtendedDatabase.Person(100, "User100"));
            d.Add(new ExtendedDatabase.Person(17, "User17"));
            Assert.That(d.Count == 2);
        }

        [Test]
        public void Add_Throws_Exception_If_Database_Already_Full()
        {
            for (int i = 0; i < 16; i++) { d.Add(new ExtendedDatabase.Person(i, $"User{i}")); }
            Assert.Throws<InvalidOperationException>(() => { d.Add(new ExtendedDatabase.Person(17, "User17")); });
        }

        [Test]
        public void Add_Throws_Exception_If_Database_Already_Has_That_ID()
        {
            d.Add(new ExtendedDatabase.Person(5, "User5"));
            Assert.Throws<InvalidOperationException>(() => { d.Add(new ExtendedDatabase.Person(5, "Username5")); });
        }
        [Test]
        public void Add_Throws_Exception_If_Database_Already_Has_That_Name()
        {
            d.Add(new ExtendedDatabase.Person(5, "User5"));
            Assert.Throws<InvalidOperationException>(() => { d.Add(new ExtendedDatabase.Person(55, "User5")); });
        }

        //_____________Remove______________

        [Test]
        public void Remove_Correct()
        {
            d.Add(new ExtendedDatabase.Person(17, "User17"));
            d.Add(new ExtendedDatabase.Person(100, "User100"));
            d.Remove();
            Assert.That(d.Count == 1);
            Assert.Throws<InvalidOperationException>(()=>d.FindById(1));
        }

        [Test]
        public void Remove_Throws_Exception_If_Database_Empty()
        { Assert.Throws<InvalidOperationException>(() => { d.Remove(); }); }

        //_____________FindByUserName______________

        [Test]
        public void FindByUserName_Correct()
        {
            ExtendedDatabase.Person p = new ExtendedDatabase.Person(100, "Username");
            d.Add(p);
            Assert.AreEqual(p, d.FindByUsername(p.UserName));
        }

        [Test]
        public void FindByUserName_Throws_Exception_If_Empty()
        { Assert.Throws<ArgumentNullException>(() => { d.FindByUsername(String.Empty); }); }

        [Test]
        public void FindByUserName_Throws_Exception_If_Null()
        { Assert.Throws<ArgumentNullException>(() => { d.FindByUsername(null); }); }

        [Test]
        public void FindByUserName_Throws_Exception_If_Not_Found()
        {
            Assert.Throws<InvalidOperationException>(() => { d.FindByUsername("Username"); });
        }

        //_____________FindById______________

        [Test]
        public void FindById_Correct()
        {
            ExtendedDatabase.Person p = new ExtendedDatabase.Person(100, "User");
            d.Add(p);
            Assert.AreEqual(p, d.FindById(p.Id));
        }

        [Test]
        public void FindById_Throws_Exception_If_Less_Than_0()
        { Assert.Throws<ArgumentOutOfRangeException>(() => { d.FindById(-1); }); }

        [Test]
        public void FindById_Throws_Exception_If_Not_Found()
        { Assert.Throws<InvalidOperationException>(() => { d.FindById(17); }); }
    }
}