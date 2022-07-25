using System;
using System.Linq;

namespace SearchingSortingAndGreedyAlgorithms
{
    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            numbers = MergeSort(numbers);
            Console.WriteLine(String.Join(" ", numbers));
        }

        private static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length <= 1) { return numbers; }
            var left = numbers.Take(numbers.Length / 2).ToArray();
            var right = numbers.Skip(numbers.Length / 2).ToArray();
            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int[] merged = new int[left.Length + right.Length];
            int m = 0, l = 0, r = 0;
            while (l < left.Length && r < right.Length)
            {
                if(left[l] < right[r])
                {
                    merged[m] = left[l];                    
                    l++;
                }
                else
                {
                    merged[m] = right[r];
                    r++;
                }
                m++;
            }
            for (int i = l; i < left.Length; i++)
            {
                merged[m] = left[i];
                m++;
            }
            for (int i = r; i < right.Length; i++)
            {
                merged[m] = right[i];
                m++;
            }
            return merged;
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            int temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}