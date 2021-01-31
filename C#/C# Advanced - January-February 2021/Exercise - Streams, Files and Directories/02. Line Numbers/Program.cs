using System;
using System.IO;

namespace _02._Line_Numbers
{
    class Program
    {
        static int CountLetters(string line)
        {
            int br = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if(char.IsLetter(line[i])) { br++; }
            }
            return br;
        }
        static int CountPunctuation(string line)
        {
            int br = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if(char.IsPunctuation(line[i])) { br++; }
            }
            return br;
        }
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                int letters = CountLetters(lines[i]);
                int punctuation = CountPunctuation(lines[i]);
                lines[i] = $"Line {i+1}: {lines[i]} ({letters})({punctuation})";
            }
            File.WriteAllLines("../../../output.txt", lines);
        }
    }
}
