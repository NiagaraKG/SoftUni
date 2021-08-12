using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (students.ContainsKey(input[0])) { students[input[0]].Add(decimal.Parse(input[1])); }
                else { students.Add(input[0], new List<decimal> { decimal.Parse(input[1]) }); }
            }
            foreach (var item in students)
            {
                Console.Write(item.Key + " -> ");
                foreach (var grade in item.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {item.Value.Average():f2})");
            }
        }
    }
}
