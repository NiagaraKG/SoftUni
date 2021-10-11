using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> pieces = new Dictionary<string, List<string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] current = Console.ReadLine().Split("|");
                pieces.Add(current[0], new List<string> { current[1], current[2] });
            }
            string[] command = Console.ReadLine().Split("|");
            while (command[0] != "Stop")
            {
                if (command[0] == "Add")
                {
                    if (pieces.ContainsKey(command[1]))
                    { Console.WriteLine($"{command[1]} is already in the collection!"); }
                    else
                    {
                        pieces.Add(command[1], new List<string> { command[2], command[3] });
                        Console.WriteLine($"{command[1]} by {command[2]} in {command[3]} added to the collection!");
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (pieces.ContainsKey(command[1]))
                    {
                        pieces.Remove(command[1]);
                        Console.WriteLine($"Successfully removed {command[1]}!");
                    }
                    else { Console.WriteLine($"Invalid operation! {command[1]} does not exist in the collection."); }
                }
                else if(command[0] == "ChangeKey")
                {
                    if(pieces.ContainsKey(command[1]))
                    {
                        pieces[command[1]][1] = command[2];
                        Console.WriteLine($"Changed the key of {command[1]} to {command[2]}!");
                    }
                    else { Console.WriteLine($"Invalid operation! {command[1]} does not exist in the collection."); }
                }
                command = Console.ReadLine().Split("|");
            }
            pieces = pieces.OrderBy(x => x.Key).ThenBy(x => x.Value[0]).ToDictionary(x => x.Key, y => y.Value);
            foreach (var p in pieces)
            {
                Console.WriteLine($"{p.Key} -> Composer: {p.Value[0]}, Key: {p.Value[1]}");
            }
        }
    }
}
