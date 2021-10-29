using System;

namespace _12._Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            while (num % 2 != 0 || num == 0) 
            {
                Console.WriteLine("Please write an even number.");
                num = int.Parse(Console.ReadLine());
            }
            if(num < 0) { num *= -1; }
            Console.WriteLine("The number is: " + num);
        }
    }
}
