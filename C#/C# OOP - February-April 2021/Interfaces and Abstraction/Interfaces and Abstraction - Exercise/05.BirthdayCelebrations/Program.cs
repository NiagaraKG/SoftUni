using System;
using System.Collections.Generic;

namespace _05.BirthdayCelebrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<IBirthable> birthable = new List<IBirthable>();
            while (input[0] != "End")
            {
                if (input[0] != "Robot")
                {
                    if (input.Length == 5) { birthable.Add(new Citizen(input[1], int.Parse(input[2]), input[3], input[4])); }
                    else { birthable.Add(new Pet(input[1], input[2])); }
                }
                input = Console.ReadLine().Split();
            }
            string year = Console.ReadLine();
            foreach (var t in birthable)
            {
                string end = t.Birthday.Substring(t.Birthday.Length - year.Length);
                if (end == year) { Console.WriteLine(t.Birthday); }
            }
        }
    }
}
