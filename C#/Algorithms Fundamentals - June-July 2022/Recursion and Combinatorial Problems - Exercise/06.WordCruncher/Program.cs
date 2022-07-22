using System;
using System.Collections.Generic;
using System.Linq;

namespace RecursionExercise
{
    public class Program
    {
        private static string target;
        private static Dictionary<int, List<string>> wordsByIndex;
        private static Dictionary<string, int> wordsCounts;
        private static LinkedList<string> used;
        public static void Main()
        {
            var words = Console.ReadLine().Split(", ");
            target = Console.ReadLine();
            wordsByIndex = new Dictionary<int, List<string>>();
            wordsCounts = new Dictionary<string, int>();
            used = new LinkedList<string>();
            foreach (var word in words)
            {
                var index = target.IndexOf(word);
                if (index == -1) { continue; }
                if (wordsCounts.ContainsKey(word))
                {
                    wordsCounts[word]++;
                    continue;
                }
                wordsCounts[word] = 1;
                while (index != -1)
                {
                    if(!wordsByIndex.ContainsKey(index))
                    {
                        wordsByIndex[index] = new List<string>();
                    }
                    wordsByIndex[index].Add(word);
                    index = target.IndexOf(word, index + 1);
                }
            }
            Generate(0);
        }

        private static void Generate(int index)
        {
            if(index == target.Length)
            {
                Console.WriteLine(string.Join(" ", used));
                return;
            }
            if(!wordsByIndex.ContainsKey(index)) { return; }
            foreach (var word in wordsByIndex[index])
            {
                if(wordsCounts[word] == 0) { continue; }
                wordsCounts[word]--;
                used.AddLast(word);
                Generate(index + word.Length);
                used.RemoveLast();
                wordsCounts[word]++;
            }
        }
    }
}