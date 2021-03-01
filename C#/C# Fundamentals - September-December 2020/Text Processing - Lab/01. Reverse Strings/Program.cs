using System;
using System.Linq;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            while (word != "end")
            {
                Console.WriteLine($"{word} = {new string(word.Reverse().ToArray())}");
                word = Console.ReadLine();
            }
        }
    }
}
