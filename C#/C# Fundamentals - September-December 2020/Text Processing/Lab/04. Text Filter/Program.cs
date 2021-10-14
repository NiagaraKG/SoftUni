using System;

namespace _04._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] banned = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();
            foreach (var word in banned)
            {
                string replacement = "";
                foreach (var letter in word) { replacement += "*"; }
                text = text.Replace(word, replacement);
            }
            Console.WriteLine(text);
        }
    }
}
