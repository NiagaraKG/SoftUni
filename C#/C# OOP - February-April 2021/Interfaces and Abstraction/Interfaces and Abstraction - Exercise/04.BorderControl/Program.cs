using System;
using System.Collections.Generic;

namespace _04.BorderControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<IID> travelers = new List<IID>();
            while (input[0] != "End")
            {
                if (input.Length == 3) { travelers.Add(new Citizen(input[0], int.Parse(input[1]), input[2])); }
                else { travelers.Add(new Robot(input[0], input[1])); }
                input = Console.ReadLine().Split();
            }
            string fake = Console.ReadLine();
            foreach (var t in travelers)
            {
                string end = t.ID.Substring(t.ID.Length - fake.Length);
                if (end == fake) { Console.WriteLine(t.ID); }
            }
        }
    }
}
