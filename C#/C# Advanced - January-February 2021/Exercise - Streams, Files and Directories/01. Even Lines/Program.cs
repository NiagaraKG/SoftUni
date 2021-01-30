using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string line = reader.ReadLine();
                int br = 0;
                while (line != null)
                {
                    if(br%2 == 0) 
                    {
                        Regex pattern = new Regex(@"[-,.!?]");
                        line = pattern.Replace(line, "@");
                        string[] words = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        words = words.Reverse().ToArray();                        
                        Console.WriteLine(string.Join(" ", words));
                    }
                    line = reader.ReadLine();
                    br++;
                }
            }
        }
    }
}
