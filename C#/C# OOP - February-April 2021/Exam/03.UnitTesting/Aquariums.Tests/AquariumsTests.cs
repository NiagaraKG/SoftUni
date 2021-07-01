namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        [Test]
        public void Ctor_Valid()
        {
            Aquarium a = new Aquarium("Aq", 5);
            Assert.That(a.Name == "Aq");
            Assert.That(a.Capacity == 5);
            Assert.That(a.Count == 0);
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Ctor_InValid_Name(string name)
        { Assert.Throws<ArgumentNullException>(() => { new Aquarium(name, 5); }); ; }
        
        [Test]
        public void Ctor_InValid_Capacity()
        { Assert.Throws<ArgumentException>(() => { new Aquarium("Aq", -1); }); ; }

        [Test]
        public void Add_Valid()
        {
            Aquarium a = new Aquarium("Aq", 5);
            a.Add(new Fish("Fish"));
            Assert.That(a.Count == 1);
        }
        [Test]
        public void Add_Full()
        {
            Aquarium a = new Aquarium("Aq", 1);
            a.Add(new Fish("Fish"));
             Assert.Throws<InvalidOperationException>(() => { a.Add(new Fish("Fish2")); }); 
        }
        [Test]
        public void Remove_Valid()
        {
            Aquarium a = new Aquarium("Aq", 5);
            a.Add(new Fish("Fish"));
            Assert.That(a.Count == 1);
            a.RemoveFish("Fish");
            Assert.That(a.Count == 0);

        }
        [Test]
        public void Remove_InValid()
        {
            Aquarium a = new Aquarium("Aq", 5);
            Assert.Throws<InvalidOperationException>(() => { a.RemoveFish("Fish2"); });
        }
        [Test]
          public void Sell_Valid()
        {
            Aquarium a = new Aquarium("Aq", 5);
            a.Add(new Fish("Fish"));
            
            Assert.AreEqual(a.SellFish("Fish").Available, false);

        }
        [Test]
        public void Sell_InValid()
        {
            Aquarium a = new Aquarium("Aq", 5);
            Assert.Throws<InvalidOperationException>(() => { a.SellFish("Fish2"); });
        }
        [Test]
        public void Report()
        {
            Aquarium a = new Aquarium("Aq", 5);
            a.Add(new Fish("Fish"));

            Assert.AreEqual(a.Report(), $"Fish available at {a.Name}: Fish");        }
        [Test]
        public void ReportEmpty()
        {
            Aquarium a = new Aquarium("Aq", 5);
            

            Assert.AreEqual(a.Report(), $"Fish available at {a.Name}: ");        }

    }
}
