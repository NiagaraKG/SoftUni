using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Vehicle
    {
        public double fuelQuantity, fuelConsumption;
        public Vehicle(double quantity, double consumption)
        {
            this.fuelQuantity = quantity;
            this.fuelConsumption = consumption;
        }
        public virtual void Drive(double distance) { }
        public virtual void Refuel(double liters) { }
    }
}
