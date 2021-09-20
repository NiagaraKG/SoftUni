using System;
using System.Linq;

namespace _06._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum1 = 0, sum2 = 0;
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (int i in arr) 
            {
                if (i % 2 == 0) { sum1 += i; }
                else { sum2 += i; }
            }            
            Console.WriteLine(sum1 - sum2);
        }
    }
}
