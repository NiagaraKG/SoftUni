using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Ranking
{
    class Contest
    {
        public string name;
        public int points;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> passwords = new Dictionary<string, string>();
            Dictionary<string, int> totals = new Dictionary<string, int>();
            Dictionary<string, List<Contest>> participants = new Dictionary<string, List<Contest>>();
            string[] input = Console.ReadLine().Split(":");
            while (input[0] != "end of contests")
            {
                passwords.Add(input[0], input[1]);
                input = Console.ReadLine().Split(":");
            }
            input = Console.ReadLine().Split("=>");
            while (input[0] != "end of submissions")
            {
                if (passwords.ContainsKey(input[0]) && passwords[input[0]] == input[1])
                {
                    if (totals.ContainsKey(input[2]))
                    {
                        totals[input[2]] += int.Parse(input[3]);
                        bool isFound = false;
                        for (int i = 0; i < participants[input[2]].Count; i++)
                        {
                            if (participants[input[2]][i].name == input[0])
                            {
                                isFound = true;
                                if (participants[input[2]][i].points < int.Parse(input[3]))
                                {
                                    totals[input[2]] -= participants[input[2]][i].points;
                                    participants[input[2]][i].points = int.Parse(input[3]);
                                }
                                else { totals[input[2]] -= int.Parse(input[3]); }
                                break;
                            }
                        }
                        Contest current = new Contest(); current.name = input[0]; current.points = int.Parse(input[3]);
                        if (!isFound) { participants[input[2]].Add(current); }
                    }
                    else
                    {
                        totals.Add(input[2], int.Parse(input[3]));
                        Contest current = new Contest(); current.name = input[0]; current.points = int.Parse(input[3]);
                        participants.Add(input[2], new List<Contest> { current });
                    }
                }
                input = Console.ReadLine().Split("=>");
            }
            totals = totals.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            Console.WriteLine($"Best candidate is {totals.First().Key} with total {totals.First().Value} points.");
            participants = participants.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            Console.WriteLine("Ranking: ");
            foreach (var p in participants)
            {
                Console.WriteLine(p.Key);
                foreach (var c in p.Value.OrderByDescending(x => x.points))
                {
                    Console.WriteLine($"#  {c.name} -> {c.points}");
                }
            }
        }
    }
}
