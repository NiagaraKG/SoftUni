using System;
using System.Collections.Generic;
using System.Linq;

namespace RecursionExercise
{
    public class Area
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Size { get; set; }
    }
    public class Program
    {
        private static char[,] matrix;
        public static int size;
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            matrix = new char[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                var line = Console.ReadLine();
                for (int c = 0; c < cols; c++)
                {
                    size = 0;
                    matrix[r, c] = line[c];
                }
            }
            var areas = new List<Area>();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    size = 0;
                    ExploreArea(r, c);
                    if(size != 0)
                    {
                        areas.Add(new Area { Row = r, Col = c, Size = size });
                    }
                }
            }
            areas = areas.OrderByDescending(x => x.Size).ThenBy(x=>x.Row).ThenBy(x=>x.Col).ToList();
            Console.WriteLine($"Total areas found: {areas.Count}");
            for (int i = 0; i < areas.Count; i++)
            {
                Console.WriteLine($"Area #{i+1} at ({areas[i].Row}, {areas[i].Col}), size: {areas[i].Size}");
            }
        }

        private static void ExploreArea(int row, int col)
        {
            if(row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1) || matrix[row,col] == '*' || matrix[row, col] == 'v')
            {
                return;
            }
            size++;
            matrix[row,col] = 'v';
            ExploreArea(row - 1, col);
            ExploreArea(row + 1, col);
            ExploreArea(row, col - 1);
            ExploreArea(row, col + 1);
        }
    }
}