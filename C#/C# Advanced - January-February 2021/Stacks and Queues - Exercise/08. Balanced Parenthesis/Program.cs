using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
         static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray().ToArray();
            Stack<char> brackets = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '[' || input[i] == '{') { brackets.Push(input[i]); }
                else
                {
                    if (brackets.Any())
                    {
                        char opening = brackets.Pop();
                        if (opening == '(' && input[i] == ')') { }
                        else if (opening == '[' && input[i] == ']') { }
                        else if (opening == '{' && input[i] == '}') { }
                        else { Console.WriteLine("NO"); return; }
                    }
                    else { Console.WriteLine("NO"); return; }
                }
            }
            if (brackets.Any()) { Console.WriteLine("NO"); }
            else { Console.WriteLine("YES"); }
        }
    }
}
