using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> cups = new Queue<int>(input);
            input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bottles = new Stack<int>(input);
            int wasted = 0;
            while (cups.Any())
            {
                int cup = cups.Peek();
                while (bottles.Any() && cup > 0)
                {
                    int bottle = bottles.Peek();
                    if (bottle >= cup)
                    {
                        wasted += bottle - cup;
                        cup = 0;
                        cups.Dequeue();
                        bottles.Pop();
                        if (cups.Count == 0)
                        {
                            Console.WriteLine("Bottles: " + string.Join(" ", bottles));
                            Console.WriteLine("Wasted litters of water: " + wasted);
                            return;
                        }
                        if (bottles.Count == 0)
                        {
                            Console.WriteLine("Cups: " + string.Join(" ", cups));
                            Console.WriteLine("Wasted litters of water: " + wasted);
                            return;
                        }
                    }
                    else
                    {
                        cup -= bottle;
                        bottles.Pop();
                        if (bottles.Count == 0)
                        {
                            Console.WriteLine("Cups: " + string.Join(" ", cups));
                            Console.WriteLine("Wasted litters of water: " + wasted);
                            return;
                        }
                    }
                }
            }
            Console.WriteLine("Bottles: " + bottles.Count());
            Console.WriteLine("Wasted litters of water: " + wasted);
            return;
        }
    }
}
