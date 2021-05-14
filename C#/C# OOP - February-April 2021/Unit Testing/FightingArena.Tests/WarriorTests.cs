using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void Ctor_Valid()
        {
            FightingArena.Warrior w = new FightingArena.Warrior("Warrior", 10, 30);
            Assert.IsNotNull(w);
            Assert.That(w.Name == "Warrior");
            Assert.That(w.Damage == 10);
            Assert.That(w.HP == 30);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("       ")]
        public void Ctor_Invalid_Name(string name)
        { Assert.Throws<ArgumentException>(() => { new FightingArena.Warrior(name, 10, 30); }); }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Ctor_Invalid_Damage(int d)
        { Assert.Throws<ArgumentException>(() => { new FightingArena.Warrior("Warrior", d, 30); }); }

        [Test]
        public void Ctor_Invalid_HP()
        { Assert.Throws<ArgumentException>(() => { new FightingArena.Warrior("Warrior", 10, -1); }); }

        [Test]
        [TestCase(20)]
        [TestCase(30)]
        public void Attack_Attacker_HP_Below_Min(int hp)
        {
            FightingArena.Warrior attacker = new FightingArena.Warrior("A", 10, hp);
            FightingArena.Warrior defender = new FightingArena.Warrior("D", 10, 40);
            Assert.Throws<InvalidOperationException>(() => { attacker.Attack(defender); });
        }

        [Test]
        [TestCase(20)]
        [TestCase(30)]
        public void Attack_Defender_HP_Below_Min(int hp)
        {
            FightingArena.Warrior attacker = new FightingArena.Warrior("A", 10, 40);
            FightingArena.Warrior defender = new FightingArena.Warrior("D", 10, hp);
            Assert.Throws<InvalidOperationException>(() => { attacker.Attack(defender); });
        }

        [Test]
        public void Attack_Attacker_HP_Below_Defender_Damage()
        {
            FightingArena.Warrior attacker = new FightingArena.Warrior("A", 10, 40);
            FightingArena.Warrior defender = new FightingArena.Warrior("D", 50, 40);
            Assert.Throws<InvalidOperationException>(() => { attacker.Attack(defender); });
        }

        [Test]
        public void Attack_Valid_Attacker_Damage_Weaker()
        {
            FightingArena.Warrior attacker = new FightingArena.Warrior("Attacker", 10, 40);
            FightingArena.Warrior defender = new FightingArena.Warrior("Defender", 10, 40);
            attacker.Attack(defender);
            Assert.AreEqual(attacker.HP, 40 - defender.Damage);
            Assert.AreEqual(defender.HP, 40 - attacker.Damage);
        }

        [Test]
        public void Attack_Valid_Attacker_Damage_Stronger()
        {
            FightingArena.Warrior attacker = new FightingArena.Warrior("Attacker", 80, 50);
            FightingArena.Warrior defender = new FightingArena.Warrior("Defender", 50, 40);
            attacker.Attack(defender);
            Assert.AreEqual(attacker.HP, 0);
            Assert.AreEqual(defender.HP, 0);
        }
    }

}