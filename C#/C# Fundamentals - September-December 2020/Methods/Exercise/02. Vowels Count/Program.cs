using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            CountVowels(input);
        }

        static void CountVowels(string input)
        {
            input = input.ToLowerInvariant();
            int br = 0;
            for (int i = 0; i < input.Length; i++)
            {                
                if(input[i] == 'a' || input[i] == 'e' || input[i] == 'i' || input[i] == 'o' || input[i] == 'u')
                { br++; }
            }
            Console.WriteLine(br);
        }

    }
}
