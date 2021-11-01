using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int current = num;
            int sum = 0;
            while (current > 0)
            {
                int f = 1;
                for(int i = current % 10; i >= 1 ; i--)
                { f *= i; }
                sum += f;
                current /= 10;
            }
            if(sum == num) { Console.WriteLine("yes"); }
            else { Console.WriteLine("no"); }
        }
    }
}
