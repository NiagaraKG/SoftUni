using System;
using System.Linq;

namespace RecursionAndBacktracking
{
    public class Program
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(Sum(arr, 0));
        }

        public static int Sum(int[] arr, int i)
        {
            if (i == arr.Length - 1) { return arr[i]; }
            return arr[i] + Sum(arr, i + 1);
        }

    }
}