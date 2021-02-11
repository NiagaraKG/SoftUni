using System;

namespace _01.GenericBoxOfString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {                
                Box<string> b = new Box<string>(Console.ReadLine());
                Console.WriteLine(b.ToString());
            }
        }
    }
}
