using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private double rating;
        private List<Player> players;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentException("A name should not be empty."); }
                else { this.name = value; }
            }
        }       
        public Team(string name)
        {
            this.Name = name;
            this.rating = 0;
            this.players = new List<Player>();
        }
        public void Add(Player p) { players.Add(p); }
        public void Remove(string player)
        {
            if (this.players.Any(p => p.Name == player)) { this.players.RemoveAll(p => p.Name == player); }
            else { throw new InvalidOperationException($"Player {player} is not in {this.Name} team."); }
        }
        public void Rating()
        {
            if (players.Count != 0)
            {
                foreach (var p in players) { this.rating += p.SkillLevel; }
                this.rating /= players.Count;
            }
            Console.WriteLine($"{this.Name} - {this.rating:f0}");
        }
    }
}
