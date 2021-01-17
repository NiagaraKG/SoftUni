using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int bestSum = 0, bestIndex = 0, bestCount = 0, index = 0, start = 100, currenti = 0;
            int[] best = new int[5];
            while (input != "Clone them!")
            {
                index++;
                int[] current = input.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int count = 0, sum = 0, maxCount = 0;
                for (int i = 0; i < current.Length; i++)
                {

                    if (current[i] == 1) 
                    {
                        if (count == 2) { currenti = i - 1; }
                        count++; sum++; 
                    }
                    else 
                    {
                        if (count == 2) { currenti = i - 1; }
                        if (count > maxCount) { maxCount = count; }
                        count = 0; 
                    }
                }
                if (count > maxCount) { maxCount = count; }
                if (maxCount > bestCount)
                {
                    bestCount = maxCount;
                    bestIndex = index;
                    best = current;
                    bestSum = sum;
                    start = currenti;
                }
                else if (maxCount == bestCount && currenti < start)
                {                    
                    bestCount = maxCount;
                    bestIndex = index;
                    best = current;
                    bestSum = sum;
                    start = currenti;
                }
                else if (maxCount == bestCount && currenti == start && sum > bestSum)
                {                    
                    bestCount = maxCount;
                    bestIndex = index;
                    best = current;
                    bestSum = sum;
                    start = currenti;
                }                
                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestIndex} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", best));
        }
    }
}
