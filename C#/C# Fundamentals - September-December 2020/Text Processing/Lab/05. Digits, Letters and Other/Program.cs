using System;
using System.Collections.Generic;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            List<char> digits = new List<char>();
            List<char> letters = new List<char>();
            List<char> others = new List<char>();
            foreach (var c in input)
            {
                if(char.IsDigit(c)) { digits.Add(c); }
                else if(char.IsLetter(c)) { letters.Add(c); }
                else { others.Add(c); }
            }
            Console.WriteLine(string.Join("", digits));
            Console.WriteLine(string.Join("", letters));
            Console.WriteLine(string.Join("", others));
        }
    }
}
