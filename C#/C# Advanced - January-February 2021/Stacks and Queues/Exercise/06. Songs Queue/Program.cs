using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            Queue<string> songs = new Queue<string>(input);
            while (songs.Any())
            {
                string command = Console.ReadLine();
                if (command == "Show") { Console.WriteLine(string.Join(", ", songs)); }
                else if (command == "Play") { songs.Dequeue(); }
                else
                {
                    command = command.Remove(0, 4);
                    if (songs.Contains(command)) { Console.WriteLine(command + " is already contained!"); }
                    else { songs.Enqueue(command); }
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
