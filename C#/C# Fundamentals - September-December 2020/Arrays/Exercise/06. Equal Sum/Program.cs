using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                int left = 0;
                int right = 0;
                for (int j = 0; j < i; j++)
                {
                    left += arr[j];
                }
                for (int k = i + 1; k < arr.Length; k++)
                {
                    right += arr[k];
                }
                if(left == right) { Console.WriteLine(i); return; }                
            }
            Console.WriteLine("no");
        }
    }
}
