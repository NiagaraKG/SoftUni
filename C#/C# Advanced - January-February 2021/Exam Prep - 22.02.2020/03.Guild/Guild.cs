using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.roster.Count();
        public Guild(string name, int capacity)
        {
            this.Name = name; this.Capacity = capacity;
            this.roster = new List<Player>();
        }
        public void AddPlayer(Player p) { if (this.roster.Count < this.Capacity) { this.roster.Add(p); } }
        public bool RemovePlayer(string name)
        {
            if (this.roster.Any(p => p.Name == name))
            {
                this.roster.RemoveAll(p => p.Name == name);
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        { this.roster.First(p => p.Name == name).Rank = "Member"; }
        public void DemotePlayer(string name)
        { this.roster.First(p => p.Name == name).Rank = "Trial"; }
        public Player[] KickPlayersByClass(string clas)
        {
            Player[] removed = roster.Where(p => p.Class == clas).ToArray();
            roster = roster.Where(p => p.Class != clas).ToList();
            return removed;
        }
        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Players in the guild: {this.Name}");
            foreach (var p in this.roster) { result.AppendLine(p.ToString()); }
            return result.ToString().Trim();
        }
    }
}
