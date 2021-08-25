using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.MergeSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Mergesort.Sort(numbers, 0, numbers.Length - 1);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
    public class Mergesort
    {
        public static void Sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                Sort(arr, l, m);
                Sort(arr, m + 1, r);
                Merge(arr, l, m, r);
            }
        }
        private static void Merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;
            for (i = 0; i < n1; i++) { L[i] = arr[l + i]; }
            for (j = 0; j < n2; j++) { R[j] = arr[m + 1 + j]; }
            i = 0; j = 0;
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j]) { arr[k] = L[i]; i++; }
                else { arr[k] = R[j]; j++; }
                k++;
            }
            while(i<n1)
            {
                arr[k] = L[i];
                i++; k++;
            }
            while(j<n2)
            {
                arr[k] = R[j];
                j++; k++;
            }
        }
    }
}
