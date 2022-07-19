using System;

namespace CombinatorialProblems
{
    public class Program
    {
        private static int k;
        private static string[] elements;
        private static string[] combinations;
        public static void Main()
        {
            elements = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());
            combinations = new string[k];
            Combine(0, 0);
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
                Combine(index + 1, i);
            }
        }
    }
}