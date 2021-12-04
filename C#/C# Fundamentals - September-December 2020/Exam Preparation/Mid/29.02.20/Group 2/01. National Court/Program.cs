using System;

namespace _01._National_Court
{
    class Program
    {
        static void Main(string[] args)
        {
            int f = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());
            int t = int.Parse(Console.ReadLine());
            int all = int.Parse(Console.ReadLine());
            int h = 0, hour = f + s + t;
            while(all>0)
            {
                all -= hour;
                h++;
                if (h % 4 == 0) { h++; }
            }
            Console.WriteLine($"Time needed: {h}h.");
        }
    }
}
