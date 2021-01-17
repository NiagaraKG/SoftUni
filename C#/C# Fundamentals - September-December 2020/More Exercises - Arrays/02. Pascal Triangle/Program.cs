using System;
using System.Linq;

namespace _02._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string printed = "1";
            Console.WriteLine(printed);
            for (int row = 1; row < n; row++)
            {
                printed += " 0";
                int[] last = printed.Split().Select(int.Parse).ToArray();
                int[] current = new int[last.Length];
                current[0] = 1;
                for (int col = 1; col < row; col++)
                {
                    current[col] = last[col] + last[col - 1];
                }
                current[current.Length - 1] = 1;
                printed = string.Join(' ', current);
                Console.WriteLine(printed);
            }
        }
    }    
}

