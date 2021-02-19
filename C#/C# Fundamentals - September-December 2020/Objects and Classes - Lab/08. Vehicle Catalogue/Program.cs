using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] current = input.Split('/');
                if(current[0] == "Car")
                {
                    Car curr = new Car();
                    curr.Brand = current[1];
                    curr.Model = current[2];
                    curr.HP = double.Parse(current[3]);
                    cars.Add(curr);
                }
                else
                {
                    Truck curr = new Truck();
                    curr.Brand = current[1];
                    curr.Model = current[2];
                    curr.Weight = double.Parse(current[3]);
                    trucks.Add(curr);
                }
                input = Console.ReadLine();
            }
            cars = cars.OrderBy(x => x.Brand).ToList();
            trucks = trucks.OrderBy(x => x.Brand).ToList();
            Console.WriteLine("Cars:");
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Brand}: {item.Model} - {item.HP}hp");
            }
            Console.WriteLine("Trucks:");
            foreach (var item in trucks)
            {
                Console.WriteLine($"{item.Brand}: {item.Model} - {item.Weight}kg");
            }
        }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double HP { get; set; }
    }

}
