using System;

namespace _02.GenericBoxOfInteger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Box<int> b = new Box<int>(int.Parse(Console.ReadLine()));
                Console.WriteLine(b.ToString());
            }
        }
    }
}
