using System;
using System.Linq;

namespace SearchingSortingAndGreedyAlgorithms
{
    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            BubbleSort(numbers);
            Console.WriteLine(String.Join(" ", numbers));
        }

        private static void BubbleSort(int[] numbers)
        {
            int sortedCount = 0;
            var isSorted = false;
            while(!isSorted)
            {
                isSorted = true;
                for (int i = 1; i < numbers.Length - sortedCount; i++)
                {
                    int j = i - 1;
                    if(numbers[j] > numbers[i])
                    {
                        Swap(numbers, i, j);
                        isSorted = false;
                    }
                }
                sortedCount++;
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