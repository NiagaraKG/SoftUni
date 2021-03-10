using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            List<int> plates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Stack<int> orcWave = new Stack<int>();
            for (int i = 0; i < waves; i++)
            {
                orcWave = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
                if ((i + 1) % 3 == 0) { plates.Add(int.Parse(Console.ReadLine())); }
                while (orcWave.Count != 0)
                {                    
                    int orc = orcWave.Pop();
                    if (orc > plates[0])
                    {
                        orc -= plates[0];
                        plates.RemoveAt(0);
                        orcWave.Push(orc);
                    }
                    else if (plates[0] > orc) { plates[0] -= orc; }
                    else if (plates[0] == orc) { plates.RemoveAt(0); }
                    if (plates.Count == 0) { break; }
                }
                if (plates.Count == 0) { break; }
            }
            if (plates.Count == 0) { Console.WriteLine("The orcs successfully destroyed the Gondor's defense."); }
            else { Console.WriteLine("The people successfully repulsed the orc's attack."); }
            if(orcWave.Count != 0) { Console.WriteLine("Orcs left: " + string.Join(", ", orcWave)); }
            if(plates.Count != 0) { Console.WriteLine("Plates left: " + string.Join(", ", plates)); }
        }
    }
}
