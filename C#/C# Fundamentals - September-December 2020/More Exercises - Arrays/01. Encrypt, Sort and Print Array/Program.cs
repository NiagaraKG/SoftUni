using System;

namespace _01._Encrypt__Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = new string[n];
            int[] output = new int[n];
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = Console.ReadLine();
            }            
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] == 'A' || input[i][j] == 'E' || input[i][j] == 'I' || input[i][j] == 'O' || input[i][j] == 'U'
                        || input[i][j] == 'a' || input[i][j] == 'e' || input[i][j] == 'i' || input[i][j] == 'o' || input[i][j] == 'u') 
                    { output[i] += input[i][j] * input[i].Length; }
                    else { output[i] += input[i][j] / input[i].Length; }
                }
            }
            Array.Sort(output);
            Console.WriteLine(string.Join('\n', output));
        }
    }
}
