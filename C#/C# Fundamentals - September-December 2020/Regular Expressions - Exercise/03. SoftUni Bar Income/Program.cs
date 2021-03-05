using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%([A-Z][a-z]+)%[^\|\$%\.]*?<(\w+)>[^\|\$%\.]*?\|(\d+)\|[^\|\$%\.]*?(\d+\.?\d+)\$";
            Regex r = new Regex(pattern);
            string input = Console.ReadLine();
            double total = 0;
            while (input != "end of shift")
            {
                Match match = r.Match(input);
                if (match.Success)
                {
                    string customer = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    double sum = double.Parse(match.Groups[3].Value) * double.Parse(match.Groups[4].Value);
                    total += sum;
                    Console.WriteLine($"{customer}: {product} - {sum:f2}");
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {total:f2}");
        }
    }
}
