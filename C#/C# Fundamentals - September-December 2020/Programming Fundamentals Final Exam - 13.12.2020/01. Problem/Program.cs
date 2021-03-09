using System;

namespace _01._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "Done")
            {
                if (command[0] == "Change")
                {
                    input = input.Replace(command[1], command[2]);
                    Console.WriteLine(input);
                }
                else if (command[0] == "End")
                {
                    string end = input.Substring(input.Length - command[1].Length);
                    if (end == command[1]) { Console.WriteLine("True"); }
                    else { Console.WriteLine("False"); }
                }
                else if (command[0] == "Uppercase")
                {
                    input = input.ToUpper();
                    Console.WriteLine(input);
                }
                else if (command[0] == "Includes")
                {
                    if (input.Contains(command[1])) { Console.WriteLine("True"); }
                    else { Console.WriteLine("False"); }
                }
                else if (command[0] == "FindIndex")
                {
                    int i = input.IndexOf(command[1]);
                    Console.WriteLine(i);
                }
                else if (command[0] == "Cut")
                {
                    int start = int.Parse(command[1]), end = start + int.Parse(command[2]);
                    if (end < input.Length) { input = input.Remove(end); }
                    input = input.Remove(0, start);
                    Console.WriteLine(input);
                }
                command = Console.ReadLine().Split();
            }
        }
    }
}
