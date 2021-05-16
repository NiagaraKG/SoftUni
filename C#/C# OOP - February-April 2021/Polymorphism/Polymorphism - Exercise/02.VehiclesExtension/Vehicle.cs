using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    public class Vehicle
    {
        public double fuelQuantity, fuelConsumption, tankCapacity;
        public Vehicle(double quantity, double consumption, double capacity)
        {
            this.tankCapacity = capacity;
            this.fuelConsumption = consumption;
            if (quantity > tankCapacity) { quantity = 0; }
            this.fuelQuantity = quantity;
        }
        public virtual void Drive(double distance) { }
        public virtual void Refuel(double liters) { }
    }
}
