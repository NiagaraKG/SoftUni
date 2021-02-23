using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine().Split(", ").ToList();
            string[] command = Console.ReadLine().Split(" - ").ToArray();
            while (command[0] != "Craft!")
            {
                string material = command[1];
                if (command[0] == "Collect")
                {
                    if (!inventory.Contains(material)) { inventory.Add(material); }
                }
                else if (command[0] == "Drop")
                {
                    if (inventory.Contains(material)) { inventory.Remove(material); }
                }
                else if (command[0] == "Renew")
                {
                    if (inventory.Contains(material))
                    {
                        inventory.Remove(material);
                        inventory.Add(material);
                    }
                }
                else
                {
                    string[] materials = material.Split(":");
                    if (inventory.Contains(materials[0]))
                    {
                        int index = inventory.IndexOf(materials[0]) + 1;
                        inventory.Insert(index, materials[1]);
                    }
                }
                command = Console.ReadLine().Split(" - ").ToArray();
            }
            Console.WriteLine(string.Join(", ", inventory));
        }
    }
}
