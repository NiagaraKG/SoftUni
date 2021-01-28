using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> list = Console.ReadLine().Split().Select(double.Parse).Where(n => n >= 0).ToList();
            if(list.Count == 0) { Console.WriteLine("empty"); }
            else
            {
                list.Reverse();
                Console.WriteLine(string.Join(' ', list));
            }
        }
    }
}
