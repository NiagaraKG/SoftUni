using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count();
        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }
        public void Add(Car car) { if (this.data.Count < this.Capacity) { this.data.Add(car); } }
        public bool Remove(string manufacturer, string model)
        {
            if (this.data.Any(c => c.Manufacturer == manufacturer && c.Model == model))
            {
                this.data.RemoveAll(c => c.Manufacturer == manufacturer && c.Model == model);
                return true;
            }
            return false;
        }
        public Car GetLatestCar()
        {
            if (this.data.Count == 0) { return null; }
            Car latest = this.data[0];
            foreach (var c in this.data)
            {
                if (latest.Year < c.Year) { latest = c; }
            }
            return latest;
        }
        public Car GetCar(string manufacturer, string model)
        {
            if (!this.data.Any(c => c.Manufacturer == manufacturer && c.Model == model)) { return null; }
            return this.data.First(c => c.Manufacturer == manufacturer && c.Model == model);
        }
        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var c in this.data) { result.AppendLine(c.ToString()); }
            return result.ToString().Trim();
        }
    }
}
