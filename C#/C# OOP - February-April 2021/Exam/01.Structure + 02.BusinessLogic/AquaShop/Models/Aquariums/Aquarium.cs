using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private List<IDecoration> decorations;
        private List<IFish> fish;

        private string name;
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentException(ExceptionMessages.InvalidAquariumName); }
                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort
        {
            get
            {
                int sum = 0;
                foreach (var d in Decorations)
                {
                    sum += d.Comfort;
                }
                return sum;
            }
        }

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fish.Count == this.Capacity) { throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity); }
            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var f in this.fish)
            {
                f.Eat();
            }
        }

        public string GetInfo()
        {
            if (this.fish.Count == 0)
            {
                return $"{this.Name} ({this.GetType().Name}):" + Environment.NewLine + "Fish: none" +
                    Environment.NewLine + $"Decorations: { this.decorations.Count}" + Environment.NewLine +
                     $"Comfort: { this.Comfort}";
            }
            else
            {
                string f = string.Join(", ", this.fish.Select(f=>f.Name));
                return $"{this.Name} ({this.GetType().Name}):" + Environment.NewLine + $"Fish: {f}" +
                 Environment.NewLine + $"Decorations: { this.decorations.Count}" + Environment.NewLine +
                $"Comfort: { this.Comfort}";
            }
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }
        public Aquarium(string name, int capacity)
        {
            this.Name = name; this.Capacity = capacity; this.decorations = new List<IDecoration>(); this.fish = new List<IFish>();
        }
    }
}
