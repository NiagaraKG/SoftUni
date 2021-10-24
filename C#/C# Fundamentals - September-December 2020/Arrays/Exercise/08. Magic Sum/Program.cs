using System;
using System.Linq;

namespace _08._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = int.Parse(Console.ReadLine());
            string result = "";
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if( (arr[i] + arr[j]) == sum)
                    { result += arr[i] + " " + arr[j] + '\n'; }
                }
            }
            Console.Write(result);
        }
    }
}
