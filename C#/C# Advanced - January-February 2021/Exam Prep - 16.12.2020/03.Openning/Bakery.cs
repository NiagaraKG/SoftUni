using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;
        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Employee>();
        }
        public void Add(Employee e) { if (this.data.Count < this.Capacity) { this.data.Add(e); } }
        public bool Remove(string name)
        {
            for (int i = 0; i < this.data.Count; i++)
            {
                if (this.data[i].Name == name)
                {
                    this.data.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public Employee GetOldestEmployee()
        {
            Employee max = this.data[0];
            for (int i = 1; i < this.data.Count; i++)
            {
                if (this.data[i].Age > max.Age) { max = this.data[i]; }
            }
            return max;
        }
        public Employee GetEmployee(string name)
        {
            foreach (var item in this.data)
            {
                if (item.Name == name) { return item; }
            }
            return null;
        }
        public string Report()
        {
            string result = "";
            result += $"Employees working at Bakery {this.Name}:" + Environment.NewLine;
            result += string.Join(Environment.NewLine, this.data);
            return result;
        }
    }
}
