using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Company_Roster
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> all = new List<Employee>();
            List<string> Departments = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Employee current = new Employee(input);
                all.Add(current);
                if(!Departments.Contains(input[2]))
                { Departments.Add(input[2]); }    
            }
            double max = 0.00;
            string maxDepartment = "";
            for (int i = 0; i < Departments.Count; i++)
            {
                double average = 0;
                int br = 0;
                for (int j = 0; j < all.Count; j++)
                {
                    if(all[j].Department == Departments[i])
                    {
                        br++;
                        average += all[j].Salary;
                    }
                }
                average /= br;
                if(average > max) { max = average; maxDepartment = Departments[i]; }
            }
            Console.WriteLine("Highest Average Salary: " + maxDepartment);
            List<Employee> Department = new List<Employee>();
            foreach (var item in all)
            {
                if(item.Department == maxDepartment)
                {
                    Department.Add(item);
                }
            }
            Department = Department.OrderByDescending(x=>x.Salary).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, Department));
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
        public Employee(string[] input)
        {
            this.Name = input[0];
            this.Salary = double.Parse(input[1]);
            this.Department = input[2];
        }

        public override string ToString()
        {
            string result = $"{this.Name} {this.Salary:F2}";
            return result;
        }
    }

}
