using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> neighbourhood = Console.ReadLine().Split("@").Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();
            int index = 0;
            while(command[0] != "Love!")
            {
                index += int.Parse(command[1]);
                if(index >= neighbourhood.Count) { index = 0; }
                if(neighbourhood[index] != 0)
                { 
                    neighbourhood[index] -= 2;
                    if(neighbourhood[index] == 0) { Console.WriteLine($"Place {index} has Valentine's day."); }
                }
                else { Console.WriteLine($"Place {index} already had Valentine's day."); }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine($"Cupid's last position was {index}.");
            bool isSucessful = true;
            int br = 0;
            foreach (var item in neighbourhood)
            {
                if(item != 0) { isSucessful = false; br++; }
            }
            if(isSucessful) { Console.WriteLine("Mission was successful."); }
            else { Console.WriteLine($"Cupid has failed {br} places."); }
        }
    }
}
