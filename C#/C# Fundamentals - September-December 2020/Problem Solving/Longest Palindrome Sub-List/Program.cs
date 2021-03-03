using System;

namespace Longest_Palindrome_Sub_List
{
    class Program
    {
        static int PalindromeLenght(string letters, int left, int right)
        {
            while(left>=0 && right < letters.Length && letters[left] == letters[right])
            { left--; right++; }
            return right - left - 1;
        }
        static void Main(string[] args)
        {
            string letters = Console.ReadLine();
            int maxLen = 0;
            for (int c = 0; c < letters.Length; c++)
            {
                maxLen = Math.Max(maxLen, PalindromeLenght(letters, c, c));
            }
            for (int c = 0; c < letters.Length-1; c++)
            {
                maxLen = Math.Max(maxLen, PalindromeLenght(letters, c, c+1));
            }
            Console.WriteLine(maxLen);
        }
    }
}
