using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Func<string, bool> filter = x => x.Length <= n;
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(filter).ToArray();
            Console.WriteLine(String.Join(Environment.NewLine, names));
        }
    }
}
