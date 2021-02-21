using System;
using System.Collections.Generic;

namespace _03._Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> all = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Car current = new Car(input);
                all.Add(current);
            }
            string[] command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                for (int i = 0; i < all.Count; i++)
                {
                    if(all[i].Model == command[1])
                    {
                        double km = double.Parse(command[2]);
                        double fuelNeeded = all[i].Consumption * km;
                        if(all[i].FuelAmount >= fuelNeeded)
                        {
                            all[i].FuelAmount -= fuelNeeded;
                            all[i].Distance += km;
                        }
                        else
                        {
                            Console.WriteLine("Insufficient fuel for the drive");
                        }
                    }
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine(String.Join(Environment.NewLine, all));
        }
    }

    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double  Consumption { get; set; }
        public double Distance { get; set; }
        public Car(string[] input)
        {
            this.Model = input[0];
            this.FuelAmount = double.Parse(input[1]);
            this.Consumption = double.Parse(input[2]);
            this.Distance = 0.00;
        }
        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:F2} {this.Distance}";
        }
    }

}
