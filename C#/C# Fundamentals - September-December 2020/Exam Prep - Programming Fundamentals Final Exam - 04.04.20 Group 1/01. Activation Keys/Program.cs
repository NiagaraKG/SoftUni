using System;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string[] command = Console.ReadLine().Split(">>>");
            while (command[0] != "Generate")
            {
                if (command[0] == "Contains")
                {
                    if (key.Contains(command[1])) { Console.WriteLine($"{key} contains {command[1]}"); }
                    else { Console.WriteLine("Substring not found!"); }
                }
                if (command[0] == "Flip")
                {
                    char[] chars = key.ToCharArray();
                    int start = int.Parse(command[2]), end = int.Parse(command[3]);
                    if (command[1] == "Upper")
                    { for (int i = start; i < end; i++) { chars[i] = char.ToUpper(chars[i]); } }
                    else { for (int i = start; i < end; i++) { chars[i] = char.ToLower(chars[i]); } }
                    key = string.Join("", chars); Console.WriteLine(key);
                }
                if (command[0] == "Slice")
                {
                    int start = int.Parse(command[1]), end = int.Parse(command[2]);
                    key = key.Remove(start, end - start);
                    Console.WriteLine(key);
                }
                command = Console.ReadLine().Split(">>>");
            }
            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
