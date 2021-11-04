using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> list1 = Console.ReadLine().Split().Select(double.Parse).ToList();
            List<double> list2 = Console.ReadLine().Split().Select(double.Parse).ToList();
            List<double> sums = new List<double>();
            int minSize = Math.Min(list1.Count, list2.Count);
            int maxList = (list1.Count > list2.Count) ? 1 : 2;
            int br1 = 0, br2 = 0, size = list1.Count + list2.Count;
            for (int i = 0; i < size; i++)
            {
                if(minSize > 0)
                {
                    if(i %2==0)
                    {
                        sums.Add(list1[br1]);
                        br1++;
                        if (maxList == 2)
                        {                            
                            minSize--;
                        }
                    }
                    else 
                    {
                        sums.Add(list2[br2]);
                        br2++;
                        if (maxList == 1)
                        {                           
                            minSize--;
                        }
                    }
                }
                else if(maxList == 1)
                {
                    sums.Add(list1[br1]);
                    br1++;
                }
                else
                {
                    sums.Add(list2[br2]);
                    br2++;
                }
            }
            Console.WriteLine(string.Join(" ", sums));
        }
    }
}
