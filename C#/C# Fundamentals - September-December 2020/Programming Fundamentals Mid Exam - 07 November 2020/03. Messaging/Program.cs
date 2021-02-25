using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chat = new List<string>();
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (command[0] != "end")
            {
                if (command[0] == "Chat")
                {
                    chat.Add(command[1]);
                }
                else if (command[0] == "Delete")
                {
                    if (chat.Contains(command[1])) { chat.Remove(command[1]); }
                }
                else if (command[0] == "Edit")
                {
                    int i = chat.IndexOf(command[1]);
                    chat[i] = command[2];
                }
                else if (command[0] == "Pin")
                {
                    chat.Remove(command[1]);
                    chat.Add(command[1]);
                }
                else if (command[0] == "Spam")
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        chat.Add(command[i]);
                    }
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            Console.WriteLine(string.Join(Environment.NewLine, chat));
        }
    }
}
