using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        Database.Database empty;
        Database.Database halfEmpty;
        Database.Database full;
        [SetUp]
        public void Setup()
        {
            empty = new Database.Database();
            halfEmpty = new Database.Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            full = new Database.Database();
            for (int i = 0; i < 16; i++) { full.Add(i); }
        }

        [Test]
        public void Add_Successful_If_Has_Space()
        {
            int initialSize = halfEmpty.Count;
            halfEmpty.Add(9);
            Assert.That(halfEmpty.Count == initialSize + 1);
        }

        [Test]
        public void Add_Throws_Exception_If_Over_Capacity()
        { Assert.Throws<InvalidOperationException>(() => { full.Add(17); }); }

        [Test]
        public void Remove_Successful_When_Has_Elements()
        {
            int initialSize = halfEmpty.Count;
            halfEmpty.Remove();
            Assert.That(halfEmpty.Count == initialSize - 1);
        }

        [Test]
        public void Remove_Throws_Exception_If_Database_Empty()
        { Assert.Throws<InvalidOperationException>(() => { empty.Remove(); }); }

        [Test]
        public void Fetch_Returns_Array()
        { Assert.That(empty.Fetch(), Is.TypeOf<int[]>()); }
    }

}
