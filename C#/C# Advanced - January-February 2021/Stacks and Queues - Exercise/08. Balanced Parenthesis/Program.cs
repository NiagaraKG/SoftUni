using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Queue<char> brackets = new Queue<char>(input);
            bool match = true;
            while (brackets.Count > 2)
            {
                int half = brackets.Count / 2 - 1;
                for (int i = 0; i < half; i++) { brackets.Enqueue(brackets.Dequeue()); }
                char first = brackets.Dequeue(), second = brackets.Dequeue();
                if(first == '(' && second == ')') { match = true; }
                else if(first == '[' && second == ']') { match = true; }
                else if(first == '{' && second == '}') { match = true; }
                else { Console.WriteLine("NO"); return; }
                for (int i = 0; i < half; i++) { brackets.Enqueue(brackets.Dequeue()); }
            }
            Console.WriteLine("YES"); 
        }
    }
}
