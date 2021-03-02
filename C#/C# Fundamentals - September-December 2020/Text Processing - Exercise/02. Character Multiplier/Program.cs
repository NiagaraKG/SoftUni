using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int sum = 0;
            if (input[0].Length < input[1].Length)
            {
                for (int i = 0; i < input[0].Length; i++)
                {
                    sum += (int)input[0][i] * (int)input[1][i];
                }
                for (int i = input[0].Length; i < input[1].Length; i++)
                {
                    sum += (int)input[1][i];
                }
            }
            else 
            {
                for (int i = 0; i < input[1].Length; i++)
                {
                    sum += (int)input[0][i] * (int)input[1][i];
                }
                for (int i = input[1].Length; i < input[0].Length; i++)
                {
                    sum += (int)input[0][i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
