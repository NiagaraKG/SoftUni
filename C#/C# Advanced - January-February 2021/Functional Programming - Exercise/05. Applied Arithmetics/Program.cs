using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int[]> add = x => { for (int i = 0; i < x.Length; i++) { x[i]++; } };
            Action<int[]> muliply = x => { for (int i = 0; i < x.Length; i++) { x[i]*=2; } };
            Action<int[]> subtract = x => { for (int i = 0; i < x.Length; i++) { x[i]--; } };
            Action<int[]> print = x => Console.WriteLine(string.Join(" ", x));
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add": add(numbers); break;
                    case "muliply": muliply(numbers); break;
                    case "subtract": subtract(numbers); break;
                    case "print": print(numbers); break;
                    default: break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
