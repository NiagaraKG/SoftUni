using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine(Substract(Sum(a, b), c));
        }

        static int Sum(int a, int b)
        {
            return a + b;
        }

        static int Substract(int a, int b)
        {
            return a - b;
        }

    }
}
