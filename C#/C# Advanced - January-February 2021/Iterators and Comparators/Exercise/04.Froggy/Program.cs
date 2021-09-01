using System;
using System.Linq;

namespace _04.Froggy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Lake<int> stones = new Lake<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            string result = "";
            foreach (var item in stones) { result += item + ", "; }
            result = result.TrimEnd(new char[] { ',', ' '});
            Console.WriteLine(result);
        }
    }
}
