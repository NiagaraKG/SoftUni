using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> alphabet = new List<char> { '0', 'A', 'B', 'C', 'D','E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
                                                'M', 'N', 'O', 'P', 'Q', 'R','S', 'T', 'U', 'V','W', 'X', 'Y', 'Z'};
            List<string> parts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            double sum = 0;
            foreach (string part in parts)
            {
                double current = 0;
                double num = double.Parse(part.Substring(1, (part.Length - 2)));
                if (char.IsUpper(part[0])) { current = num / alphabet.IndexOf(part[0]); }
                else { current = num * alphabet.IndexOf(char.ToUpper(part[0])); }
                if (char.IsUpper(part[part.Length-1])) { current -= alphabet.IndexOf(part[part.Length - 1]); }
                else { current += alphabet.IndexOf(char.ToUpper(part[part.Length - 1])); }
                sum += current;
            }
            Console.WriteLine(sum.ToString("0.00"));
        }
    }
}
