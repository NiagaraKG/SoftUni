using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<Animal> animals = new List<Animal>();
            while (input[0] != "End")
            {
                Animal currentAnimal;
                switch (input[0])
                {
                    case "Owl": currentAnimal = new Owl(input[1], double.Parse(input[2]), double.Parse(input[3])); break;
                    case "Hen": currentAnimal = new Hen(input[1], double.Parse(input[2]), double.Parse(input[3])); break;
                    case "Cat": currentAnimal = new Cat(input[1], double.Parse(input[2]), input[3], input[4]); break;
                    case "Tiger": currentAnimal = new Tiger(input[1], double.Parse(input[2]), input[3], input[4]); break;
                    case "Mouse": currentAnimal = new Mouse(input[1], double.Parse(input[2]), input[3]); break;
                    default: currentAnimal = new Dog(input[1], double.Parse(input[2]), input[3]); break;
                }
                string animalType = input[0];
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Food currentFood;
                switch (input[0])
                {
                    case "Vegetable": currentFood = new Vegetable(int.Parse(input[1])); break;
                    case "Fruit": currentFood = new Fruit(int.Parse(input[1])); break;
                    case "Meat": currentFood = new Meat(int.Parse(input[1])); break;
                    default: currentFood = new Seeds(int.Parse(input[1])); break;
                }
                currentAnimal.ProduceSound();
                if(animalType == "Mouse" && input[0] != "Vegetable" && input[0] != "Fruit") { Console.WriteLine($"Mouse does not eat {input[0]}!"); }
                else if(animalType == "Cat" && input[0] != "Vegetable" && input[0] != "Meat") { Console.WriteLine($"Cat does not eat {input[0]}!"); }
                else  if(animalType == "Tiger" && input[0] != "Meat") { Console.WriteLine($"Tiger does not eat {input[0]}!"); }
                else  if(animalType == "Dog" && input[0] != "Meat") { Console.WriteLine($"Dog does not eat {input[0]}!"); }
                else  if(animalType == "Owl" && input[0] != "Meat") { Console.WriteLine($"Owl does not eat {input[0]}!"); }
                else
                {
                    switch (animalType)
                    {
                        case "Owl": currentAnimal.Weight += currentFood.Quantity*0.25; break;
                        case "Hen": currentAnimal.Weight += currentFood.Quantity * 0.35; break;
                        case "Cat": currentAnimal.Weight += currentFood.Quantity * 0.3; break;
                        case "Tiger": currentAnimal.Weight += currentFood.Quantity; break;
                        case "Mouse": currentAnimal.Weight += currentFood.Quantity * 0.1; break;
                        default: currentAnimal.Weight += currentFood.Quantity * 0.4; break;
                    }
                    currentAnimal.FoodEaten += currentFood.Quantity;
                }
                animals.Add(currentAnimal);
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var a in animals)
            { Console.WriteLine(a); }
        }
    }
}
