using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> effects = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Stack<int> casings = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            int smoke = 0, cherry = 0, datura = 0;
            bool hasBombs = false;
            while (effects.Count > 0 && casings.Count > 0)
            {
                int sum = effects.Dequeue() + casings.Pop();
                while (sum != 120 && sum != 60 && sum != 40) { sum -= 5; }
                if (sum == 120) { smoke++; }
                else if (sum == 60) { cherry++; }
                else if (sum == 40) { datura++; }
                if(smoke >= 3 && cherry >= 3 && datura >= 3) { hasBombs = true; break; }
            }
            if(hasBombs) { Console.WriteLine("Bene! You have successfully filled the bomb pouch!"); }
            else { Console.WriteLine("You don't have enough materials to fill the bomb pouch."); }
            if(effects.Count == 0) { Console.WriteLine("Bomb Effects: empty"); }
            else { Console.WriteLine("Bomb Effects: " + string.Join(", ", effects)); }
            if(casings.Count == 0) { Console.WriteLine("Bomb Casings: empty"); }
            else { Console.WriteLine("Bomb Casings: " + string.Join(", ", casings)); }
            Console.WriteLine("Cherry Bombs: " + cherry);
            Console.WriteLine("Datura Bombs: " + datura);
            Console.WriteLine("Smoke Decoy Bombs: " + smoke);
        }
    }
}
