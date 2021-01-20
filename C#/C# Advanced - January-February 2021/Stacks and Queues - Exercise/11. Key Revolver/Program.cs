using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrel = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bullets = new Stack<int>(input);
            input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> locks = new Queue<int>(input);
            int money = int.Parse(Console.ReadLine());
            int shots = 0;
            while (locks.Any())
            {
                int currentLock = locks.Peek();
                while (bullets.Any())
                {
                    int bullet = bullets.Peek();
                    if (bullet <= currentLock)
                    {
                        Console.WriteLine("Bang!");
                        locks.Dequeue();
                        bullets.Pop();
                        shots++;
                        money -= bulletPrice;
                        if (shots % barrel == 0 && bullets.Any()) { Console.WriteLine("Reloading!"); }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                        bullets.Pop();
                        shots++;
                        money -= bulletPrice;
                    }
                    if (shots % barrel == 0 && bullets.Any()) { Console.WriteLine("Reloading!"); }
                }
                if (bullets.Count == 0 && locks.Any()) { Console.WriteLine("Couldn't get through. Locks left: " + locks.Count()); return; }
            }
            Console.WriteLine(bullets.Count + " bullets left. Earned $" + money);
        }
    }
}
