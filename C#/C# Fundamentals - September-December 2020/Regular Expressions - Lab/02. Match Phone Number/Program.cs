using System;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(^| )\+359([ -])2\2\d{3}\2\d{4}\b";
            Regex r = new Regex(pattern);
            string[] input = Console.ReadLine().Split(", ");
            MatchCollection m = r.Matches(string.Join(" ", input));
            Console.WriteLine(string.Join(",", m));
        }
    }
}
