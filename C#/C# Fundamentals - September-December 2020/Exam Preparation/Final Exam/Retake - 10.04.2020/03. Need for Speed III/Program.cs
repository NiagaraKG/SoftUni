using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> cars = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] car = Console.ReadLine().Split("|");
                cars.Add(car[0], new List<double> { double.Parse(car[1]), double.Parse(car[2])});
            }
            string[] command = Console.ReadLine().Split(" : ");
            while(command[0] != "Stop")
            {
                if(command[0] == "Drive")
                {
                    double fuel = double.Parse(command[3]), distance = double.Parse(command[2]);
                    if(cars[command[1]][1] - fuel < 0) { Console.WriteLine("Not enough fuel to make that ride"); }
                    else
                    {
                        cars[command[1]][0] += distance; cars[command[1]][1] -= fuel;
                        Console.WriteLine($"{command[1]} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    if(cars[command[1]][0] >= 100000)
                    {
                        cars.Remove(command[1]);
                        Console.WriteLine($"Time to sell the {command[1]}!");
                    }
                }
                else if(command[0] == "Refuel")
                {
                    double fuel = double.Parse(command[2]);
                    if(cars[command[1]][1] + fuel > 75) { fuel = 75 - cars[command[1]][1]; }
                    cars[command[1]][1] += fuel;
                    Console.WriteLine($"{command[1]} refueled with {fuel} liters");
                }
                else if(command[0] == "Revert")
                {
                    double km = Double.Parse(command[2]);
                    if(cars[command[1]][0] - km < 10000) { cars[command[1]][0] = 10000; }
                    else 
                    {
                        cars[command[1]][0] -= km;
                        Console.WriteLine($"{command[1]} mileage decreased by {km} kilometers");
                    }
                }
                command = Console.ReadLine().Split(" : ");
            }
            cars = cars.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key)
                                                          .ToDictionary(x => x.Key, y => y.Value);
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");
            }
        }
    }
}
