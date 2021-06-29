using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        UnitCar c;
        UnitDriver d;
        RaceEntry r;

        [SetUp]
        public void Setup()
        {
            c = new UnitCar("Mazda RX8", 200, 1000);
            d = new UnitDriver("Driver", c);
            r = new RaceEntry();
        }

        [Test]
        public void Ctor_Valid()
        { Assert.That(r.Counter == 0); }

        [Test]
        public void AddDriver_Valid()
        {
            string result = r.AddDriver(d);
            Assert.That(r.Counter == 1);
            Assert.AreEqual(result, $"Driver Driver added in race.");
        }

        [Test]
        public void AddDriver_Null()
        { Assert.Throws<InvalidOperationException>(() => { r.AddDriver(null); }); }

        [Test]
        public void AddDriver_Repeated()
        {
            r.AddDriver(d);
            Assert.Throws<InvalidOperationException>(() => { r.AddDriver(d); });
        }

        [Test]
        public void CalculateAverageHorsepower_Empty()
        { Assert.Throws<InvalidOperationException>(() => { r.CalculateAverageHorsePower(); }); }
        
        [Test]
        public void CalculateAverageHorsepower_Valid()
        {
            r.AddDriver(d);
            r.AddDriver(new UnitDriver("Second", new UnitCar("Opel Astra", 160, 600)));
            Assert.AreEqual(r.CalculateAverageHorsePower(), 180);
        }
    }
}