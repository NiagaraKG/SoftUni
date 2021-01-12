using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger Value = 0;
            int Snow = 0, Time = 0, Quality = 0;
            for (int i = 0; i < n; i++)
            {
                int snow = int.Parse(Console.ReadLine());
                int time = int.Parse(Console.ReadLine());
                int quality = int.Parse(Console.ReadLine());
                BigInteger value = BigInteger.Pow((snow / time), quality);
                if(value > Value)
                {
                    Value = value;
                    Snow = snow;
                    Time = time;
                    Quality = quality;
                }
            }
            Console.WriteLine($"{Snow} : {Time} = {Value} ({Quality})");
        }
    }
}
