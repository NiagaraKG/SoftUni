using System;
using System.Data.SqlTypes;

namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double current = budget;
            string action = Console.ReadLine();
            while (action != "Game Time")
            {
                if(current == 0) { Console.WriteLine("Out of money!"); break; }
                switch (action)
                {
                    case "OutFall 4":
                        if(current >= 39.99)
                        {
                            current -= 39.99;
                            Console.WriteLine("Bought OutFall 4");
                        }
                        else { Console.WriteLine("Too Expensive"); }
                        break;
                    case "CS: OG":
                        if (current >= 15.99)
                        {
                            current -= 15.99;
                            Console.WriteLine("Bought CS: OG");
                        }
                        else { Console.WriteLine("Too Expensive"); }
                        break;
                    case "Zplinter Zell":
                        if (current >= 19.99)
                        {
                            current -= 19.99;
                            Console.WriteLine("Bought Zplinter Zell");
                        }
                        else { Console.WriteLine("Too Expensive"); }
                        break;
                    case "Honored 2":
                        if (current >= 59.99)
                        {
                            current -= 59.99;
                            Console.WriteLine("Bought Honored 2");
                        }
                        else { Console.WriteLine("Too Expensive"); }
                        break;
                    case "RoverWatch":
                        if (current >= 29.99)
                        {
                            current -= 29.99;
                            Console.WriteLine("Bought RoverWatch");
                        }
                        else { Console.WriteLine("Too Expensive"); }
                        break;
                    case "RoverWatch Origins Edition":
                        if (current >= 39.99)
                        {
                            current -= 39.99;
                            Console.WriteLine("Bought RoverWatch Origins Edition");
                        }
                        else { Console.WriteLine("Too Expensive"); }
                        break;
                    default: Console.WriteLine("Not Found"); break;
                }
                action = Console.ReadLine();
            }
            if (current != 0) { Console.WriteLine($"Total spent: ${(budget - current):F2}. Remaining: ${current:F2}"); }
            else { Console.WriteLine("Out of money!"); }

        }
    }
}
