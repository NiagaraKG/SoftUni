using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> first = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> second = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int claimed = 0;
            while (first.Count > 0 && second.Count > 0)
            {
                int sum = first.Peek() + second.Peek();
                if (sum % 2 == 0) { claimed += sum; first.Dequeue(); second.Pop(); }
                else { first.Enqueue(second.Pop()); }
            }
            if(first.Count == 0) { Console.WriteLine("First lootbox is empty"); }
            else { Console.WriteLine("Second lootbox is empty"); }
            if(claimed >= 100) { Console.WriteLine($"Your loot was epic! Value: {claimed}"); }
            else { Console.WriteLine($"Your loot was poor... Value: {claimed}"); }
        }
    }
}
