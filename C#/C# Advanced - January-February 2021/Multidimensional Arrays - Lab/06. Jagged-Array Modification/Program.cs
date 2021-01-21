using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];
            for (int r = 0; r < n; r++)
            {
                int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
                matrix[r] = row;
            }
            string[] command = Console.ReadLine().Split();
            while (command[0] != "END")
            {
                int row = int.Parse(command[1]), col = int.Parse(command[2]), value = int.Parse(command[3]);
                if (row >= 0 && row < n && col >= 0 && col < n)
                {
                    if (command[0] == "Add")
                    {
                        matrix[row][col] += value;
                    }
                    else
                    {
                        matrix[row][col] -= value;
                    }
                }
                else { Console.WriteLine("Invalid coordinates"); }
                command = Console.ReadLine().Split();
            }
            for (int r = 0; r < n; r++)
            {
                Console.WriteLine(string.Join(" ", matrix[r]));
            }
        }
    }
}
