using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double quantity, double consumption, double capacity) : base(quantity, consumption, capacity) { }
        public override void Refuel(double liters)
        {
            if (liters <= 0) { Console.WriteLine("Fuel must be a positive number"); }
            else if (liters > (this.tankCapacity - this.fuelQuantity)) { Console.WriteLine($"Cannot fit {liters} fuel in the tank"); }
            else { this.fuelQuantity += liters; }
        }
        public override void Drive(double distance)
        {
            double fuelNeeded = distance * (this.fuelConsumption + 1.4);
            if (fuelNeeded > fuelQuantity) { Console.WriteLine("Bus needs refueling"); }
            else
            {
                Console.WriteLine($"Bus travelled {distance} km");
                this.fuelQuantity -= fuelNeeded;
            }
        }
        public void DriveEmpty(double distance)
        {
            double fuelNeeded = distance * this.fuelConsumption;
            if (fuelNeeded > fuelQuantity) { Console.WriteLine("Bus needs refueling"); }
            else
            {
                Console.WriteLine($"Bus travelled {distance} km");
                this.fuelQuantity -= fuelNeeded;
            }
        }
    }
}
