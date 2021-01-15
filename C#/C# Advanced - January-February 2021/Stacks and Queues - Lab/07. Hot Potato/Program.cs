using System;
using System.Collections.Generic;

namespace _07._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Queue<string> names = new Queue<string>(input);
            int n = int.Parse(Console.ReadLine()), br = 0;
            while (names.Count > 1)
            {
                string child = names.Dequeue();
                br++;
                if(br%n==0) { Console.WriteLine("Removed " + child); }
                else { names.Enqueue(child); }
            }
            Console.WriteLine("Last is " + names.Dequeue());
        }
    }
}
