using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();            
            while (input != "END")
            {
                int[] num = new int[input.Length];
                for (int i = 0; i < input.Length; i++)
                {
                    num[i] = input[i];
                }
                
                if(isPalindrome(num)) { Console.WriteLine("true"); }
                else { Console.WriteLine("false"); }
                input = Console.ReadLine();
            }
        }

        static bool isPalindrome (int[] num)
        {            
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] != num[num.Length - 1 - i])
                {
                    return false;                    
                }
            }
            return true;
        }
    }
}
