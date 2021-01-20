using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int green = int.Parse(Console.ReadLine());
            int window = int.Parse(Console.ReadLine());
            int passed = 0;
            bool left = false;
            Queue<string> cars = new Queue<string>();
            string command = Console.ReadLine();
            while (command != "END")
            {
                if (command == "green")
                {
                    string current = "";
                    int time = 0;
                    while (time < green && cars.Any())
                    {
                        current = cars.Dequeue();
                        time += current.Length;
                        if (time > green)
                        {
                            time = time - green; left = true; break;
                        }
                        else { passed++; }
                    }
                    if (left == true)
                    {
                        if (time > window)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine(current + $" was hit at {current[current.Length - time + window]}.");
                            return;
                        }
                        else { passed++; }
                    }
                }
                else { cars.Enqueue(command); }
                command = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine(passed + " total cars passed the crossroads.");
        }
    }
}
