using System;
using System.Linq;

namespace SearchingSortingAndGreedyAlgorithms
{
    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            QuickSort(numbers, 0, numbers.Length-1);
            Console.WriteLine(String.Join(" ", numbers));
        }

        private static void QuickSort(int[] numbers, int start, int end)
        {
            if(start > end) { return; }
            int pivot = start;
            int left = start + 1;
            int right = end;
            while (left <= right)
            {
                if (numbers[left] > numbers[pivot] && numbers[pivot] > numbers[right])
                {
                    Swap(numbers, left, right);
                }
                if(numbers[left] <= numbers[pivot]) { left++; }
                if(numbers[right] >= numbers[pivot]) { right--; }
            }
            Swap(numbers, pivot, right);
            QuickSort(numbers, start, right - 1);
            QuickSort(numbers, right + 1, end);
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            int temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}