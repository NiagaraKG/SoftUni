using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }
        public Car(string[] data)
        {
            this.Model = data[0];
            this.Engine = new Engine(int.Parse(data[1]), int.Parse(data[2]));
            this.Cargo = new Cargo(int.Parse(data[3]), data[4]);
            this.Tires = new Tire[4];
            Tires[0] = new Tire(double.Parse(data[5]), int.Parse(data[6]));
            Tires[1] = new Tire(double.Parse(data[7]), int.Parse(data[8]));
            Tires[2] = new Tire(double.Parse(data[9]), int.Parse(data[10]));
            Tires[3] = new Tire(double.Parse(data[11]), int.Parse(data[12]));
        }
    }
}
