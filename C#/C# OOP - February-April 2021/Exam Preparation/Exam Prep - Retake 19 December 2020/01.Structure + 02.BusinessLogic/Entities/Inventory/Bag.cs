using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private List<Item> items;
        public Bag(int capacity) { this.Capacity = capacity; items = new List<Item>(); }
        public int Capacity { get; set; }

        public int Load
        {
            get
            {
                int sum = 0;
                foreach (var i in Items) { sum += i.Weight; }
                return sum;
            }
        }

        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            if(this.Load + item.Weight > this.Capacity) { throw new InvalidOperationException("Bag is full!"); }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if(Items.Count == 0) { throw new InvalidOperationException("Bag is empty!"); }
            if(!Items.Any(i=>i.GetType().Name == name)) { throw new ArgumentException($"No item with name {name} in bag!"); }
            Item found = Items.FirstOrDefault(i => i.GetType().Name == name);
            this.items.Remove(found);
            return found;
        }
    }
}
