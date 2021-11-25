using System;

namespace _05._Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine(GetSign(a, b, c));
        }

        static string GetSign(double a, double b, double c)
        {
            int br = 0;
            if(a == 0 || b == 0 || c == 0) { return "zero"; }
            if (a < 0) { br++; }
            if (b < 0) { br++; }
            if (c < 0) { br++; }
            if(br % 2 == 0) { return "positive"; }
            return "negative";
        }
    }
}
