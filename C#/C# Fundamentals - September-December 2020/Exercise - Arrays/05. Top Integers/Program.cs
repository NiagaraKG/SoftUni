using System;
using System.Linq;

namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string result = "";
            for (int i = 0; i < arr.Length; i++)
            {
                bool isBigger = true;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if(arr[j] >= arr[i]) { isBigger = false; break; }
                }
                if (isBigger) { result += arr[i] + " "; }
            }
            Console.WriteLine(result);
        }
    }
}
