using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(Environment.NewLine, Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x=>x = "Sir " + x)));
        }
    }
}
