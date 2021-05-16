using System;

namespace _02.VehiclesExtension
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Car c = new Car(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));
            input = Console.ReadLine().Split();
            Truck t = new Truck(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));
            input = Console.ReadLine().Split();
            Bus b = new Bus(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split();
                if (input[0] == "Drive")
                {
                    double distance = double.Parse(input[2]);
                    switch (input[1])
                    {
                        case "Car": c.Drive(distance); break;
                        case "Truck": t.Drive(distance); break;
                        case "Bus": b.Drive(distance); break;
                    }
                }
                else if(input[0]=="DriveEmpty") { b.DriveEmpty(double.Parse(input[2])); }
                else if (input[0] == "Refuel")
                {
                    double liters = double.Parse(input[2]);
                    switch (input[1])
                    {
                        case "Car": c.Refuel(liters); break;
                        case "Truck": t.Refuel(liters); break;
                        case "Bus": b.Refuel(liters); break;
                    }
                }
            }
            Console.WriteLine($"Car: {c.fuelQuantity:f2}");
            Console.WriteLine($"Truck: {t.fuelQuantity:f2}");
            Console.WriteLine($"Bus: {b.fuelQuantity:f2}");
        }
    }
}
