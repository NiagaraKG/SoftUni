using System;
using System.Collections.Generic;
using System.Linq;

namespace RecursionExercise
{
    public class Program
    {
        private static List<string> people;
        private static string[] variants;
        private static bool[] areFixed;
        public static void Main()
        {
            people = Console.ReadLine().Split(", ").ToList();
            variants = new string[people.Count];
           areFixed = new bool[people.Count];
            string line = Console.ReadLine();
            while (line != "generate")
            {
                var elements = line.Split(" - ");
                string name = elements[0];
                int position = int.Parse(elements[1]) - 1;
                variants[position] = name;
                areFixed[position] = true;
                people.Remove(name);
                line = Console.ReadLine();
            }
            Permute(0);
        }

        private static void Permute(int index)
        {
            if(index >= people.Count) 
            {
                Print();
                return; 
            }
            Permute(index + 1);
            for (int i = index + 1; i < people.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Print()
        {
            var p = 0;
            string line = "";
            for (int i = 0; i < variants.Length; i++)
            {
                
                if(areFixed[i])
                {
                    line += $"{variants[i]} ";
                }
                else
                {
                   line += $"{people[p]} ";
                    p++;
                }
            }
            Console.WriteLine(line.Trim());
        }

        private static void Swap(int i, int j)
        {
            var temp = people[i];
            people[i] = people[j];
            people[j] = temp;
        }
    }
}