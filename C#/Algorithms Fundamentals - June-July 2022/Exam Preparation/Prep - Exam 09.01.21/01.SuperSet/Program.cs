using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_01_21
{
    public class Program
    {
        private static string[] elements;
        private static string[] combinations;
        public static void Main()
        {
            elements = Console.ReadLine().Split(", ");
            for (int i = 0; i <= elements.Length; i++)
            {
                combinations = new string[i];
                Combine(0,0);
            }            
        }

        private static void Combine(int index, int start)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(String.Join(" ", combinations));
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                combinations[index] = elements[i];
                Combine(index + 1, i + 1);
            }
        }
    }
}
