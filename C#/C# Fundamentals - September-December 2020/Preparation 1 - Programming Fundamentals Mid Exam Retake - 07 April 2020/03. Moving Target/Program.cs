using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split().ToArray();
            while (command[0] != "End")
            {
                int index = int.Parse(command[1]);
                int second = int.Parse(command[2]);
                if (command[0] == "Shoot")
                {
                    if (index >= 0 && index < targets.Count)
                    {
                        targets[index] -= second;
                        if (targets[index] <= 0) { targets.RemoveAt(index); }
                    }
                }
                else if (command[0] == "Add")
                {
                    if (index >= 0 && index < targets.Count) { targets.Insert(index, second); }
                    else { Console.WriteLine("Invalid placement!"); }
                }
                else
                {
                    int start = index - second, end = index + second;
                    if (start >= 0 && start < targets.Count && end < targets.Count)
                    { targets.RemoveRange(start, 2 * second + 1); }
                    else { Console.WriteLine("Strike missed!"); }
                }
                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine(string.Join("|", targets));
        }
    }
}
