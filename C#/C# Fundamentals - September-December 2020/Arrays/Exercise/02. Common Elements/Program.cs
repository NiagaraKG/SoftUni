using System;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] first = Console.ReadLine().Split();
            string[] second = Console.ReadLine().Split();
            string common = "";
            for (int i = 0; i < second.Length; i++)
            {
                for (int j = 0; j < first.Length; j++)
                {
                    if(second[i] == first[j]) { common += second[i] + " "; }
                }
            }
            Console.WriteLine(common);
        }
    }
}
