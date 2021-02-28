using System;
using System.Collections.Generic;
using System.Linq;


namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if(students.ContainsKey(name)) { students[name].Add(grade); }
                else { students.Add(name, new List<double> { grade }); }
            }
            students = students.Where(x => x.Value.Average() >= 4.5).ToDictionary(x => x.Key, x => x.Value);
            students = students.OrderByDescending(x => x.Value.Average()).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in students)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Average():F2}");
            }
        }
    }
}
