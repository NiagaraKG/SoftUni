using System;
using System.Text.RegularExpressions;

namespace _4._Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            while (input != "end")
            {
                char[] encripted = input.ToCharArray();
                for (int i = 0; i < encripted.Length; i++) { encripted[i] = (char)(encripted[i] - key); }
                string decripted = string.Join("", encripted);
                string pattern = @"@([A-Za-z]+)[^@!:>\-]*!([G])!";
                Regex r = new Regex(pattern);
                Match m = r.Match(decripted);
                if (m.Success) { Console.WriteLine(m.Groups[1].Value); }
                input = Console.ReadLine();
            }
        }
    }
}
