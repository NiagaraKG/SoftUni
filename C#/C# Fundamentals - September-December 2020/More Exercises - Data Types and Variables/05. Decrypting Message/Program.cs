using System;

namespace _05._Decrypting_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string result = "";
            for (int i = 0; i < n; i++)
            {
                char current = char.Parse(Console.ReadLine());
                result += (char)((int)current + key);
            }
            Console.Write(result);
        }
    }
}
