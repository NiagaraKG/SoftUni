using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;
        public int Capacity { get; set; }
        public int Count => this.data.Count;
        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            data = new List<Pet>();
        }
        public void Add(Pet p) { if (this.data.Count < this.Capacity) { data.Add(p); } }
        public bool Remove(string name)
        {
            if(this.data.Any(p=>p.Name == name))
            {
                this.data.RemoveAll(p => p.Name == name);
                return true;
            }
            return false;
        }
        public Pet GetPet(string name, string owner)
        {
            if (this.data.Any(p => p.Name == name && p.Owner == owner))
            {                
                return this.data.Find(p => p.Name == name && p.Owner == owner);
            }
            return null;
        }
        public Pet GetOldestPet()
        {
            Pet oldest = data[0];
            for (int i = 1; i < data.Count; i++)
            {
                if(data[i].Age > oldest.Age) { oldest = data[i]; }
            }
            return oldest;
        }
        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("The clinic has the following patients:");
            foreach (var p in this.data)
            {
                result.AppendLine($"Pet {p.Name} with owner: {p.Owner}");
            }
            return result.ToString().Trim();
        }
    }
}
