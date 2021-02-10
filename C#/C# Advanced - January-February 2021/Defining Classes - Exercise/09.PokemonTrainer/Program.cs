using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<Trainer> trainers = new List<Trainer>();
            while (input[0] != "Tournament")
            {
                bool isExisting = false;
                foreach (var T in trainers)
                {
                    if (T.Name == input[0]) 
                    {
                        isExisting = true;
                        T.Pokemons.Add(new Pokemon(input[1], input[2], int.Parse(input[3]))); 
                    }
                }
                if (!isExisting) { trainers.Add(new Trainer(input[0], new List<Pokemon> { new Pokemon(input[1], input[2], int.Parse(input[3])) })); }
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                foreach (var T in trainers)
                {
                    bool hasElement = false;
                    foreach (var p in T.Pokemons) { if (p.Element == command) { hasElement = true; T.Badges++; break; } }
                    if (!hasElement) { foreach (var p in T.Pokemons) { p.Health -= 10; } }
                    T.Pokemons = T.Pokemons.Where(x => x.Health > 0).ToList();
                }
                command = Console.ReadLine();
            }
            trainers = trainers.OrderByDescending(x => x.Badges).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, trainers));
        }
    }
}
