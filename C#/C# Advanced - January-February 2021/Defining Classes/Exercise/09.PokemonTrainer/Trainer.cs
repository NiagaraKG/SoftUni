using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public Trainer() { this.Name = ""; this.Badges = 0; this.Pokemons = new List<Pokemon>(); }
        public Trainer(string name, List<Pokemon> pokemons) : this() { this.Name = name; this.Pokemons = pokemons; }
        public override string ToString() { return this.Name + " " + this.Badges + " " + this.Pokemons.Count; }
    }
}
