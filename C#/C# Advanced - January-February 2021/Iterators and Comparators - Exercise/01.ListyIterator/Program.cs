using System;
using System.Linq;

namespace _01.ListyIterator
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] items = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            ListIterator<string> collection = new ListIterator<string>(items);
            string command = Console.ReadLine();
            while (command != "END")
            {
                switch (command)
                {
                    case "Move": Console.WriteLine(collection.Move()); break;
                    case "HasNext": Console.WriteLine(collection.HasNext()); break;
                    case "Print":
                        try { collection.Print(); }
                        catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
