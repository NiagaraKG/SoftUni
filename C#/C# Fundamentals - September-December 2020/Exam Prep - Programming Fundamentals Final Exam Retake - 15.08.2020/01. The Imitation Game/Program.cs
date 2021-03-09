using System;

namespace _01._The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string[] command = Console.ReadLine().Split("|");
            while (command[0] != "Decode")
            {
                if(command[0] == "Move")
                {
                    int n = int.Parse(command[1]); string m = message.Substring(0, n);
                    message = message.Remove(0, n); message += m;
                }
                else if(command[0] == "Insert") 
                { message = message.Insert(int.Parse(command[1]), command[2]); }
                else if(command[0] == "ChangeAll")
                { message = message.Replace(command[1], command[2]); }
                command = Console.ReadLine().Split("|");
            }
            Console.WriteLine("The decrypted message is: " + message);
        }
    }
}
