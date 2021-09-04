using System;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(Environment.NewLine, Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)));           
        }
    }
}
