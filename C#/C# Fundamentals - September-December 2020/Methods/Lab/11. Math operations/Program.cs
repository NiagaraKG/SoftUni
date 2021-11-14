using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {            
            double a = double.Parse(Console.ReadLine());
            char command = char.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            if (command == '+') { Sum(a, b); }
            else if (command == '*') { Multiply(a, b); }
            else if (command == '-') { Substract(a, b); }
            else { Divide(a, b); }
        }
        static void Sum(double a, double b)
        {
            Console.WriteLine(a + b);
        }

        static void Multiply(double a, double b)
        {
            Console.WriteLine(a * b);
        }

        static void Substract(double a, double b)
        {
            Console.WriteLine(a - b);
        }

        static void Divide(double a, double b)
        {
            Console.WriteLine(a / b);
        }
    }
}
