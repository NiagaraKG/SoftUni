using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int wreaths = 0, sum = 0;
            while (roses.Count > 0 && lilies.Count > 0)
            {
                int current = lilies.Peek() + roses.Peek();
                while (current > 15) { current -= 2; }
                if (current == 15) { wreaths++; }
                else if (current < 15) { sum += current; }
                roses.Dequeue();
                lilies.Pop();
            }
            wreaths += sum / 15;
            if(wreaths < 5) { Console.WriteLine($"You didn't make it, you need {5-wreaths} wreaths more!"); }
            else { Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!"); }
        }
    }
}
