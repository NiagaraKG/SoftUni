using System;

namespace _01._Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                int start = line.IndexOf("@") + 1;
                int end = line.IndexOf("|");
                string name = line.Substring(start, end - start);
                start = line.IndexOf("#") + 1;
                end = line.IndexOf("*");
                string age = line.Substring(start, end - start);
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
