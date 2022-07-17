using System;

namespace CombinatorialProblems
{
    public class Program
    {
        private static string[] elements;
        
        public static void Main()
        {
            elements = Console.ReadLine().Split();            
            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(String.Join(" ", elements));
                return;
            }
            Permute(index + 1);
            for (int i = index+1; i < elements.Length; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }

        /*private static string[] elements;
        private static string[] permutations;
        private static bool[] used;
        public static void Main()
        {
            elements = Console.ReadLine().Split();
            permutations = new string[elements.Length];
            used = new bool[elements.Length];
            Permute(0);
        }

        private static void Permute(int index)
        {
            if(index >= permutations.Length)
            {
                Console.WriteLine(String.Join(" ", permutations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if(!used[i])
                {
                    used[i] = true;
                    permutations[index] = elements[i];
                    Permute(index + 1);
                    used[i] = false;
                }
            }
        }*/
    }
}