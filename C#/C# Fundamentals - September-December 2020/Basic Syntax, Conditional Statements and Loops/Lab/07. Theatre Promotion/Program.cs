using System;

namespace _07._Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());
            int price = 0;
            if(0 <= age && age <= 18)
            {
                switch (day)
                {
                    case "weekday": price = 12; break;
                    case "weekend": price = 15; break;
                    case "holiday": price = 5; break;
                }
            }
            else if (18 < age && age <= 64)
            {
                switch (day)
                {
                    case "weekday": price = 18; break;
                    case "weekend": price = 20; break;
                    case "holiday": price = 12; break;
                }
            }
            else if (64 < age && age <= 122)
            {
                switch (day)
                {
                    case "weekday": price = 12; break;
                    case "weekend": price = 15; break;
                    case "holiday": price = 10; break;
                }
            }
            if(price != 0)
            {
                Console.WriteLine(price + "$");
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
