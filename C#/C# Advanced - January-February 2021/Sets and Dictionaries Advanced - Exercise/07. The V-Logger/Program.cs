using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Follows> vloggers = new Dictionary<string, Follows>();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "Statistics")
            {
                if (command[1] == "joined")
                {
                    if (!vloggers.ContainsKey(command[0]))
                    {
                        vloggers.Add(command[0], new Follows());
                    }
                }
                else if (command[1] == "followed")
                {
                    if (vloggers.ContainsKey(command[0]) && vloggers.ContainsKey(command[2]) && command[0] != command[2])
                    {
                        if (!vloggers[command[2]].followers.Contains(command[0]))
                        {
                            vloggers[command[2]].followers.Add(command[0]);
                            vloggers[command[0]].following++;
                        }
                    }
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            string first = "";
            int max = int.MinValue;
            foreach (var v in vloggers)
            {
                if (v.Value.followers.Count > max) { first = v.Key; max = v.Value.followers.Count; }
                if (v.Value.followers.Count == max && v.Value.following < vloggers[first].following) { first = v.Key; }
            }
            Console.WriteLine($"1. {first} : {max} followers, { vloggers[first].following} following");
            foreach (var follower in vloggers[first].followers) { Console.WriteLine("*  " + follower); }
            vloggers.Remove(first);
            int num = 2;
            foreach (var v in vloggers.OrderByDescending(x=>x.Value.followers.Count).ThenBy(x=>x.Value.following))
            {
                Console.WriteLine($"{num}. {v.Key} : {v.Value.followers.Count} followers, {v.Value.following} following");
                num++;
            }
        }
    }
    class Follows
    {
        public SortedSet<string> followers;
        public int following;
        public Follows()
        {
            this.followers = new SortedSet<string>();
            this.following = 0;
        }
    }
}
