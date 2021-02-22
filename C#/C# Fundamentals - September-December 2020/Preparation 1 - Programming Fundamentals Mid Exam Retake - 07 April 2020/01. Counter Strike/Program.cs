using System;

namespace _01._Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int wins = 0;
            while (command != "End of battle" && energy >= 0)
            {
                int distance = int.Parse(command);
                if(distance <= energy)
                {
                    energy -= distance;
                    wins++;
                    if (wins % 3 == 0) { energy += wins; }
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {energy} energy");
                    return;
                }
                command = Console.ReadLine();
            }
            if (command == "End of battle") { Console.WriteLine($"Won battles: {wins}. Energy left: {energy}"); }
        }
    }
}
