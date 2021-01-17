using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int max = 0;
            int br = 1;
            int value = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if(arr[i] == arr[i-1]) { br++; }
                else
                {
                    if(br > max) { max = br; value = arr[i-1]; }
                    br = 1;
                }
            }
            if (br > max) { max = br; value = arr[arr.Length - 1]; }
            for (int i = 0; i < max; i++)
            { Console.Write(value + " "); }
        }
    }
}
