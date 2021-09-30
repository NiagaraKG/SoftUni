using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string biggest = "";
            double max = 0;
            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double r = double.Parse(Console.ReadLine());
                int h = int.Parse(Console.ReadLine());
                double V = Math.PI * Math.Pow(r,2) * h;
                if(V > max) 
                {
                    biggest = model;
                    max = V;
                }
            }
            Console.WriteLine(biggest);
        }
    }
}
