using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();
            string[] command = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "END")
            {
                if(command[0] == "IN") { cars.Add(command[1]); }
                else { cars.Remove(command[1]); }
                command = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }
            if(cars.Count == 0) { Console.WriteLine("Parking Lot is Empty"); }
            else { Console.WriteLine(string.Join(Environment.NewLine, cars)); }
        }
    }
}
