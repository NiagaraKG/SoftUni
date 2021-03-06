﻿using System;
using System.Collections.Generic;

namespace _05._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Student> all = new List<Student>();
            while (input != "end")
            {
                string[] current = input.Split();
                Student curr = new Student();
                curr.FirstName = current[0];
                curr.LastName = current[1];
                curr.Age = int.Parse(current[2]);
                curr.Town = current[3];
                all.Add(curr);
                input = Console.ReadLine();
            }
            string town = Console.ReadLine();
            foreach (var item in all)
            {
                if(item.Town == town)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName} is {item.Age} years old.");
                }
            }
        }

        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Town { get; set; }
            public int Age { get; set; }

        }

    }
}
