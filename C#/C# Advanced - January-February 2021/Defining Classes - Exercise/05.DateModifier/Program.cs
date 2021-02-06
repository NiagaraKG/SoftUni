using System;

namespace _05.DateModifier
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            Console.WriteLine(DateModifier.Calculate(first, second));
        }
    }
}
