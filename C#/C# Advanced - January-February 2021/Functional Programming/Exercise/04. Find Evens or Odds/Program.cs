using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> numbers = new List<int>();
            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }
            string criteria = Console.ReadLine();
            Predicate<int> p;
            if(criteria == "even") { p = n => n % 2 == 0; }
            else { p = n => n % 2 != 0; }
            numbers = Filter(numbers, p);
            Console.WriteLine(string.Join(" ", numbers));
        }
        static List<int> Filter(List<int> numbers, Predicate<int> p)
        {
            List<int> filtered = new List<int>();
            foreach (var n in numbers)                   
            {
                if(p(n))
                {
                    filtered.Add(n);
                }
            }
            return filtered;
        }
    }
}
