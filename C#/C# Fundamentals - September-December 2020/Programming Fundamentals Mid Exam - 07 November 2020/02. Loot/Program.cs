using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Loot
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            while(command[0] != "Yohoho!")
            {
                if(command[0] == "Loot")
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        if(!chest.Contains(command[i]))
                        {
                            chest.Insert(0, command[i]);
                        }
                    }
                }
                else if(command[0] == "Drop")
                {
                    int index = int.Parse(command[1]);
                    if (index>=0 && index < chest.Count)
                    {
                        string item = chest[index];
                        chest.RemoveAt(index);
                        chest.Add(item);
                    }
                }
                else if(command[0] == "Steal")
                {
                    int count = int.Parse(command[1]);
                    List<string> stolen = new List<string>();
                    if(count > chest.Count) { count = chest.Count; }
                    for (int i = 0; i < count; i++)
                    {
                        stolen.Insert(0, chest.Last());
                        chest.RemoveAt(chest.Count - 1);
                    }
                    Console.WriteLine(string.Join(", ", stolen));

                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            double Av = 0;
            if (chest.Count == 0) { Av = 0; Console.WriteLine("Failed treasure hunt."); }
            else
            {
                for (int i = 0; i < chest.Count; i++)
                {
                    Av += chest[i].Length;
                }
                Av /= chest.Count;
                Console.WriteLine($"Average treasure gain: {Av:F2} pirate credits.");
            }
        }
    }
}
