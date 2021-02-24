using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._School_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shelf = Console.ReadLine().Split("&").ToList();
            string[] command = Console.ReadLine().Split(" | ").ToArray();
            while (command[0] != "Done")
            {
                if (command[0] == "Add Book")
                {
                    if (!shelf.Contains(command[1])) { shelf.Insert(0, command[1]); }
                }
                else if (command[0] == "Take Book")
                {
                    if (shelf.Contains(command[1])) { shelf.Remove(command[1]); }
                }
                else if (command[0] == "Insert Book")
                { shelf.Add(command[1]); }
                else if (command[0] == "Swap Books")
                {
                    if (shelf.Contains(command[1]) && shelf.Contains(command[2]))
                    {
                        string buf = command[1];
                        int i1 = shelf.IndexOf(command[1]);
                        int i2 = shelf.IndexOf(command[2]);
                        shelf[i1] = shelf[i2];
                        shelf[i2] = buf;
                    }
                }
                else if(command[0] == "Check Book")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index < shelf.Count)
                    { Console.WriteLine(shelf[index]); }
                }
                command = Console.ReadLine().Split(" | ").ToArray();
            }
            Console.WriteLine(string.Join(", ", shelf));
        }
    }
}
