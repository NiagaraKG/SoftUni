using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < input.Length; i++) { numbers.Push(int.Parse(input[i])); }
            string[] commannd = Console.ReadLine().Split();
            while(commannd[0].ToLower() != "end")
            {
                if(commannd[0].ToLower() == "add")
                { 
                    numbers.Push(int.Parse(commannd[1]));
                    numbers.Push(int.Parse(commannd[2])); 
                }
                else
                {
                    int n = int.Parse(commannd[1]);
                    if(n<=numbers.Count)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }
                commannd = Console.ReadLine().Split();
            }
            Console.WriteLine("Sum: " + numbers.Sum());
        }
    }
}
