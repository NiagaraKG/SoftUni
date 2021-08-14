using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> VIP = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();
            string command = Console.ReadLine();
            while (command != "PARTY")
            {
                if (Char.IsDigit(command[0])) { VIP.Add(command); }
                else { regular.Add(command); }
                command = Console.ReadLine();
            }
            command = Console.ReadLine();
            while (command != "END")
            {
                if (VIP.Contains(command)) { VIP.Remove(command); }
                else if (regular.Contains(command)) { regular.Remove(command); }
                command = Console.ReadLine();
            }
            Console.WriteLine(VIP.Count + regular.Count);
            if (VIP.Count > 0) { Console.WriteLine(string.Join(Environment.NewLine, VIP)); }
            if (regular.Count > 0) { Console.WriteLine(string.Join(Environment.NewLine, regular)); }
        }
    }
}
