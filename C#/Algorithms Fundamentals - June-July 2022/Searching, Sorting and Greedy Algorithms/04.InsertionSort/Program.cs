using System;
using System.Linq;

namespace SearchingSortingAndGreedyAlgorithms
{
    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            InsertionSort(numbers);
            Console.WriteLine(String.Join(" ", numbers));
        }

        private static void InsertionSort(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                int j = i;
                while (j > 0 && numbers[j-1] > numbers[j])
                {
                    Swap(numbers, j, j - 1);
                    j--;
                }
            }
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            int temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}