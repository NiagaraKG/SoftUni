using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MOBA_Challenger
{
    class Position
    {
        public string position;
        public int skill;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Position>> players = new Dictionary<string, List<Position>>();
            Dictionary<string, int> totals = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while (input != "Season end")
            {
                if (input.Contains("vs"))
                {
                    string[] command = input.Split(" vs ");
                    if (players.ContainsKey(command[0]) && players.ContainsKey(command[1]))
                    {
                        bool haveCommon = false;
                        foreach (var p1 in players[command[0]])
                        {
                            foreach (var p2 in players[command[1]])
                            {
                                if (p1.position == p2.position) { haveCommon = true; break; }
                            }
                            if (haveCommon) { break; }
                        }
                        if (haveCommon)
                        {
                            if (totals[command[0]] > totals[command[1]])
                            {
                                totals.Remove(command[1]);
                                players.Remove(command[1]);
                            }
                            else if (totals[command[0]] < totals[command[1]])
                            {
                                totals.Remove(command[0]);
                                players.Remove(command[0]);
                            }
                        }
                    }
                }
                else
                {
                    string[] command = input.Split(" -> "); string name = command[0];
                    Position p = new Position(); p.position = command[1]; p.skill = int.Parse(command[2]);
                    if (players.ContainsKey(name))
                    {
                        bool isFound = false;
                        foreach (var current in players[name])
                        {
                            if (current.position == p.position)
                            {
                                isFound = true;
                                if (p.skill > current.skill)
                                { totals[name] -= current.skill; current.skill = p.skill;  totals[name] += p.skill; }
                            }
                        }
                        if (!isFound) { players[name].Add(p); totals[name] += p.skill; }
                    }
                    else { players.Add(name, new List<Position> { p }); totals.Add(name, p.skill); }
                }
                input = Console.ReadLine();
            }
            players = players.OrderByDescending(x => totals[x.Key]).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            foreach (var p in players)
            {
                Console.WriteLine($"{p.Key}: {totals[p.Key]} skill");
                foreach (var s in p.Value.OrderByDescending(x => x.skill).ThenBy(x => x.position))
                {
                    Console.WriteLine($"- {s.position} <::> {s.skill}");
                }
            }
        }
    }
}
