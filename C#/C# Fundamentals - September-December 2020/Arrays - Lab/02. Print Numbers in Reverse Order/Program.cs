using System;
using System.Linq;

namespace _02._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] nums = new string[n];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', nums.Reverse().ToArray()));
        }
    }
}
