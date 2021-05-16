using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Car : Vehicle
    {
        public Car(double quantity, double consumption, double capacity) : base(quantity, consumption + 0.9, capacity) { }
        public override void Refuel(double liters)
        {
            if (liters <= 0) { Console.WriteLine("Fuel must be a positive number"); }
            else if (liters > (this.tankCapacity - this.fuelQuantity)) { Console.WriteLine($"Cannot fit {liters} fuel in the tank"); }
            else { this.fuelQuantity += liters; }
        }
        public override void Drive(double distance)
        {
            double fuelNeeded = distance * this.fuelConsumption;
            if (fuelNeeded > fuelQuantity) { Console.WriteLine("Car needs refueling"); }
            else
            {
                Console.WriteLine($"Car travelled {distance} km");
                this.fuelQuantity -= fuelNeeded;
            }
        }
    }
}
