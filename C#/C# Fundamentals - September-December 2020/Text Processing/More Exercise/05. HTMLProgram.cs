using System;

namespace _05._HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine(); Console.WriteLine("<h1>\n" + title + "\n</h1>");
            string article = Console.ReadLine(); Console.WriteLine("<article>\n" + article + "\n</article>");
            string comment = Console.ReadLine();
            while(comment != "end of comments")
            {
                Console.WriteLine("<div>\n" + comment + "\n</div>");
                comment = Console.ReadLine();
            }
        }
    }
}
