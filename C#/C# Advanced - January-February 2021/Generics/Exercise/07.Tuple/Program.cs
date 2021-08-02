using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Tuple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0] + " " + input[1];
            string adress = input[2];
            Console.WriteLine(new Tuple<string, string>(name, adress));
            input = Console.ReadLine().Split();
            Console.WriteLine(new Tuple<string, int>(input[0], int.Parse(input[1])));
            input = Console.ReadLine().Split();
            Console.WriteLine(new Tuple<int, double>(int.Parse(input[0]), double.Parse(input[1])));
        }
    }
}
