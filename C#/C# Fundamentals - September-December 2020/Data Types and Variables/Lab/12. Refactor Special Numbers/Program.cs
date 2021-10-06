using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());            
            for (int i = 1; i <= n; i++)
            {
                int current = i;
                int sum = 0;
                while (current > 0)
                {
                    sum += current % 10;
                    current = current / 10;
                }
                bool isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{i} -> {isSpecial}");               
            }
        }
    }
}
