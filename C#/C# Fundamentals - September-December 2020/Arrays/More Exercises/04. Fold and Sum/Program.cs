using System;
using System.Linq;

namespace _04._Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = input.Length / 4;
            int[] first = new int[2*k];
            int[] second = new int[2*k];
            int[] begin = new int[k];
            int[] end = new int[k];
            int[] sum = new int[2 * k];
            for (int i = 0; i < input.Length; i++)
            {
                if(i < k)
                {
                    begin[i] = input[i];
                }
                else if (i >= input.Length - k)
                {
                    end[i - 3 * k] = input[i];
                }
                else
                {
                    second[i - k] = input[i];
                }                
            }
            begin = begin.Reverse().ToArray();
            end = end.Reverse().ToArray();
            for (int i = 0; i < begin.Length; i++)
            {
                first[i] = begin[i];
            }
            for (int i = 0; i < end.Length; i++)
            {
                first[i+k] = end[i];
            }
            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = first[i] + second[i];
            }
            Console.WriteLine(string.Join(' ', sum));
        }
    }
}
