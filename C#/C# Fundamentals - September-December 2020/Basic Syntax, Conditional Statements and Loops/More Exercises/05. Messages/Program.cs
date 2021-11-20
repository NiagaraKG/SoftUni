using System;

namespace _05._Messages
{
    class Program
    {
        static void Main(string[] args)
        {   
            int n = int.Parse(Console.ReadLine());
            string result = "";
            for (int i = 0; i < n; i++)
            {
                string letter = Console.ReadLine();
                string first = "";
                first += letter[0];
                if (first == "0") { result += " "; }
                else
                {
                    int num = (int.Parse(first) - 2) * 3;
                    if (int.Parse(first) == 8 || int.Parse(first) == 9) { num++; }
                    num += letter.Length - 1;
                    num += 97;
                    result += (char)num;
                }
            }
            Console.Write(result);
        }
    }
}
