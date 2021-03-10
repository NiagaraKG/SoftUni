using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;
        public Race(string name, int capacity) { this.Name = name; this.Capacity = capacity; this.data = new List<Racer>(); }
        public void Add(Racer r) { if (this.data.Count < this.Capacity) { this.data.Add(r); } }
        public bool Remove(string name)
        {
            if (this.data.Any(x => x.Name == name))
            {
                this.data.RemoveAll(x => x.Name == name);
                return true;
            }
            return false;
        }
        public Racer GetOldestRacer()
        {
            Racer oldest = this.data[0];
            foreach (var r in this.data) { if (r.Age > oldest.Age) { oldest = r; } }
            return oldest;
        }
        public Racer GetRacer(string name)
        {
            if (this.data.Any(x => x.Name == name)) { return this.data.First(x => x.Name == name); }
            return null;
        }
        public Racer GetFastestRacer()
        {
            Racer fastest = this.data[0];
            foreach (var r in this.data) { if (r.Car.Speed > fastest.Car.Speed) { fastest = r; } }
            return fastest;
        }
        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Racers participating at {this.Name}:");
            foreach (var r in this.data) { result.AppendLine(r.ToString()); }
            return result.ToString().Trim();
        }
    }
}
