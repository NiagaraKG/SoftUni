using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> key = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            while (input != "find")
            {
                char[] text = input.ToCharArray();
                int index = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    text[i] = (char)(input[i] - key[index]);
                    index++;
                    if (index >= key.Count) { index = 0; }
                }

                int start = Array.IndexOf(text, '&') + 1;
                text[start - 1] = '.';
                input = string.Join("", text);
                int end = input.IndexOf("&");
                string type = input.Substring(start, end - start);
                start = input.IndexOf("<") + 1;
                end = input.IndexOf(">");
                string coordinates = input.Substring(start, end - start);
                Console.WriteLine($"Found {type} at {coordinates}");
                input = Console.ReadLine();
            }
        }
    }
}
