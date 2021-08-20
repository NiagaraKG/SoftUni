using System;
using System.Linq;

namespace _04._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[dimentions[0], dimentions[1]];
            for (int r = 0; r < dimentions[0]; r++)
            {
                string[] row = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int c = 0; c < dimentions[1]; c++)
                {
                    matrix[r, c] = row[c];
                }
            }
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "END")
            {
                if(command[0] == "swap" && command.Length == 5)
                {
                    int r1 = int.Parse(command[1]);
                    int c1 = int.Parse(command[2]);
                    int r2 = int.Parse(command[3]);
                    int c2 = int.Parse(command[4]);
                    if(r1 < 0 || r2 < 0 || c1 < 0 || c2 < 0 || r1 >= matrix.GetLength(0) ||r2 >= matrix.GetLength(0) || c1 >= matrix.GetLength(1) || c2 >= matrix.GetLength(1))
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        string temp = matrix[r1, c1];
                        matrix[r1, c1] = matrix[r2, c2];
                        matrix[r2, c2] = temp;
                        for (int r = 0; r < matrix.GetLength(0); r++)
                        {
                            for (int c = 0; c < matrix.GetLength(1); c++)
                            {
                                Console.Write(matrix[r,c] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                }
                else { Console.WriteLine("Invalid input!"); }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
