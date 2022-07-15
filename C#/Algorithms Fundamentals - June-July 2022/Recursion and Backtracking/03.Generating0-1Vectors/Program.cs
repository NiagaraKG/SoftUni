using System;

namespace RecursionAndBacktracking
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            GenerateVectors(new int[n], 0);
        }

        public static void GenerateVectors(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(string.Empty, arr));
                return;
            }
            for (int i = 0; i < 2; i++)
            {
                arr[index] = i;
                GenerateVectors(arr, index + 1);
            }
        }

    }
}