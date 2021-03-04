using System;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<day>\d{2})([./-])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";
            Regex r = new Regex(pattern);
            string input = Console.ReadLine();
            MatchCollection matches = r.Matches(input);
            foreach (Match m in matches)
            {
                Console.WriteLine($"Day: {m.Groups["day"].Value}, Month: {m.Groups["month"].Value}, Year: {m.Groups["year"].Value}");
            }
        }
    }
}
