using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int s = Sum(arr, 0);
            Console.WriteLine(s);
        }

        private static int Sum(int[] arr, int index)
        {
            if(index == arr.Length - 1) { return arr[index]; }
            return arr[index] + Sum(arr, index+1);
        }
    }
}
