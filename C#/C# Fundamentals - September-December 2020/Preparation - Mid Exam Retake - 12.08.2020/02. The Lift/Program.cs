using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._The_Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            List<int> lift = Console.ReadLine().Split().Select(int.Parse).ToList();
            for (int i = 0; i < lift.Count; i++)
            {
                if(lift[i] < 4)
                {
                    int space = 4 - lift[i];
                    if(people != 0)
                    {
                        if(people < space) { space = people; }
                        people -= space;                        
                        lift[i] += space;
                    }                    
                }
            }
            bool isFull = true;
            foreach (var wagon in lift)
            {
                if(wagon < 4) { isFull = false; break; }
            }
            if(isFull && people > 0) 
            { Console.WriteLine($"There isn't enough space! {people} people in a queue!"); }
            else if (!isFull && people == 0)
            { Console.WriteLine("The lift has empty spots!"); }
            Console.WriteLine(string.Join(" ", lift));
        }
    }
}
