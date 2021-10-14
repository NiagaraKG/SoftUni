using System;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string toRemove = Console.ReadLine();
            string removeFrom = Console.ReadLine();
            while (removeFrom.Contains(toRemove))
            { removeFrom = removeFrom.Replace(toRemove, ""); }
            Console.WriteLine(removeFrom);
        }
    }
}
