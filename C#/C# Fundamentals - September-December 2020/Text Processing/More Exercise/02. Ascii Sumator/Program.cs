using System;

namespace _02._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char[] text = Console.ReadLine().ToCharArray();
            int sum = 0;
            foreach (var c in text)
            {
                if(c>start && c<end) { sum += c; }
            }
            Console.WriteLine(sum);
        }
    }
}
