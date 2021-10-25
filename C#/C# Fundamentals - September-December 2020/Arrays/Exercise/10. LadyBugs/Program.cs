using System;
using System.Linq;

namespace _10._LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] bugs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] field = new int[size];
            for (int i = 0; i < bugs.Length; i++)
            {
                if(bugs[i] >= 0 && bugs[i] < size)
                {
                    field[bugs[i]] = 1;
                }
            }
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] flight = command.Split();
                int from = int.Parse(flight[0]);
                int steps = int.Parse(flight[2]);
                if (flight[1] == "left") { steps *= -1; }
                if (from >= 0 && from < field.Length)
                {
                    int to = from + steps;
                    if (field[from] == 1)
                    {
                        field[from] = 0;                        
                            while (to >= 0 && to < field.Length && field[to] == 1) { to += steps; }
                            if (to >= 0 && to < field.Length) { field[to] = 1; }                        
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', field));
        }
    }
}
