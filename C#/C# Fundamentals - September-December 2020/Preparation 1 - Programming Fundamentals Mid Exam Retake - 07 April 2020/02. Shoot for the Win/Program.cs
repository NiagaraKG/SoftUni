using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse).ToList();
            int br = 0;
            string command = Console.ReadLine();
            while (command != "End")
            {
                int index = int.Parse(command);
                if (index >= 0 && index < targets.Count && targets[index] != -1)
                {
                    for (int i = 0; i < targets.Count; i++)
                    {
                        if (targets[i] > targets[index])
                        {
                            targets[i] -= targets[index];
                        }
                        else if (targets[i] != -1 && i != index)
                        {
                            targets[i] += targets[index];
                        }
                    }
                    targets[index] = -1;
                    br++;
                }
                command = Console.ReadLine();
            }
            Console.Write($"Shot targets: {br} -> ");
            Console.WriteLine(string.Join(" ", targets));
        }
    }
}
