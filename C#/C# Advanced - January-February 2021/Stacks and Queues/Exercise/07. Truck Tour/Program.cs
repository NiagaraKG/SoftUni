using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Petrol
    {
        public int value, distance;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Petrol> pumps = new Queue<Petrol>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                Petrol p = new Petrol();
                p.value = input[0]; p.distance = input[1];
                pumps.Enqueue(p);
            }            
            for (int i = 0; i < n; i++)
            {
                bool isSuccessful = true;
                int fuel = 0;
                for (int j = 0; j < n; j++)
                {
                    Petrol current = pumps.Dequeue();
                    pumps.Enqueue(current);
                    fuel += current.value;
                    fuel -= current.distance;
                    if (fuel < 0) { isSuccessful = false; }
                }
                if(isSuccessful) { Console.WriteLine(i); break; }
                pumps.Enqueue(pumps.Dequeue());
            }
        }
    }
}
