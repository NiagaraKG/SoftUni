using System;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();
            for (int i = 0; i < text.Length; i++)
            {
                text[i] = (char)((int)text[i] + 3);
            }
            Console.WriteLine(string.Join("", text));
        }
    }
}
