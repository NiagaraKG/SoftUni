using System;
using System.Collections.Generic;
using System.Linq;

namespace RecursionExercise
{
    public class Program
    {
        public static void Main()
        {
            var girls = Console.ReadLine().Split(", ");
            var gComb = new string[3];
            var gCombinations = new List<string[]>();
            var boys = Console.ReadLine().Split(", ");
            var bComb = new string[2];
            var bCombinations = new List<string[]>();
            Combine(0, 0, girls, gComb, gCombinations);
            Combine(0, 0, boys, bComb, bCombinations);
            foreach (var g in gCombinations)
            {
                foreach (var b in bCombinations)
                {
                    Console.WriteLine($"{string.Join(", ", g)}, {string.Join(", ", b)}");
                }
            }
        }

        private static void Combine(int index, int start, string[] elements, string[] comb, List<string[]> combinations)
        {
            if (index >= comb.Length)
            {
                combinations.Add(comb.ToArray());
                return;
            }
            for (int i = start; i < elements.Length; i++)
            {
                comb[index] = elements[i];
                Combine(index + 1, i + 1, elements, comb, combinations);
            }
        }
    }
}