﻿using System;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine().Split(", ").Select(int.Parse).Where(x => x % 2 == 0).ToArray().OrderBy(x=>x)));
        }
    }
}
