﻿using System;

namespace CombinatorialProblems
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine(Binom(n, k));
        }

        private static int Binom(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row) { return 1; }
            return Binom(row - 1, col - 1) + Binom(row - 1, col);
        }
    }
}