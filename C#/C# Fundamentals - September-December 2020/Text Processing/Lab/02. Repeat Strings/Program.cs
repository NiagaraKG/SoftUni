using System;
using System.Text;

namespace _02._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            StringBuilder s = new StringBuilder();
            foreach (var item in input)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    s.Append(item);
                }
            }
            Console.WriteLine(s.ToString());
        }
    }
}
