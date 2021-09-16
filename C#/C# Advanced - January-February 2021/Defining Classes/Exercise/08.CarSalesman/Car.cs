using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        public string Model { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public Engine Engine { get; set; }

        public Car() { this.Weight = -1; this.Color = "n/a"; this.Engine = new Engine(); }
        public Car(string model, Engine e) : this() { this.Model = model; this.Engine = new Engine(e); }
        public Car(string model, Engine e, int weight) : this(model, e)
        { this.Model = model; this.Engine = new Engine(e); this.Weight = weight; }
        public Car(string model, Engine e, string color) : this(model, e) { this.Color = color; }
        public Car(string model, Engine e, int weight, string color) : this(model, e, weight) { this.Color = color; }
        public Car(Car B)
        { this.Model = B.Model; this.Weight = B.Weight; this.Color = B.Color; this.Engine = new Engine(B.Engine); }

        public override string ToString()
        {
            string result = "";
            result += this.Model + ":\n";
            result += this.Engine.ToString() + "\n";
            if(this.Weight != -1) { result += "  Weight: " + this.Weight + '\n'; }
            else { result += "  Weight: n/a\n"; }
            result += "  Color: " + this.Color;
            return result;
        }
    }
}
