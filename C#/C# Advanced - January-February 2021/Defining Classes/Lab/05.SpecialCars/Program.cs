using System;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "No")
            {
                Tire first = new Tire(int.Parse(command[0]), double.Parse(command[1]));
                Tire second = new Tire(int.Parse(command[2]), double.Parse(command[3]));
                Tire third = new Tire(int.Parse(command[4]), double.Parse(command[5]));
                Tire fourth = new Tire(int.Parse(command[6]), double.Parse(command[7]));
                tires.Add(new Tire[] { first, second, third, fourth });
                command = Console.ReadLine().Split();
            }
            command = Console.ReadLine().Split();
            while (command[0] != "Engines")
            {
                engines.Add(new Engine(int.Parse(command[0]), double.Parse(command[1])));
                command = Console.ReadLine().Split();
            }
            command = Console.ReadLine().Split();
            while (command[0] != "Show")
            {
                cars.Add(new Car(command[0], command[1], int.Parse(command[2]), double.Parse(command[3]), double.Parse(command[4]), engines[int.Parse(command[5])], tires[int.Parse(command[6])]));
                command = Console.ReadLine().Split();
            }
            foreach (var c in cars)
            {
                double sumPressure = c.Tires[0].Pressure + c.Tires[1].Pressure + c.Tires[2].Pressure + c.Tires[3].Pressure;
                if (c.Year >= 2017 && c.Engine.HorsePower > 330 && sumPressure >= 9 && sumPressure <= 10)
                {
                    c.Drive(20);
                    Console.WriteLine($"Make: {c.Make}");
                    Console.WriteLine($"Model: {c.Model}");
                    Console.WriteLine($"Year: {c.Year}");
                    Console.WriteLine($"HorsePowers: {c.Engine.HorsePower}");
                    Console.WriteLine($"FuelQuantity: {c.FuelQuantity}");
                }
            }
        }
    }
}
