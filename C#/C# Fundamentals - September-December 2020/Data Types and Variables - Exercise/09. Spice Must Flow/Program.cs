using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int days = 0, total = 0;
            while (yield >= 100)
            {
                total += yield;
                yield -= 10;
                if (total >= 26) { total -= 26; }
                days++;
            }
            if(total >= 26) { total -= 26; }
            Console.WriteLine(days);
            Console.WriteLine(total);
        }
    }
}
