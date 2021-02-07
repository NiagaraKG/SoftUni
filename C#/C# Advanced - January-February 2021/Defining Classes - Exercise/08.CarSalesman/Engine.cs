using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CarSalesman
{
    public class Engine
    {
        public string Model { get; set; }
        public double Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }
        public Engine() { this.Displacement = -1; this.Efficiency = "n/a"; }
        public Engine(string model, double power) : this() { this.Model = model; this.Power = power; }
        public Engine(string model, double power, int displacement) : this(model, power) { this.Displacement = displacement; }
        public Engine(string model, double power, string efficiency) : this(model, power) { this.Efficiency = efficiency; }
        public Engine(string model, double power, int displacement, string efficiency) : this(model, power, displacement)
        { this.Efficiency = efficiency; }
        public Engine(Engine B)
        { this.Model = B.Model; this.Power = B.Power; this.Displacement = B.Displacement; this.Efficiency = B.Efficiency; }
        public override string ToString()
        {
            string result = "";
            result += "  " + this.Model + ":\n";
            result += "    Power: " + this.Power + '\n';
            result += "    Displacement: ";
            if (this.Displacement == -1) { result += "n/a\n"; }
            else { result += this.Displacement.ToString() + '\n'; }
            result += "    Efficiency: " + this.Efficiency;
            return result;
        }
    }
}
