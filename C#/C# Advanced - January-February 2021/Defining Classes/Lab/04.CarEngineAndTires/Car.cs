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
        private Engine engine;
        private Tire[] tires;

        public string Make { get { return this.make; } set { this.make = value; } }
        public string Model { get { return this.model; } set { this.model = value; } }
        public int Year { get { return this.year; } set { this.year = value; } }
        public double FuelQuantity { get { return this.fuelQuantity; } set { this.fuelQuantity = value; } }
        public double FuelConsumption { get { return this.fuelConsumption; } set { this.fuelConsumption = value; } }
        public Engine Engine { get { return this.engine; } set { this.engine = value; } }
        public Tire[] Tires { get { return this.tires; } set { this.tires = value; } }

        public Car() { this.Make = "VW"; this.Model = "Golf"; this.Year = 2025; this.FuelQuantity = 200; this.FuelConsumption = 10; }
        public Car(string make, string model, int year) : this() { this.Make = make; this.Model = model; this.Year = year; }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        { this.FuelQuantity = fuelQuantity; this.FuelConsumption = fuelConsumption; }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption) { this.Engine = engine; this.Tires = tires; }


        public void Drive(double distance)
        {
            double fuelNeeded = fuelConsumption * distance/100;
            if (fuelQuantity - fuelNeeded > 0) { FuelQuantity -= fuelNeeded; }
            else { Console.WriteLine("Not enough fuel to perform this trip!"); }
        }
        public string WhoAmI() { return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}L"; }
    }
}
