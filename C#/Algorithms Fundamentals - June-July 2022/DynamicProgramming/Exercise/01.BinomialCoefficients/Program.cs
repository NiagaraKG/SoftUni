using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicProgrammingExercise
{
    public class Program
    {
        public static Dictionary<string, ulong> pascal = new Dictionary<string, ulong>();
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine(GetPascal(n, k));
        }

        private static ulong GetPascal(int n, int k)
        {
            if (n <= 1 || k == n || k == 0) { return 1; }
            string id = $"{n}-{k}";
            if (pascal.ContainsKey(id)) { return pascal[id]; }
            ulong result = GetPascal(n - 1, k - 1) + GetPascal(n - 1, k);
            pascal[id] = result;
            return result;
        }
    }
}