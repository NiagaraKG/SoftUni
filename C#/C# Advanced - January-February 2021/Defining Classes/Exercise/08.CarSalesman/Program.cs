using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarSalesman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            string[] input;
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                double power = double.Parse(input[1]);
                int displacement = -1;
                string efficiency = "n/a";
                if (input.Length == 3)
                {
                    if (input[2].All(char.IsDigit)) { displacement = int.Parse(input[2]); }
                    else { efficiency = input[2]; }
                }
                else if(input.Length == 4) { displacement = int.Parse(input[2]); efficiency = input[3]; }
                engines.Add(new Engine(model, power, displacement, efficiency));
            }
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                Engine engine = new Engine();
                foreach (var e in engines) { if (e.Model == input[1]) { engine = new Engine(e); break; } }
                int weight = -1;
                string color = "n/a";
                if (input.Length == 3)
                {
                    if (input[2].All(char.IsDigit)) { weight = int.Parse(input[2]); }
                    else { color = input[2]; }
                }
                else if (input.Length == 4) {
                    weight = int.Parse(input[2]); 
                    color = input[3]; }
                cars.Add(new Car(model, engine, weight, color));
            }
            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
