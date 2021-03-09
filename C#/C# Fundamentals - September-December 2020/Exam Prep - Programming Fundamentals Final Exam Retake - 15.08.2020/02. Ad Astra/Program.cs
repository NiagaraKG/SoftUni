using System;
using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(#|\|)([A-Za-z\s]+)\1(\d{2}\/\d{2}\/\d{2})\1([0-9]+)\1";
            Regex r = new Regex(pattern);
            MatchCollection matches = r.Matches(input);
            int sum = 0;
            foreach (Match m in matches) { sum += int.Parse(m.Groups[4].Value); }
            int days = sum / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (Match m in matches)
            {
                string item = m.Groups[2].Value, date = m.Groups[3].Value, calories = m.Groups[4].Value;
                Console.WriteLine($"Item: {item}, Best before: {date}, Nutrition: {calories}");
            }
        }
    }
}
