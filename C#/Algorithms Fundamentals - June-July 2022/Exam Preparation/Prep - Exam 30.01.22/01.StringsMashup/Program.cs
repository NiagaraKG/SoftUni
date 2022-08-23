using System;
using System.Collections.Generic;
using System.Linq;

namespace _30_01_22
{
    public class Program
    {
        private static int k;
        private static char[] elements;
        private static char[] combination;

        public static void Main()
        {
            elements = Console.ReadLine().ToCharArray();
            Array.Sort(elements);
            k = int.Parse(Console.ReadLine());
            combination = new char[k];
            Combine(0, 0);
        }

        private static void Combine(int index, int start)
        {
            if (index >= combination.Length)
            {
                Console.WriteLine(String.Join("",combination));
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                combination[index] = elements[i];
                Combine(index + 1, i);
            }
        }
    }
}