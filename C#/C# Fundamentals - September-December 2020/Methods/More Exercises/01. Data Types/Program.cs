using System;

namespace _01._Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            if (type == "int")
            {
                int n = 0;
                n = Read(n, Console.ReadLine());
                Console.WriteLine(n);
            }
            else if (type == "real")
            {
                double n = 0;
                n = Read(n, Console.ReadLine());
                Console.WriteLine(n.ToString("0.00"));
            }
            else
            {
                string result = "";
                result = Read(result, Console.ReadLine());
                Console.WriteLine(result);
            }
        }

        static int Read(int n, string s)
        {
            n = int.Parse(s);
            n *= 2;
            return n;
        }
        
        static double Read(double n, string s)
        {
            n = double.Parse(s);
            n *= 1.5;
            return n;
        }

        static string Read(string n, string s)
        {
            n = "$" + s + "$";
            return n;
        }

    }
}
