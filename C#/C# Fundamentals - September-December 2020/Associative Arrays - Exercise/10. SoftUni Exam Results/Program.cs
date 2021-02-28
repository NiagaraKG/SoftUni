using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> languages = new Dictionary<string, int>();
            Dictionary<string, int> students = new Dictionary<string, int>();
            string[] command = Console.ReadLine().Split("-");
            while (command[0] != "exam finished")
            {
                if (command[1] == "banned") { students.Remove(command[0]); }
                else
                {
                    if (students.ContainsKey(command[0]))
                    {
                        if (students[command[0]] < int.Parse(command[2])) { students[command[0]] = int.Parse(command[2]); }
                    }
                    else { students.Add(command[0], int.Parse(command[2])); }
                    if (languages.ContainsKey(command[1])) { languages[command[1]]++; }
                    else { languages.Add(command[1], 1); }
                }
                command = Console.ReadLine().Split("-");
            }
            students = students.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            languages = languages.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Results:");
            foreach (var item in students)
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var item in languages)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
