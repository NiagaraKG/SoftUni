using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> all = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Student s = new Student(input);
                all.Add(s);
            }
            all = all.OrderByDescending(x => x.Grade).ToList();
            Console.WriteLine(String.Join(Environment.NewLine, all)) ;
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student(string[] input)
        {
            this.FirstName = input[0];
            this.LastName = input[1];
            this.Grade = double.Parse(input[2]);
        }

        public override string ToString()
        {
            string result = this.FirstName + " " + this.LastName + ": " + this.Grade.ToString("0.00");
            return result; 
        }

    }

}
