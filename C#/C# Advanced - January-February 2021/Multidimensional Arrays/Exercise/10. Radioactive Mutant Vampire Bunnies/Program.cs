using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] lair = new char[dimentions[0], dimentions[1]];
            int playerR = -1, playerC = -1;
            for (int r = 0; r < dimentions[0]; r++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int c = 0; c < dimentions[1]; c++)
                {
                    lair[r, c] = row[c];
                    if (lair[r, c] == 'P') { playerR = r; playerC = c; }
                }
            }
            char[] directions = Console.ReadLine().ToCharArray();
            bool iswinner = false, isdead = false;
            foreach (var d in directions)
            {
                int newR = playerR, newC = playerC;
                if (d == 'U') { newR--; }
                else if (d == 'D') { newR++; }
                else if (d == 'L') { newC--; }
                else if (d == 'R') { newC++; }
                if (!IsValidCell(newR, newC, dimentions[0], dimentions[1]))
                {
                    iswinner = true;
                    lair[playerR, playerC] = '.';
                    List<int[]> bunnies = GetBunnies(lair);
                    SpreadBunnies(bunnies, lair);
                }
                else if (lair[newR, newC] == '.')
                {
                    lair[playerR, playerC] = '.';
                    lair[newR, newC] = 'P';
                    playerR = newR; playerC = newC;
                    List<int[]> bunnies = GetBunnies(lair);
                    SpreadBunnies(bunnies, lair);
                    if (lair[playerR, playerC] == 'B') { isdead = true; }
                }
                else if (lair[newR, newC] == 'B')
                {
                    isdead = true;
                    lair[playerR, playerC] = '.';
                    playerR = newR; playerC = newC;
                    List<int[]> bunnies = GetBunnies(lair);
                    SpreadBunnies(bunnies, lair);
                }
                if (isdead || iswinner) { break; }
            }
            for (int r = 0; r < dimentions[0]; r++)
            {
                for (int c = 0; c < dimentions[1]; c++) { Console.Write(lair[r, c]); }
                Console.WriteLine();
            }
            if (iswinner) { Console.WriteLine($"won: {playerR} {playerC}"); }
            else if (isdead) { Console.WriteLine($"dead: {playerR} {playerC}"); }
        }

        private static void SpreadBunnies(List<int[]> bunnies, char[,] lair)
        {
            foreach (var b in bunnies)
            {
                SpreadBunny(b[0] - 1, b[1], lair);
                SpreadBunny(b[0] + 1, b[1], lair);
                SpreadBunny(b[0], b[1] - 1, lair);
                SpreadBunny(b[0], b[1] + 1, lair);
            }
        }

        private static void SpreadBunny(int r, int c, char[,] lair)
        {
            if (IsValidCell(r, c, lair.GetLength(0), lair.GetLength(1))) { lair[r, c] = 'B'; }
        }

        private static List<int[]> GetBunnies(char[,] lair)
        {
            List<int[]> bunnies = new List<int[]>();
            for (int r = 0; r < lair.GetLength(0); r++)
            {
                for (int c = 0; c < lair.GetLength(1); c++)
                { if (lair[r, c] == 'B') { bunnies.Add(new int[] { r, c }); } }
            }
            return bunnies;
        }

        private static bool IsValidCell(int r, int c, int n, int m) { return r >= 0 && r < n && c >= 0 && c < m; }
    }
}
