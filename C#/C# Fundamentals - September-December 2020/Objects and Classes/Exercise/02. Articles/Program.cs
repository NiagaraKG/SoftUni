using System;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            Article a = new Article(input);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                if(command[0] == "Edit")
                { a.Edit(command[1]); }
                else if(command[0] == "ChangeAuthor")
                { a.ChangeAuthor(command[1]); }
                else { a.Rename(command[1]); }
            }
            Console.WriteLine(a.ToString());
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

        public void Edit(string content)
        {
            this.Content = content;
        }

        public void ChangeAuthor(string author)
        {
            this.Author = author;
        }

        public void Rename(string title)
        {
            this.Title = title;
        }

        public override string ToString()
        {
            string result = this.Title + " - " + this.Content + ": " + this.Author;
            return result;
        }
    }

}
