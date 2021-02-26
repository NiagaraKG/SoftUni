using System;
using System.Linq;

namespace _04._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(n=>n).ToArray();
            if(numbers.Length < 3) { Console.WriteLine(String.Join(" ", numbers)); }
            else { Console.WriteLine(numbers[0] + " " + numbers[1] + " " + numbers[2]); }
        }
    }
}
