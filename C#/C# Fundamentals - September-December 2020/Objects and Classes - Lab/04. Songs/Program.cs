using System;
using System.Collections.Generic;

namespace _04._Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> all = new List<Song>();
            for (int i = 0; i < n; i++)
            {
                string[] current = Console.ReadLine().Split('_');
                Song curr = new Song();
                curr.type = current[0];
                curr.name = current[1];
                curr.time = current[2];
                all.Add(curr);
            }
            string type = Console.ReadLine();
            if (type != "all")
            {
                foreach (var item in all)
                {
                    if (item.type == type)
                    {
                        Console.WriteLine(item.name);
                    }
                }
            }
            else
            {
                foreach (var item in all)
                {
                    Console.WriteLine(item.name);
                }
            }
        }
    }

    class Song
    {
        public string type { get; set; }
        public string name { get; set; }
        public string time { get; set; }
    }

}
