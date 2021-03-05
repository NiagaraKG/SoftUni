using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>([A-Za-z]+)<<(\d+\.?\d+)!(\d+)";
            Regex r = new Regex(pattern);
            string input = Console.ReadLine();
            double total = 0;
            Console.WriteLine("Bought furniture:");
            while (input != "Purchase")
            {                
                var match = r.Match(input);
                if (match.Success)
                {
                    string item = match.Groups[1].Value;
                    total += double.Parse(match.Groups[2].Value) * double.Parse(match.Groups[3].Value);
                    Console.WriteLine(item);
                }                
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total money spend: {total:f2}");
        }
    }
}
