﻿using System;
using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b([A-Z][a-z]+) ([A-Z][a-z]+)\b";
            Regex r = new Regex(pattern);
            String input = Console.ReadLine();
            MatchCollection m = r.Matches(input);
            Console.WriteLine(string.Join(" ", m));
        }
    }
}
