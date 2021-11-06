using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());            
            List<string> names = new List<string>();
            for (int m = 0; m < n; m++)
            {
                string[] command = Console.ReadLine().Split();
                string person = command[0];
                if (command[2] == "not")
                {
                    bool wasInList = false;
                    for (int i = 0; i < names.Count; i++)
                    {                        
                        if (names[i] == person)
                        {
                            names.RemoveAt(i);
                            wasInList = true;
                            break;
                        }
                    }
                    if (!wasInList)
                    {
                        Console.WriteLine($"{person} is not in the list!");
                    }
                }
                else
                {
                    bool wasInList = false;
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (names[i] == person)
                        {
                            Console.WriteLine($"{person} is already in the list!");
                            wasInList = true;
                            break;
                        }
                    }
                    if (!wasInList)
                    {
                        names.Add(person);
                    }
                }                              
            }
            Console.WriteLine(string.Join('\n', names));
        }
    }
}
