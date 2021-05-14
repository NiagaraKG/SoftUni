using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void Ctor_Check_If_Warriors_Count_Is_0()
        {
            FightingArena.Arena a = new FightingArena.Arena();
            Assert.That(a.Warriors.Count == 0);
        }

        [Test]
        public void Enroll_Warrior_Already_Enrolled()
        {
            FightingArena.Arena a = new FightingArena.Arena();
            a.Enroll(new FightingArena.Warrior("Warrior", 10, 40));
            Assert.Throws<InvalidOperationException>(() => { a.Enroll(new FightingArena.Warrior("Warrior", 10, 40)); });
        }

        [Test]
        public void Fight_Attacker_Null()
        {
            FightingArena.Arena a = new FightingArena.Arena();
            a.Enroll(new FightingArena.Warrior("Defender", 10, 40));
            Assert.Throws<InvalidOperationException>(() => { a.Fight("Attacker", "Defender"); });
        }

        [Test]
        public void Fight_Defender_Null()
        {
            FightingArena.Arena a = new FightingArena.Arena();
            a.Enroll(new FightingArena.Warrior("Attacker", 10, 40));
            Assert.Throws<InvalidOperationException>(() => { a.Fight("Attacker", "Defender"); });
        }

        [Test]
        public void Fight_Valid()
        {
            FightingArena.Warrior attacker = new FightingArena.Warrior("Attacker", 10, 40);
            FightingArena.Warrior defender = new FightingArena.Warrior("Defender", 10, 40);
            FightingArena.Arena a = new FightingArena.Arena();
            a.Enroll(attacker);
            a.Enroll(defender);
            a.Fight("Attacker", "Defender");
            Assert.AreEqual(attacker.HP, 40-defender.Damage);
            Assert.AreEqual(defender.HP, 40- attacker.Damage);
        }
    }
}
