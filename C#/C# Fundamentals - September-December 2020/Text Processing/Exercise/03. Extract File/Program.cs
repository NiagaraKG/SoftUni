using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split("\\");
            string[] result = command[command.Length - 1].Split(".");
            Console.WriteLine($"File name: {result[0]}");
            Console.WriteLine($"File extension: {result[1]}");
        }
    }
}
