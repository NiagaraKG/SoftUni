using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cities_by_Continent_and_Country
{
    class Country
    {
        public string name;
        public List<string> cities;
        public Country(string country, string town)
        {
            this.name = country;
            this.cities = new List<string> { town };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Country>> continents = new Dictionary<string, List<Country>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (continents.ContainsKey(input[0]))
                {
                    bool foundCountry = false;
                    for (int j = 0; j < continents[input[0]].Count; j++)
                    {
                        if (continents[input[0]][j].name == input[1])
                        {
                            foundCountry = true;
                            continents[input[0]][j].cities.Add(input[2]); 
                        }
                    }
                    if (!foundCountry) { continents[input[0]].Add(new Country(input[1], input[2])); }
                }
                else { continents.Add(input[0], new List<Country> { new Country(input[1], input[2]) }); }
            }
            foreach (var continent in continents)
            {
                Console.WriteLine(continent.Key + ":");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine(country.name + " -> " + string.Join(", ", country.cities));
                }
            }
        }
    }
}
