using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        Item i;
        BankVault b;

        [SetUp]
        public void Setup()
        {
            i = new Item("Owner", "55");
            b = new BankVault();
        }

        [Test]
        public void Ctor_Valid()
        {
            foreach (var item in b.VaultCells)
            {
                Assert.That(item.Value == null);
            }
        }

        [Test]
        public void AddItem_Valid()
        {
            b.AddItem("A1", i);
            Assert.AreEqual(b.VaultCells["A1"], i);
        }

        [Test]
        public void AddItem_InValid_Cell()
        { Assert.Throws<ArgumentException>(() => { b.AddItem("B12", i); }); }

        [Test]
        public void AddItem_Full_Cell()
        {
            b.AddItem("A1", new Item("OwnerName", "1"));
            Assert.Throws<ArgumentException>(() => { b.AddItem("A1", i); });
        }

        [Test]
        public void AddItem_Repeated_Item()
        {
            b.AddItem("A1", i);
            Assert.Throws<InvalidOperationException>(() => { b.AddItem("A2", i); });
        }

        [Test]
        public void RemoveItemValid()
        {
            b.AddItem("A1", i);
            Assert.IsNotNull(b.VaultCells["A1"]);
            b.RemoveItem("A1", i);
            Assert.IsNull(b.VaultCells["A1"]);
        }

        [Test]
        public void RemoveItem_Invalid_Cell()
        { Assert.Throws<ArgumentException>(() => { b.RemoveItem("B12", i); }); }

        [Test]
        public void RemoveItem_Invalid_Item()
        {
            b.AddItem("A1", new Item("OwnerName", "1"));
            Assert.Throws<ArgumentException>(() => { b.RemoveItem("A1", i); });
        }

    }
}