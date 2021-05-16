using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Truck : Vehicle
    {
        public Truck(double quantity, double consumption, double capacity) : base(quantity, consumption + 1.6, capacity) { }
        public override void Refuel(double liters)
        {
            if (liters <= 0) { Console.WriteLine("Fuel must be a positive number"); }
            else if(liters>(this.tankCapacity-this.fuelQuantity)) { Console.WriteLine($"Cannot fit {liters} fuel in the tank"); }
            else { this.fuelQuantity += liters * 0.95; }
        }
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
