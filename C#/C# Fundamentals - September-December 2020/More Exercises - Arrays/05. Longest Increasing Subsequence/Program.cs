using System;
using System.Linq;

namespace _05._Longest_Increasing_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input.Length;
            int[] lenght = new int[n];
            int[] previous = new int[n];            
            for (int p = 0; p < n; p++)
            {
                int left = -1, max = int.MinValue;
                for (int i = 0; i < p; i++)
                {
                    if(lenght[i] > max && input[i] < input[p])
                    {
                        max = lenght[i];
                        left = i;
                    }
                }
                if(left == -1) { lenght[p] = 1; }
                else { lenght[p] = 1 + lenght[left]; }
                previous[p] = left;
            }
            int longest = lenght.Max(), index = 0;
            int[] LIS = new int[longest];
            for (int i = 0; i < n; i++)
            {
                if(lenght[i] == longest) 
                { 
                    index = i;                    
                    break; 
                }
            }
            int br = 0;
            while (index >= 0)
            {
                LIS[br] = input[index];
                index = previous[index];
                br++;
            }
            LIS = LIS.Reverse().ToArray();
            Console.WriteLine(string.Join(' ', LIS));
        }
    }
}