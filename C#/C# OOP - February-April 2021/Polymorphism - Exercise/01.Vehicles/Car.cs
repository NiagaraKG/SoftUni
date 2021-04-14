using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double quantity, double consumption) : base(quantity, consumption + 0.9) { }
        public override void Refuel(double liters) { this.fuelQuantity += liters; }
        public override void Drive(double distance)
        {
            double fuelNeeded = distance * this.fuelConsumption;
            if(fuelNeeded>fuelQuantity) { Console.WriteLine("Car needs refueling"); }
            else
            {
                Console.WriteLine($"Car travelled {distance} km");
                this.fuelQuantity -= fuelNeeded;
            }
        }
    }
}
