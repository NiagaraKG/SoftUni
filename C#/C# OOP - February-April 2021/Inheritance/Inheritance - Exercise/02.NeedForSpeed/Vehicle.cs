using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
        private double DefaultFuelConsumption = 1.25;
        public double Fuel { get; set; }
        public int HorsePower { get; set; }
        public virtual double FuelConsumption => this.DefaultFuelConsumption;
        public virtual void Drive(double kilometers)
        {
            Fuel -= FuelConsumption * kilometers;
        }
    }
}
