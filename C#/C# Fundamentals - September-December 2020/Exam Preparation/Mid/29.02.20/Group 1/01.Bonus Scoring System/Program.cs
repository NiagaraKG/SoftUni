using System;

namespace _01._Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int lectures = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());
            double max = 0, attendancesMax = 0;
            for (int i = 0; i < students; i++)
            {
                int attendances = int.Parse(Console.ReadLine());
                if(attendancesMax < attendances) 
                {
                    max = (attendances * 1.00 / lectures) * (5 + bonus);
                    attendancesMax = attendances; 
                }
            }
            Console.WriteLine($"Max Bonus: {Math.Ceiling(max)}.");
            Console.WriteLine($"The student has attended {attendancesMax} lectures.");
        }
    }
}
/*
  static void Main(string[] args)
        {
            int health = 100, bitcoins = 0;
            List<string> rooms = Console.ReadLine().Split("|").ToList();
            bool isAlive = true;
            for (int i = 0; i < rooms.Count; i++)
            {
                string[] command = rooms[i].Split();
                int power = int.Parse(command[1]);
                if (command[0] == "potion")
                {                    
                    if(health+power <= 100) 
                    {
                        health += power;
                        Console.WriteLine($"You healed for {power} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }                    
                }
                else if(command[0] == "chest")
                {
                    bitcoins += power;
                    Console.WriteLine($"You found {power} bitcoins.");
                }
                else
                {
                    health -= power;
                    if(health > 0) { Console.WriteLine($"You slayed {command[0]}."); }
                    else
                    {
                        isAlive = false;
                        Console.WriteLine($"You died! Killed by {command[0]}.\nBest room: {i+1}");
                    }
                }
            }
            if(isAlive) 
            { Console.WriteLine($"You've made it!\nBitcoins: {bitcoins}\nHealth: {health}"); }
        }
*/
