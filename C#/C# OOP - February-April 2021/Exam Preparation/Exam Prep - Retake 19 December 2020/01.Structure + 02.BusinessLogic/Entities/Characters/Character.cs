using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.baseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public double baseArmor;
        public double BaseHealth;

        private double armor;
        private double health;
        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentException("Name cannot be null or whitespace!"); }
                this.name = value;
            }
        }
        public double Health
        {
            get => this.health;
            set
            {
                if (value > 0 && value <= this.BaseHealth) { this.health = value; }
            }
        }
        public double Armor
        {
            get => this.armor;
            set { if (value >= 0) { this.armor = value; } }
        }
        public Inventory.Bag Bag { get; set; }
        public double AbilityPoints { get; set; }

        public bool IsAlive { get; set; } = true;
        protected void EnsureAlive()
        { if (!this.IsAlive) { throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead); } }

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();
            if (hitPoints > this.Armor) { this.health -= (hitPoints - this.Armor); }
            this.armor -= hitPoints;
            if (this.armor < 0) { this.Armor = 0; }
            if (this.Health <= 0) { this.health = 0; IsAlive = false; }
        }
        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);
        }
    }
}
