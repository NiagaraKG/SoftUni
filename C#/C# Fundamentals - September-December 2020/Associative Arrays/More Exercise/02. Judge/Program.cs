using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Judge
{
    class Participant
    {
        public string name;
        public int points;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Participant>> contests = new Dictionary<string, List<Participant>>();
            Dictionary<string, int> totals = new Dictionary<string, int>();
            string[] input = Console.ReadLine().Split(" -> ");
            while (input[0] != "no more time")
            {
                string user = input[0], contest = input[1]; int points = int.Parse(input[2]);
                Participant current = new Participant(); current.name = user; current.points = points;
                if (contests.ContainsKey(contest))
                {
                    bool isFound = false;
                    foreach (var item in contests[contest])
                    {
                        if (user == item.name)
                        {
                            isFound = true;
                            if (points > item.points)
                            {
                                totals[user] -= item.points; totals[user] += points;
                                item.points = points;
                            }
                            break;
                        }
                    }
                    if (!isFound)
                    {
                        contests[contest].Add(current);
                        if (totals.ContainsKey(user)) { totals[user] += points; } else { totals.Add(user, points); }
                    }
                }
                else
                {
                    contests.Add(contest, new List<Participant> { current });
                    if (totals.ContainsKey(user)) { totals[user] += points; } else { totals.Add(user, points); }
                }
                input = Console.ReadLine().Split(" -> ");
            }
            foreach (var c in contests)
            {
                Console.WriteLine($"{c.Key}: {c.Value.Count} participants");
                int index = 1;
                foreach (var item in c.Value.OrderByDescending(x => x.points).ThenBy(x=>x.name))
                {
                    Console.WriteLine($"{index}. {item.name} <::> {item.points}"); index++;
                }
            }
            Console.WriteLine("Individual standings:");
            int i = 1;
            foreach (var item in totals.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{i}. {item.Key} -> {item.Value}"); i++;
            }
        }
    }
}
