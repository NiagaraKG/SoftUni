using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustion = int.Parse(Console.ReadLine());
            int targets = 0;
            double half = power / 2.0;
            while(power >= distance)
            {
                power -= distance;
                targets++;
                if(power == half && exhaustion != 0)
                { power /= exhaustion; }
            }
            Console.WriteLine(power);
            Console.WriteLine(targets);
        }
    }
}
