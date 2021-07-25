using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        public int Capacity { get; set; }
        public int Count => this.students.Count;
        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            students = new List<Student>();
        }
        public string RegisterStudent(Student student)
        {
            if(this.Count < this.Capacity)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return "No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            if(this.students.Any(s=>s.FirstName == firstName && s.LastName == lastName))
            {
                this.students.RemoveAll(s => s.FirstName == firstName && s.LastName == lastName);
                return $"Dismissed student {firstName} {lastName}";
            }
            return "Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            StringBuilder result = new StringBuilder();
            if (!this.students.Any(s => s.Subject == subject))
            {
                result.AppendLine("No students enrolled for the subject");
            }
            else
            {
                result.AppendLine($"Subject: {subject}");
                result.AppendLine("Students:");
                foreach (var s in this.students)
                {
                    if (s.Subject == subject)
                    {
                        result.AppendLine($"{s.FirstName} {s.LastName}");
                    }
                }
            }
            return result.ToString().Trim();
        }
        public int GetStudentsCount()
        {
            return this.Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            return this.students.Find(s=>s.FirstName == firstName && s.LastName == lastName);
        }
    }
}
