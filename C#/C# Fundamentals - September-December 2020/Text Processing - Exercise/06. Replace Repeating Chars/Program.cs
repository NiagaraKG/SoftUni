using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> letters = Console.ReadLine().ToCharArray().ToList();
            for (int i = 1; i < letters.Count; i++)
            {
                if (letters[i] == letters[i - 1]) { letters.RemoveAt(i); i--; }
            }
            Console.WriteLine(string.Join("", letters));
        }
    }
}
