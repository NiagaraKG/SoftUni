using System;

namespace RecursionExercise
{
    public static class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split();
            Reverse(arr, 0);
            Console.WriteLine(String.Join(" ", arr));
        }

        private static void Reverse(string[] arr, int i)
        {
            if (i == arr.Length / 2) { return; }
            var temp = arr[i];
            arr[i] = arr[arr.Length - 1 - i];
            arr[arr.Length - 1 - i] = temp;
            Reverse(arr, i + 1);
        }
    }
}