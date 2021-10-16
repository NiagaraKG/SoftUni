using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> first = Console.ReadLine().ToCharArray().ToList();
            while(first[0] == '0') { first.RemoveAt(0); }
            int second = int.Parse(Console.ReadLine());
            int factor = 0;
            string result = "";
            if (second == 0 || first.Count == 0) { result = "0"; }
            else
            {
                for (int i = first.Count - 1; i >= 0; i--)
                {
                    int product = second * (first[i] - '0') + factor;
                    factor = product / 10;
                    product = product % 10;
                    result = result.Insert(0, (product).ToString());

                }
                if (factor > 0) { result = result.Insert(0, factor.ToString()); }
            }
            Console.WriteLine(result);
        }
    }
}
