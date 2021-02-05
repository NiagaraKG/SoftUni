using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make, model;
        private int year;
        private double fuelQuantity, fuelConsumption;

        public string Make { get { return this.make; } set { this.make = value; } }
        public string Model { get { return this.model; } set { this.model = value; } }
        public int Year { get { return this.year; } set { this.year = value; } }
        public double FuelQuantity { get { return this.fuelQuantity; } set { this.fuelQuantity = value; } }
        public double FuelConsumption { get { return this.fuelConsumption; } set { this.fuelConsumption = value; } }

        public void Drive(double distance)
        {
            double fuelNeeded = fuelConsumption * distance/100;
            if (fuelQuantity - fuelNeeded > 0) { FuelQuantity -= fuelNeeded; }
            else { Console.WriteLine("Not enough fuel to perform this trip!"); }
        }
        public string WhoAmI() { return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}L"; }
    }
}
