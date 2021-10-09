using System;
using System.Linq;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string[] command = Console.ReadLine().Split(":|:");
            while (command[0] != "Reveal")
            {
                if (command[0] == "InsertSpace") 
                { message = message.Insert(int.Parse(command[1]), " "); Console.WriteLine(message); }
                else if (command[0] == "Reverse")
                {
                    if (message.Contains(command[1]))
                    {
                        message = message.Remove(message.IndexOf(command[1]), command[1].Length);
                        char[] reverse = command[1].ToCharArray();
                        Array.Reverse(reverse);
                        message += string.Join("", reverse);
                        Console.WriteLine(message);
                    }
                    else { Console.WriteLine("error"); }
                }
                else if (command[0] == "ChangeAll") 
                { message = message.Replace(command[1], command[2]); Console.WriteLine(message); }
                command = Console.ReadLine().Split(":|:");
            }
            Console.WriteLine("You have a new text message: " + message);
        }
    }
}
