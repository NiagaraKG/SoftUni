using System;

namespace _06._Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        char f = Convert.ToChar(i + 97);
                        char s = Convert.ToChar(j + 97);
                        char t = Convert.ToChar(k + 97);
                        Console.WriteLine($"{f}{s}{t}");
                    }
                }
            }
        }
    }
}
