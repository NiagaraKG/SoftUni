using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isChanged = false;
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    numbers.Add(int.Parse(command[1]));
                    isChanged = true;
                }
                else if (command[0] == "Remove")
                {
                    numbers.Remove(int.Parse(command[1]));
                    isChanged = true;
                }
                else if (command[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(command[1]));
                    isChanged = true;
                }
                else if (command[0] == "Insert")
                {
                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    isChanged = true;
                }
                else if (command[0] == "Contains")
                {
                    if(numbers.Contains(int.Parse(command[1]))) { Console.WriteLine("Yes"); }
                    else { Console.WriteLine("No such number"); }
                }
                else if (command[0] == "PrintEven")
                {
                    List<int> result = new List<int>();
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if(numbers[i] % 2 == 0) { result.Add(numbers[i]); }
                    }
                    Console.WriteLine(string.Join(' ', result));
                }
                else if (command[0] == "PrintOdd")
                {
                    List<int> result = new List<int>();
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if(numbers[i] % 2 == 1) { result.Add(numbers[i]); }
                    }
                    Console.WriteLine(string.Join(' ', result));
                }
                else if (command[0] == "GetSum")
                {
                    int sum = 0;
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        sum += numbers[i];
                    }
                    Console.WriteLine(sum);
                }   
                else
                {
                    if(command[1] == "<")
                    {
                        List<int> result = new List<int>();
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] < int.Parse(command[2])) { result.Add(numbers[i]); }
                        }
                        Console.WriteLine(string.Join(' ', result));
                    }
                    else if(command[1] == ">")
                    {
                        List<int> result = new List<int>();
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] > int.Parse(command[2])) { result.Add(numbers[i]); }
                        }
                        Console.WriteLine(string.Join(' ', result));
                    }

                    else if(command[1] == "<=")
                    {
                        List<int> result = new List<int>();
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] <= int.Parse(command[2])) { result.Add(numbers[i]); }
                        }
                        Console.WriteLine(string.Join(' ', result));
                    }
                    else 
                    {
                        List<int> result = new List<int>();
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] >= int.Parse(command[2])) { result.Add(numbers[i]); }
                        }
                        Console.WriteLine(string.Join(' ', result));
                    }

                }
                command = Console.ReadLine().Split();
            }
            if (isChanged) { Console.WriteLine(string.Join(' ', numbers)); }
        }
    }
}
