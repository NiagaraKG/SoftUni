using System;
using System.Collections.Generic;

namespace _03._Take_Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> digits = new List<int>();
            List<char> symbols = new List<char>();
            for (int i = 0; i < input.Length; i++)
            {
                if(Char.IsDigit(input[i]))
                {                    
                    digits.Add(input[i] - '0'); 
                }
                else { symbols.Add(input[i]); }
            }
           
            int textindex = 0, br = 0;
            string result = "";
            for (int i = 0; i < digits.Count; i++)
            {
                if(i%2==0)
                {
                    while (br < digits[i] && textindex < symbols.Count)
                    {
                        result += symbols[textindex];
                        br++;
                        textindex++;
                    }
                    br = 0;
                }
                else 
                {
                    while (br < digits[i] && textindex < symbols.Count)
                    {                        
                        br++;
                        textindex++;
                    }
                    br = 0;
                }
            }
            Console.WriteLine(result);
        }
    }
}
