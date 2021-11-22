using System;

namespace _06._Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int balance = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (input == "(")
                {
                    if (balance == -1) { balance = -10; }
                    balance++;
                    if(balance == 2) { balance = -10; }                    
                }
                else if (input == ")")
                {
                    balance--;                    
                }
            }
            if(balance == 0) { Console.WriteLine("BALANCED"); }
            else { Console.WriteLine("UNBALANCED"); }
        }
    }
}
