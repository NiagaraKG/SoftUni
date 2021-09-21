using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> resources = new Dictionary<string, double>();
            string command = Console.ReadLine();
            while(command != "stop")
            {
                double quantity = double.Parse(Console.ReadLine());
                if (!resources.ContainsKey(command))
                { resources.Add(command, quantity); }
                else { resources[command] += quantity; }
                command = Console.ReadLine();
            }
            foreach (var item in resources)
            {
                Console.WriteLine(item.Key + " -> " + item.Value);
            }
        }
    }
}
