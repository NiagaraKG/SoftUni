using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Article> all = new List<Article>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                Article a = new Article(input);
                all.Add(a);
            }
            string orderBy = Console.ReadLine();
            if (orderBy == "title") { all = all.OrderBy(a => a.Title).ToList(); }
            else if (orderBy == "content") { all = all.OrderBy(a => a.Content).ToList(); }
            else { all = all.OrderBy(a => a.Author).ToList(); }
            foreach (var item in all)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string[] input)
        {
            this.Title = input[0];
            this.Content = input[1];
            this.Author = input[2];
        }

        public override string ToString()
        {
            string result = this.Title + " - " + this.Content + ": " + this.Author;
            return result;
        }
    }

}
