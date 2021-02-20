using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();
            List<Vehicle> vehicles = new List<Vehicle>();
            while (data != "End")
            {
                string[] input = data.Split();
                Vehicle t = new Vehicle(input);
                vehicles.Add(t);
                data = Console.ReadLine();
            }
            data = Console.ReadLine();
            while (data != "Close the Catalogue")
            {
                foreach (var item in vehicles)
                {
                    if (item.Model == data)
                    {
                        Console.WriteLine(item);
                    }
                }
                data = Console.ReadLine();
            }
            double carAv = 0, truckAv = 0;
            int carBr = 0, truckBr = 0;
            foreach (var item in vehicles)
            {
                if (item.Type == "Truck")
                {
                    truckAv += item.HP;
                    truckBr++;
                }
                else
                {
                    carAv += item.HP;
                    carBr++;
                }
            }
            if (carBr == 0) { carAv = 0; } else { carAv /= carBr; }
            if (truckBr == 0) { truckAv = 0; } else { truckAv /= truckBr; }
            Console.WriteLine($"Cars have average horsepower of: {carAv:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {truckAv:F2}.");
        }
    }

    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HP { get; set; }
        public Vehicle(string[] input)
        {
            this.Type = input[0];
            if (this.Type == "car") { this.Type = "Car"; }
            else { this.Type = "Truck"; }
            this.Model = input[1];
            this.Color = input[2];
            this.HP = double.Parse(input[3]);
        }
        public override string ToString()
        {
            string result = $"Type: {this.Type}\nModel: {this.Model}\nColor: {this.Color}\nHorsepower: {this.HP}";
            return result;
        }
    }
}
