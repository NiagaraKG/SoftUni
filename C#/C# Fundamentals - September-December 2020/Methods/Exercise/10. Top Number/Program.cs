using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if(IsTop(i)) { Console.WriteLine(i); }
            }
        }

        static bool IsTop(int n)
        {
            if(!DigitSum(n)) { return false; }
            if(!OddDigit(n)) { return false; }
            return true;
        }

        static bool DigitSum (int n)
        {
            int sum = 0;
            while(n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            if(sum % 8 == 0) { return true; }
            return false;
        }

        static bool OddDigit(int n)
        {
            int digit;
            while (n > 0)
            {
                digit = n % 10;
                n /= 10;
                if(digit % 2 == 1) { return true; }
            }
            return false;
        }

    }
}
