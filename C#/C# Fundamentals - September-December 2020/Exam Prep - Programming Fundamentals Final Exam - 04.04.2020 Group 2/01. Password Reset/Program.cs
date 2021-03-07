using System;
using System.Text;

namespace _01._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();
            string[] command = Console.ReadLine().Split();
            while (command[0] != "Done")
            {
                if (command[0] == "TakeOdd")
                {
                    StringBuilder odd = new StringBuilder();
                    for (int i = 1; i < pass.Length; i += 2) { odd.Append(pass[i]); }
                    pass = odd.ToString();
                    Console.WriteLine(pass);
                }
                else if (command[0] == "Cut")
                {
                    int start = int.Parse(command[1]), lenght = int.Parse(command[2]);
                    string sub = pass.Substring(start, lenght);
                    pass = pass.Remove(pass.IndexOf(sub), sub.Length);
                    Console.WriteLine(pass);
                }
                else
                {
                    if (pass.Contains(command[1]))
                    {
                        pass = pass.Replace(command[1], command[2]); Console.WriteLine(pass);
                    }
                    else { Console.WriteLine("Nothing to replace!"); }
                }
                command = Console.ReadLine().Split();
            }
            Console.WriteLine("Your password is: " + pass);
        }
    }
}
