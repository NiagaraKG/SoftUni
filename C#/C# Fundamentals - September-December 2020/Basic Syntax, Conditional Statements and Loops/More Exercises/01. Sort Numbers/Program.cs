using System;

namespace _01._Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int buf;
            if (a < b) { buf = a; a = b; b = buf; }
            if (a < c) { buf = a; a = c; c = buf; }
            if (b < c) { buf = b; b = c; c = buf; }
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }
    }
}
