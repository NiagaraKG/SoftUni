using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            PrintASCII(start, end);
        }

        static void PrintASCII(char s, char e)
        {
            if(s > e) { char a = s; s = e; e = a; }
            string result = "";
            for (int i = (int)s + 1; i < (int)e; i++)
            {
                result += (char)(i) + " ";
            }
            Console.WriteLine(result);
        }

    }
}
