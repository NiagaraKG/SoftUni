using System;
using System.Numerics;

namespace _02._From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {                
                string[] line = Console.ReadLine().Split();
                long first = long.Parse(line[0]);
                long second = long.Parse(line[1]);
                long sum = 0;
                if(first > second)
                {
                    if(first < 0) { first *= -1; }
                    while(first > 0)
                    {
                        sum += first % 10;
                        first /= 10;
                    }
                }
                else
                {
                    if (second < 0) { second *= -1; }
                    while (second > 0)
                    {
                        sum += second % 10;
                        second /= 10;
                    }
                }
                Console.WriteLine(sum);
            }
        }
    }
}
