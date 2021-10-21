using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();
            string pattern = @"[^@\-!:>]*@([A-Za-z]+)[^@\-!:>]*:(\d+)[^@\-!:>]*!([AD])![^@\-!:>]*->(\d+)[^@\-!:>]*";
            Regex r = new Regex(pattern);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                List<char> message = Console.ReadLine().ToCharArray().ToList();
                int key = 0;
                foreach (char symbol in message)
                {
                    if (symbol == 's' || symbol == 't' || symbol == 'a' || symbol == 'r' ||
                        symbol == 'S' || symbol == 'T' || symbol == 'A' || symbol == 'R')
                    { key++; }
                }
                for (int l = 0; l < message.Count; l++) { message[l] = (char)(message[l] - key); }
                var match = r.Match(string.Join("", message));
                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    if (match.Groups[3].Value == "A") { attacked.Add(name); }
                    else { destroyed.Add(name); }
                }
            }
            attacked.Sort();
            destroyed.Sort();
            Console.WriteLine($"Attacked planets: {attacked.Count}");
            foreach (string planet in attacked) { Console.WriteLine($"-> {planet}"); }
            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            foreach (string planet in destroyed) { Console.WriteLine($"-> {planet}"); }
        }
    }
}
