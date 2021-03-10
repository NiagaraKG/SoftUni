using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> attacks = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            char[,] field = new char[n, n];
            int ships1 = 0, ships2 = 0;
            for (int r = 0; r < n; r++)
            {
                char[] row = Console.ReadLine().ToCharArray().Where(x => x != ' ').ToArray();
                for (int c = 0; c < n; c++)
                {
                    field[r, c] = row[c];
                    if (field[r, c] == '<') { ships1++; }
                    else if (field[r, c] == '>') { ships2++; }
                }
            }
            int allShips = ships1 + ships2;
            for (int i = 0; i < attacks.Count; i++)
            {
                int[] attack = attacks[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                if (attack[0] >= 0 && attack[0] < n && attack[1] >= 0 && attack[1] < n)
                {
                    if (field[attack[0], attack[1]] == '<') { ships1--; field[attack[0], attack[1]] = 'X'; }
                    else if (field[attack[0], attack[1]] == '>') { ships2--; field[attack[0], attack[1]] = 'X'; }
                    if (field[attack[0], attack[1]] == '#')
                    {
                        field[attack[0], attack[1]] = 'X';
                        if (attack[0] + 1 < n)
                        {
                            if (field[attack[0] + 1, attack[1]] == '<') { ships1--; field[attack[0] + 1, attack[1]] = 'X'; }
                            if (field[attack[0] + 1, attack[1]] == '>') { ships2--; field[attack[0] + 1, attack[1]] = 'X'; }
                        }
                        if (attack[1] + 1 < n)
                        {
                            if (field[attack[0], attack[1] + 1] == '<') { ships1--; field[attack[0], attack[1] + 1] = 'X'; }
                            if (field[attack[0], attack[1] + 1] == '>') { ships2--; field[attack[0], attack[1] + 1] = 'X'; }
                        }
                        if (attack[0] - 1 >= 0)
                        {
                            if (field[attack[0] - 1, attack[1]] == '<') { ships1--; field[attack[0] - 1, attack[1]] = 'X'; }
                            if (field[attack[0] - 1, attack[1]] == '>') { ships2--; field[attack[0] - 1, attack[1]] = 'X'; }
                        }
                        if (attack[1] - 1 >= 0)
                        {
                            if (field[attack[0], attack[1] - 1] == '<') { ships1--; field[attack[0], attack[1] - 1] = 'X'; }
                            if (field[attack[0], attack[1] - 1] == '>') { ships2--; field[attack[0], attack[1] - 1] = 'X'; }
                        }
                        if (attack[0] - 1 >= 0 && attack[1] + 1 < n)
                        {
                            if (field[attack[0] - 1, attack[1] + 1] == '<') { ships1--; field[attack[0] - 1, attack[1] + 1] = 'X'; }
                            if (field[attack[0] - 1, attack[1] + 1] == '>') { ships2--; field[attack[0] - 1, attack[1] + 1] = 'X'; }
                        }
                        if (attack[0] + 1 < n && attack[1] - 1 >= 0)
                        {
                            if (field[attack[0] + 1, attack[1] - 1] == '<') { ships1--; field[attack[0] + 1, attack[1] - 1] = 'X'; }
                            if (field[attack[0] + 1, attack[1] - 1] == '>') { ships2--; field[attack[0] + 1, attack[1] - 1] = 'X'; }
                        }
                        if (attack[0] - 1 >= 0 && attack[1] - 1 >= 0)
                        {
                            if (field[attack[0] - 1, attack[1] - 1] == '<') { ships1--; field[attack[0] - 1, attack[1] - 1] = 'X'; }
                            if (field[attack[0] - 1, attack[1] - 1] == '>') { ships2--; field[attack[0] - 1, attack[1] - 1] = 'X'; }
                        }
                        if (attack[0] + 1 < n && attack[1] + 1 < n)
                        {
                            if (field[attack[0] + 1, attack[1] + 1] == '<') { ships1--; field[attack[0] + 1, attack[1] + 1] = 'X'; }
                            if (field[attack[0] + 1, attack[1] + 1] == '>') { ships2--; field[attack[0] + 1, attack[1] + 1] = 'X'; }
                        }
                    }
                }
                if (ships1 == 0 || ships2 == 0) { break; }
            }
            if (ships1 == 0) { Console.WriteLine($"Player Two has won the game! {allShips - ships2} ships have been sunk in the battle."); }
            else if (ships2 == 0) { Console.WriteLine($"Player One has won the game! {allShips - ships1} ships have been sunk in the battle."); }
            else { Console.WriteLine($"It's a draw! Player One has {ships1} ships left. Player Two has {ships2} ships left."); }
        }
    }
}
