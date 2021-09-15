using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                cars.Add(new Car(data));
            }
            string type = Console.ReadLine();
            cars = cars.Where(x => x.Cargo.Type == type).ToList();
            if (type == "fragile")
            {
                cars = cars.Where(x => x.Tires[0].Pressure < 1 || x.Tires[1].Pressure < 1
                                       || x.Tires[2].Pressure < 1 || x.Tires[3].Pressure < 1).ToList();
            }
            else { cars = cars.Where(x => x.Engine.Power > 250).ToList(); }
            foreach (var c in cars) { Console.WriteLine(c.Model); }
        }
    }
}
