using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int kill = int.Parse(Console.ReadLine());
            int currThread = 0, currTask = 0;
            while (currTask != kill)
            {
                currThread = threads.Peek(); currTask = tasks.Peek();
                if(currThread >= currTask) { tasks.Pop(); }
                threads.Dequeue();                
            }
            Console.WriteLine($"Thread with value {currThread} killed task {currTask}");
            Console.WriteLine(currThread.ToString() + " " + string.Join(" ", threads));
        }
    }
}
