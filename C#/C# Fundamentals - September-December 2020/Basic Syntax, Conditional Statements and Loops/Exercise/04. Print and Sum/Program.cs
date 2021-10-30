using System;

namespace _4._Print_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int sum = end;
            for (int i = start; i < end; i++)
            {
                Console.Write(i + " ");
                sum += i;
            }
            Console.WriteLine(end);
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
