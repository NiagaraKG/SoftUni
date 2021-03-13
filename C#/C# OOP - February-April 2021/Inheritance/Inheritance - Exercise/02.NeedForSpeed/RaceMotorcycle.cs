using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public override double FuelConsumption => 8;
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel) { }

    }
}
