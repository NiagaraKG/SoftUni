using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Item> ItemPool;
        private List<Character> CharacterParty;
        public WarController()
        {
            this.ItemPool = new List<Item>();
            this.CharacterParty = new List<Character>();
        }

        public string JoinParty(string[] args)
        {
            string t = args[0], name = args[1];
            if (t == "Priest") { CharacterParty.Add(new Priest(name)); }
            else if (t == "Warrior") { CharacterParty.Add(new Warrior(name)); }
            else { throw new ArgumentException($"Invalid character type \"{t}\"!"); }
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            if (args[0] == "FirePotion") { ItemPool.Add(new FirePotion()); }
            else if (args[0] == "HealthPotion") { ItemPool.Add(new HealthPotion()); }
            else { throw new ArgumentException($"Invalid item \"{args[0]}\"!"); }
            return $"{args[0]} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            if (!CharacterParty.Any(c => c.Name == args[0])) { throw new ArgumentException($"Character {args[0]} not found!"); }
            Character curr = CharacterParty.FirstOrDefault(c => c.Name == args[0]);
            if (ItemPool.Count == 0) { throw new InvalidOperationException($"No items left in pool!"); }
            var i = ItemPool[ItemPool.Count - 1];
            ItemPool.RemoveAt(ItemPool.Count - 1);
            curr.Bag.AddItem(i);
            if (i.GetType().Name == "FirePotion") { return $"{args[0]} picked up FirePotion!"; }
            else { return $"{args[0]} picked up HealthPotion!"; }
        }

        public string UseItem(string[] args)
        {
            string charName = args[0], itemName = args[1];
            if (!CharacterParty.Any(c => c.Name == charName)) { throw new ArgumentException($"Character {charName} not found!"); }
            Character curr = CharacterParty.FirstOrDefault(c => c.Name == charName);
            if(curr.Bag.Items.Count == 0) { throw new InvalidOperationException($"Bag is empty!"); }
            var item = curr.Bag.Items.FirstOrDefault(i => i.GetType().Name == itemName);
            if (item == null) { throw new ArgumentException($"No item with name {itemName} in bag!"); }
            curr.UseItem(item);
            return $"{charName} used {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder s = new StringBuilder();
            foreach (var ch in CharacterParty.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                string status = "Alive";
                if (ch.IsAlive == false) { status = "Dead"; }
                s.AppendLine($"{ch.Name} - HP: {ch.Health}/{ch.BaseHealth}, AP: {ch.Armor}/{ch.baseArmor}, Status: {status}");
            }
            return s.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string aName = args[0], rName = args[1];
            if (!CharacterParty.Any(c => c.Name == aName)) { throw new ArgumentException($"Character {aName} not found!"); }
            Warrior attacker = (Warrior)CharacterParty.FirstOrDefault(c => c.Name == aName);
            if (!CharacterParty.Any(c => c.Name == rName)) { throw new ArgumentException($"Character {rName} not found!"); }
            Character receiver = CharacterParty.FirstOrDefault(c => c.Name == rName);
            if (attacker.IsAlive == false) { throw new ArgumentException($"{attacker.Name} cannot attack!"); }
            attacker.Attack(receiver);
            StringBuilder s = new StringBuilder();
            s.AppendLine($"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.baseArmor} AP left!");
            if (receiver.IsAlive == false) { s.AppendLine($"{receiver.Name} is dead!"); }
            return s.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string hName = args[0], rName = args[1];
            if (!CharacterParty.Any(c => c.Name == hName)) { throw new ArgumentException($"Character {hName} not found!"); }
            var healer = CharacterParty.FirstOrDefault(c => c.Name == hName);
            if (!CharacterParty.Any(c => c.Name == rName)) { throw new ArgumentException($"Character {rName} not found!"); }
            var receiver = CharacterParty.FirstOrDefault(c => c.Name == rName);
            if (healer.GetType().Name != "Priest") { throw new ArgumentException($"{healer.Name} cannot heal!"); }
            var priest = (Priest)healer;
            priest.Heal(receiver);
            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }
    }
}
