using System;
using System.Text;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int times = int.Parse(Console.ReadLine());
            Console.WriteLine(Repeat(input, times));
        }

        static string Repeat(string input, int times)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < times; i++)
            {
                result.Append(input);
            }
            return result.ToString();
        }
    }
}
