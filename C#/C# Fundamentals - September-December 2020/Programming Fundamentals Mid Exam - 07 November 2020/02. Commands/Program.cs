using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Commands
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> collection = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (command[0] != "end")
            {
                if (command[0] == "sort")
                {
                    int start = int.Parse(command[2]);
                    int count = int.Parse(command[4]);
                    int last = start + count - 1;
                    List<string> sorted = new List<string>();
                    for (int i = start; i <= last; i++)
                    {
                        sorted.Add(collection[i]);
                    }
                    sorted.Sort();
                    int j = 0;
                    for (int i = start; i <= last; i++)
                    {
                        collection[i] = sorted[j];
                        j++;
                    }
                }
                else if(command[0] == "reverse")
                {
                    int start = int.Parse(command[2]);
                    int count = int.Parse(command[4]);
                    int last = start + count - 1;
                    List<string> reversed = new List<string>();
                    for (int i = start; i <= last; i++)
                    {
                        reversed.Add(collection[i]);
                    }
                    reversed.Reverse();
                    int j = 0;
                    for (int i = start; i <= last; i++)
                    {
                        collection[i] = reversed[j];
                        j++;
                    }
                }
                else if(command[0] == "remove")
                {
                    int count = int.Parse(command[1]);
                    collection.RemoveRange(0, count);
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            Console.WriteLine(string.Join(", ", collection));
        }
    }
}
