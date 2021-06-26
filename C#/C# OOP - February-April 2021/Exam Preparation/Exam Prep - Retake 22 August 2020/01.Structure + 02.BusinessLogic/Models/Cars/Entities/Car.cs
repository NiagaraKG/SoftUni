using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int maxHP, minHP, horsePower;
        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                { throw new ArgumentException($"Model {value} cannot be less than 4 symbols."); }
                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            private set
            {
                if (value > maxHP || value < minHP) { throw new ArgumentException($"Invalid horse power: {value}."); }
                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps) { return this.CubicCentimeters / this.HorsePower * laps; }

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHP = minHorsePower; this.maxHP = maxHorsePower;
            this.Model = model; this.HorsePower = horsePower; this.CubicCentimeters = cubicCentimeters;            
        }
    }
}
