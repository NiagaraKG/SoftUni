using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> indexes = Console.ReadLine().Split().Select(int.Parse).ToList();
            string message = Console.ReadLine();
            string result = "";
            for (int i = 0; i < indexes.Count; i++)
            {
                int sum = 0;
                while (indexes[i] > 0)
                {
                    sum += indexes[i] % 10;
                    indexes[i] /= 10;
                }
                while(sum >= message.Length)
                { sum -= message.Length; }
                result += message[sum];
                message = message.Remove(sum, 1);
            }
            Console.WriteLine(result);
        }
    }
}
