using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            double quotient = Factoriel(a) / Factoriel(b);
            Console.WriteLine(quotient.ToString("0.00"));
        }

        static double Factoriel(int a)
        {
            double fact = 1;
            for (int i = a; i > 0; i--)
            {
                fact *= i;
            }
            return fact;
        }

    }
}
