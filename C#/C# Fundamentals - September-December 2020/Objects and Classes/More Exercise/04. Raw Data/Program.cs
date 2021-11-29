using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace _04._Raw_Data
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
            string command = Console.ReadLine();
            if(command == "fragile")
            {
                foreach (var item in all)
                {
                    if(item.CargoType == "fragile" && item.CargoWeight < 1000)
                    { Console.WriteLine(item.Model); }
                }
            }
            else
            {
                foreach (var item in all)
                {
                    if (item.CargoType == "flamable" && item.Power > 250)
                    { Console.WriteLine(item.Model); }
                }
            }
        }
    }

    class Car
    {
        public string Model { get; set; }        
        public int Power { get; set; }
        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
        public Car(string[] input)
        {
            this.Model = input[0];
            this.Power = int.Parse(input[2]);
            this.CargoWeight = int.Parse(input[3]);
            this.CargoType = input[4];
        }        
    }   
}
