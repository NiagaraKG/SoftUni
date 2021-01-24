using System;
using System.Linq;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] nums = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == '-') { nums[i] = 0; }
                else { nums[i] = input[i] - '0'; }
            }
            int even = EvenSum(nums);
            int odd = OddSum(nums);
            Console.WriteLine(Multiply(even, odd));
        }

        static int EvenSum(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    sum += Math.Abs(nums[i]);
                }
            }
            return sum;
        }
        static int OddSum(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 1)
                {
                    sum += Math.Abs(nums[i]);
                }
            }
            return sum;
        }

        static int Multiply(int a, int b)
        { return a * b; }

    }
}
