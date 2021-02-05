using System;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int s = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in names)
            {
                int current = 0;
                foreach (var c in name)
                {
                    current += c;
                }
                if(current>= s) { Console.WriteLine(name); return; }
            }
        }
    }
}
