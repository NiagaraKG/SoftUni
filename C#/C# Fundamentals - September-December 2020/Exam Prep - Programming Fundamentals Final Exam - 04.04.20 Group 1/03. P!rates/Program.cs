using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("||");
            Dictionary<string, List<double>> cities = new Dictionary<string, List<double>>();
            while (input[0] != "Sail")
            {
                if (cities.ContainsKey(input[0]))
                { cities[input[0]][0] += double.Parse(input[1]); cities[input[0]][1] += double.Parse(input[2]); }
                else { cities.Add(input[0], new List<double> { double.Parse(input[1]), double.Parse(input[2]) }); }
                input = Console.ReadLine().Split("||");
            }
            input = Console.ReadLine().Split("=>");
            while (input[0] != "End")
            {
                if (input[0] == "Plunder")
                {
                    double people = double.Parse(input[2]), gold = double.Parse(input[3]);
                    cities[input[1]][0] -= people; cities[input[1]][1] -= gold;
                    Console.WriteLine($"{input[1]} plundered! {gold} gold stolen, {people} citizens killed.");
                    if (cities[input[1]][0] == 0 || cities[input[1]][1] == 0)
                    { cities.Remove(input[1]); Console.WriteLine($"{input[1]} has been wiped off the map!"); }
                }
                else
                {
                    double gold = double.Parse(input[2]);
                    if(gold < 0) { Console.WriteLine("Gold added cannot be a negative number!"); }
                    else
                    {
                        cities[input[1]][1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {input[1]} now has {cities[input[1]][1]} gold.");
                    }
                }
                input = Console.ReadLine().Split("=>");
            }
            cities = cities.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            if (cities.Count == 0)
            { Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!"); }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var t in cities)
                { Console.WriteLine($"{t.Key} -> Population: {t.Value[0]} citizens, Gold: {t.Value[1]} kg"); }
            }
        }
    }
}
