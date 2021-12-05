using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> grocery = Console.ReadLine().Split("!").ToList();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "Go")
            {
                if (command[0] == "Urgent")
                {
                    if (!grocery.Contains(command[1]))
                    { grocery.Insert(0, command[1]); }
                }
                else if(command[0] == "Unnecessary")
                {
                    if (grocery.Contains(command[1]))
                    { grocery.Remove(command[1]); }
                }
                else if(command[0] == "Correct")
                {
                    if (grocery.Contains(command[1]))
                    {
                        grocery[grocery.FindIndex(x=>x==command[1])] = command[2];
                    }
                }
                else if (grocery.Contains(command[1]))
                {
                    grocery.Remove(command[1]);
                    grocery.Add(command[1]);
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(", ", grocery));
        }
    }
}
