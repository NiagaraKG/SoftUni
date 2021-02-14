using System;
using System.Linq;

namespace _03.Stack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomStack<string> collection = new CustomStack<string>();
            string[] input = Console.ReadLine().Split(new string[] { " ", ", "}, StringSplitOptions.RemoveEmptyEntries);
            while (input[0] != "END")
            {
                switch (input[0])
                {
                    case "Push": collection.Push(input.Skip(1).ToArray()); break;
                    case "Pop": collection.Pop(); break;
                }
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var item in collection) { Console.WriteLine(item); }
            foreach (var item in collection) { Console.WriteLine(item); }
        }
    }
}
