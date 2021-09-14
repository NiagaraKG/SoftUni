using System;
using System.Collections.Generic;
using System.Text;

namespace _06.SpeedRacing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumotionPerKilometer { get; set; }
        public double DistanceTraveled { get; set; }
        public Car(string model, double fuel, double consumption)
        {
            this.Model = model;
            this.FuelAmount = fuel;
            this.FuelConsumotionPerKilometer = consumption;
            this.DistanceTraveled = 0;
        }
        public void Drive(double km)
        {
            double FuelNeeded = km * FuelConsumotionPerKilometer;
            if (FuelNeeded <= FuelAmount)
            {
                FuelAmount -= FuelNeeded;
                DistanceTraveled += km;
            }
            else { Console.WriteLine("Insufficient fuel for the drive"); }
        }
    }
}
