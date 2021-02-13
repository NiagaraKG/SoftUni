using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();
            List<double> left = new List<double>();
            List<double> right = new List<double>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i < numbers.Count / 2)
                { left.Add(numbers[i]); }
                else if (i > numbers.Count / 2)
                { right.Add(numbers[i]); }
            }
            double vleft = 0, vright = 0;
            for (int i = 0; i < left.Count; i++)
            {
                vleft += left[i];
                if(left[i] == 0)
                { vleft *= 0.8; }
            }
            right.Reverse();
            for (int i = 0; i < right.Count; i++)
            {
                vright += right[i];
                if(right[i] == 0)
                { vright *= 0.8; }
            }
            if(vleft<vright) { Console.WriteLine("The winner is left with total time: " + vleft); }
            else { Console.WriteLine("The winner is right with total time: " + vright); }
        }
    }
}
