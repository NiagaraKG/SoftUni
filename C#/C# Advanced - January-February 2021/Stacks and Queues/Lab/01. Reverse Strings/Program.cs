using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Join("", Console.ReadLine().ToArray()); ;
            Stack<char> text = new Stack<char>(input);
            Console.WriteLine(string.Join("", text.ToArray()));
        }
    }
}
