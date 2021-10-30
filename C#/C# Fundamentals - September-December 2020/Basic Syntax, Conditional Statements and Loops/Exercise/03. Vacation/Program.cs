using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 1;
            switch (type)
            {
                case "Students":
                    switch (day)
                    {
                        case "Friday":
                            price = people * 8.45; break;
                        case "Saturday":
                            price = people * 9.80; break;
                        case "Sunday":
                            price = people * 10.46; break;
                    }
                    if (people >= 30) { price *= 0.85; }
                    break;
                case "Business":
                    if (people >= 100) { people -= 10; }
                    switch (day)
                    {
                        case "Friday":
                            price = people * 10.90; break;
                        case "Saturday":
                            price = people * 15.60; break;
                        case "Sunday":
                            price = people * 16; break;
                    }
                    break;
                case "Regular":
                    switch (day)
                    {
                        case "Friday":
                            price = people * 15; break;
                        case "Saturday":
                            price = people * 20; break;
                        case "Sunday":
                            price = people * 22.50; break;
                    }
                    if (people >= 10 && people <= 20) { price *= 0.95; }
                    break;
            }
            Console.WriteLine($"Total price: {price:F2}");
        }
    }
}
