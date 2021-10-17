using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1._Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tickets = Console.ReadLine().Split(", ").Select(x => x.Trim()).ToList();
            foreach (string t in tickets)
            {
                if (t.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    string right = t.Substring(0, 10);
                    string left = t.Substring(10);
                    string pattern = @"([^@#$\^\s]*)(([@#$\^])(\3{5,}))([^@#$\^\s]*)";
                    Regex R = new Regex(pattern);
                    Match r = R.Match(right);
                    Match l = R.Match(left);
                    if (r.Success && l.Success && (r.Groups[2].Value.Contains(l.Groups[2].Value) || l.Groups[2].Value.Contains(r.Groups[2].Value)))
                    {
                        double lenght = Math.Min(r.Groups[2].Value.Length, l.Groups[2].Value.Length);
                        if (lenght == 10) { Console.WriteLine($"ticket \"{t}\" - 10{t[0]} Jackpot!"); }
                        else { Console.WriteLine($"ticket \"{t}\" - {lenght}{r.Groups[2].Value[0]}"); }
                    }
                    else { Console.WriteLine($"ticket \"{t}\" - no match"); }

                }
            }
        }
    }
}
