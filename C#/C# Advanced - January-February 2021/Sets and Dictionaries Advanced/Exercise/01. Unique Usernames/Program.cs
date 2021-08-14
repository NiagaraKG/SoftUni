using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> unique = new HashSet<string>();
            for (int i = 0; i < n; i++) { unique.Add(Console.ReadLine()); }
            Console.WriteLine(string.Join(Environment.NewLine, unique));
        }
    }
}
