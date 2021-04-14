using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double quantity, double consumption) : base(quantity, consumption + 1.6) { }
        public override void Refuel(double liters) { this.fuelQuantity += liters*0.95; }
        public override void Drive(double distance)
        {
            double fuelNeeded = distance * this.fuelConsumption;
            if (fuelNeeded > fuelQuantity) { Console.WriteLine("Truck needs refueling"); }
            else
            {
                Console.WriteLine($"Truck travelled {distance} km");
                this.fuelQuantity -= fuelNeeded;
            }
        }
    }
}
