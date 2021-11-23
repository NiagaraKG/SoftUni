using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Drum_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            List<int> initialQuality = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> currentQuality = new List<int> (initialQuality);
            string hit = Console.ReadLine();
            while (hit != "Hit it again, Gabsy!")
            {
                int power = int.Parse(hit);
                for (int i = 0; i < currentQuality.Count; i++)
                {
                    currentQuality[i] -= power;
                    if(currentQuality[i] <= 0)
                    {
                        double price = initialQuality[i] * 3.00;
                        if(price<=money)
                        {
                            money -= price;
                            currentQuality[i] = initialQuality[i];
                        }
                        else
                        {
                            currentQuality.RemoveAt(i);
                            initialQuality.RemoveAt(i);
                            i--;
                        }
                    }
                }
                hit = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', currentQuality));
            Console.WriteLine($"Gabsy has {money:F2}lv.");
        }
    }
}
