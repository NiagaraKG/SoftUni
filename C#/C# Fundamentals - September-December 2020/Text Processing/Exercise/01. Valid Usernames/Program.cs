using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(", ").ToList();
            for (int i = 0; i < names.Count; i++)            
            {
                if (names[i].Length < 3 || names[i].Length > 16) { names[i] = "@"; }
                else
                {
                    foreach (var letter in names[i])
                    {
                        if (!char.IsLetterOrDigit(letter) && letter != '-' && letter != '_') { names[i] = "@"; break; }
                    }
                }
            }
            names.RemoveAll(x=>x=="@");
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
