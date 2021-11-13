using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            if(type == "int")
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(a, b));
            }
            else if(type == "char")
            {
                char a = char.Parse(Console.ReadLine());
                char b = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(a, b));
            }
            else if(type == "string")
            {
                string a = Console.ReadLine();
                string b = Console.ReadLine();                
                Console.WriteLine(GetMax(a, b));
            }
        }

        static int GetMax(int a, int b)
        {
            return Math.Max(a, b);
        }
        static char GetMax(char a, char b)
        {
            if(a > b) { return a; }
            return b;
        }
        static string GetMax(string a, string b)
        {            
            if(a[0] > b[0])
            {
                return a;
            }
            if(a[0] < b[0])
            {
                return b;
            }
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > b[i])
                {
                    return a;
                }
                if (a[i] < b[i])
                {
                    return b;
                }
            }
            return a;
        }

    }
}
