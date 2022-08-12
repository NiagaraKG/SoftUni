using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    public class Program
    {
        private static List<int>[] outposts;
        private static bool[] reached;
        private static List<int> unreachable;
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            outposts = new List<int>[N + 1];
            unreachable = new List<int>();
            for (int i = 0; i < outposts.Length; i++)
            {
                outposts[i] = new List<int>();
            }
            for (int i = 0; i < M; i++)
            {
                var edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
                outposts[edge[0]].Add(edge[1]);
            }
            int start = int.Parse(Console.ReadLine());
            for (int i = 1; i < outposts.Length; i++)
            {
                if (i == start) { continue; }
                reached = new bool[N + 1];
                BFS(start, i);
            }
            Console.WriteLine(string.Join(" ", unreachable));
        }

        private static void BFS(int start, int end)
        {
            var q = new Queue<int>();
            q.Enqueue(start);
            reached[start] = true;
            while (q.Count > 0)
            {
                var current = q.Dequeue();
                if (current == end) { return; }
                foreach (var child in outposts[current])
                {
                    if (!reached[child])
                    {
                        reached[child] = true;
                        q.Enqueue(child);
                    }
                }
            }
            unreachable.Add(end);
        }
    }
}