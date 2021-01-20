using System;
using System.Collections.Generic;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> history = new Stack<string>();
            int n = int.Parse(Console.ReadLine());
            string text = "";
            history.Push(text);
            for (int i = 0; i < n; i++)
            {
                text = history.Peek();
                string[] command = Console.ReadLine().Split();
                if (command[0] == "1")
                {
                    text += command[1];
                    history.Push(text);
                }
                else if(command[0] == "2")
                {
                    text = text.Remove(text.Length - int.Parse(command[1]));
                    history.Push(text);
                }
                else if (command[0] == "3")
                {
                    Console.WriteLine(text[int.Parse(command[1]) - 1]);
                }
                else if (command[0] == "4")
                {
                    history.Pop();
                }
            }
        }
    }
}
