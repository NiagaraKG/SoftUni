using System;

namespace _10._Lower_or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            if(a == char.ToLower(a))
            {
                Console.WriteLine("lower-case");
            }
            else { Console.WriteLine("upper-case"); }
        }
    }
}
