using System;

namespace _01._World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();
            string[] command = Console.ReadLine().Split(":");
            while (command[0] != "Travel")
            {
                if (command[0] == "Add Stop")
                {
                    int index = int.Parse(command[1]);
                    if (index >= 0 && index < stops.Length)
                    {
                        stops = stops.Insert(index, command[2]);
                    }
                }
                else if (command[0] == "Remove Stop")
                {
                    int start = int.Parse(command[1]), end = int.Parse(command[2]);
                    if (start >= 0 && end < stops.Length)
                    {
                        stops = stops.Remove(start, end - start + 1);
                    }
                }
                else if (command[0] == "Switch")
                {
                    if (stops.Contains(command[1]))
                    {
                        stops = stops.Replace(command[1], command[2]);
                    }
                }
                Console.WriteLine(stops);
                command = Console.ReadLine().Split(":");
            }
            Console.WriteLine("Ready for world tour! Planned stops: " + stops);
        }
    }
}
