using System;
using System.Linq;

namespace SearchingSortingAndGreedyAlgorithms
{
    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(BinarySearch(n, numbers));
        }

        private static int BinarySearch(int n, int[] numbers)
        {
            int left = 0, right = numbers.Length-1;
            while (left <= right)
            {
                var mid = (left + right) / 2;
                if (numbers[mid] == n)
                {
                    return mid;
                }
                if(numbers[mid] < n)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }
    }
}