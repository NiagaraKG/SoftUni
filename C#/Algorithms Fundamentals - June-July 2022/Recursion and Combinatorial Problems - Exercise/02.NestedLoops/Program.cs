using System;

namespace RecursionExercise
{
    public class Program
    {
        private static int[] numbers;
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            numbers = new int[n];
            Generate(0);
        }

        private static void Generate(int index)
        {
            if (index >= numbers.Length)
            {
                Console.WriteLine(string.Join(" ", numbers));
                return;
            }
            for (int i = 1; i <= numbers.Length; i++)
            {
                numbers[index] = i;
                Generate(index + 1);
            }
        }
    }
}