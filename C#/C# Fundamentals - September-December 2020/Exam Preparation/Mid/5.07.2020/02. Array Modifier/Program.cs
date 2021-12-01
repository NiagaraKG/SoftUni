using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split().ToArray();
            while (command[0] != "end")
            {
                if (command[0] == "decrease")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    { numbers[i]--; }
                }
                else
                {
                    int f = int.Parse(command[1]);
                    int s = int.Parse(command[2]);
                    if (command[0] == "swap")
                    {
                        int buf = numbers[f];
                        numbers[f] = numbers[s];
                        numbers[s] = buf;
                    }
                    else { numbers[f] *= numbers[s]; }
                }
                command = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
