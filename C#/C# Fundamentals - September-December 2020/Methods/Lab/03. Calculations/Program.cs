using System;
using System.ComponentModel;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            if(command == "add") { Sum(a, b); }
            else if (command == "multiply") { Multiply(a, b); }
            else if (command == "substract") { Substract(a, b); }
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
