using System;
using System.Collections.Generic;

namespace _08._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()), br = 0;
            string input = Console.ReadLine();
            Queue<string> vehicles = new Queue<string>();
            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (vehicles.Count == 0) { break; }
                        Console.WriteLine(vehicles.Dequeue() + " passed!"); br++;
                    }
                }
                else { vehicles.Enqueue(input); }
                input = Console.ReadLine();
            }
            Console.WriteLine(br + " cars passed the crossroads.");
        }
    }
}
