using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Quicksort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Quick.Sort(numbers, 0, numbers.Count-1);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
    public class Quick
    {
        public static void Sort(List<int> array, int left, int right)
        {
            if (left < right)
            {
                var partitionIndex = Partition(array, left, right);
                Sort(array, left, partitionIndex);
                Sort(array, partitionIndex + 1, right);
            }
        }
        static int Partition(List<int> array, int left, int right)
        {
            int pivot = array[(left + right) / 2];
            int i = left - 1;
            int j = right + 1;
            while (true)
            {
                do { i++; } while (array[i] < pivot);
                do { j--; } while (array[j] > pivot);
                if (i >= j) { return j; }
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}
