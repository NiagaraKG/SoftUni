using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Threeuple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            string name = input[0] + " " + input[1];
            string adress = input[2];
            input.RemoveAt(0);input.RemoveAt(0);input.RemoveAt(0);           
            Console.WriteLine(new Threeuple<string, string, string>(name, adress, string.Join(" ", input)));
            input = Console.ReadLine().Split().ToList();
            bool isDrunk = input[2] == "drunk" ? true : false;
            Console.WriteLine(new Threeuple<string, int, bool>(input[0], int.Parse(input[1]), isDrunk));
            input = Console.ReadLine().Split().ToList();
            Console.WriteLine(new Threeuple<string, double, string>(input[0], double.Parse(input[1]), input[2]));
        }
    }
}
