using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string pass = "";
            int tries = 0;
            string input;
            for (int i = user.Length - 1; i >= 0; i--)
            {
                pass += user[i];
            }
            while (tries < 4)
            {
                input = Console.ReadLine();
                if (input == pass) { Console.WriteLine($"User {user} logged in."); break; }
                tries++;
                if (tries == 4) { Console.WriteLine($"User {user} blocked!"); break; }
                Console.WriteLine("Incorrect password. Try again.");
            }
        }
    }
}
