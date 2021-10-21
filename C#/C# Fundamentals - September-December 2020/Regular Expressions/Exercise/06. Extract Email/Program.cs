using System;
using System.Text.RegularExpressions;

namespace _06._Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(^| )([A-Za-z0-9]+[._-]*[A-Za-z0-9]+)@((([A-Za-z]+\-*[A-Za-z]+)\.)+([A-Za-z]+\-*[A-Za-z]+))";
            Regex r = new Regex(pattern);
            string[] input = Console.ReadLine().Split();
            foreach (string part in input)
            {
                Match m = r.Match(part);
                if (m.Success)
                { Console.WriteLine(m.Value); }
            }
        }
    }
}
