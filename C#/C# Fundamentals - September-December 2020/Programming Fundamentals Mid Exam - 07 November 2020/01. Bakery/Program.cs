using System;

namespace _01._Bakery
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsPerDay = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            double othersBuiscuits = int.Parse(Console.ReadLine());
            double biscuits = 0;
            biscuitsPerDay *= workers;
            for (int i = 1; i <= 30; i++)
            {
                double produced = biscuitsPerDay;
                if(i % 3 == 0)
                {
                    produced = Math.Floor(0.75*produced);
                }
                biscuits += produced;
            }
            Console.WriteLine($"You have produced {biscuits} biscuits for the past month.");
            double percentage = 0;
            if(biscuits > othersBuiscuits)
            {
                percentage = 100.00 * (biscuits - othersBuiscuits) / othersBuiscuits;
                Console.WriteLine($"You produce {percentage:F2} percent more biscuits.");
            }
            else
            {
                percentage = 100.00 * (othersBuiscuits - biscuits) / othersBuiscuits;
                Console.WriteLine($"You produce {percentage:F2} percent less biscuits.");
            }
        }
    }
}
