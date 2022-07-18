using System;

namespace CombinatorialProblems
{
    public class Program
    {
        private static int k;
        private static string[] elements;
        private static string[] variations;
        private static bool[] used;
        public static void Main()
        {
            elements = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());
            variations = new string[k];
            used = new bool[elements.Length];
            Variate(0);
        }

        private static void Variate(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(String.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variations[index] = elements[i];
                    Variate(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}