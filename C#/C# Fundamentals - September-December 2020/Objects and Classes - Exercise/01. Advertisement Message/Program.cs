using System;

namespace _01._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = new string[] { "Excellent product.", "Such a great product.", "I always use that product.", 
                "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            string[] events = new string[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] authors = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };
                Random r = new Random();
                string result = phrases[r.Next(0, 6)] + " " + events[r.Next(0, 6)] + " " + authors[r.Next(0, 8)] + " - " + cities[r.Next(0, 5)];
                Console.WriteLine(result);
            }
        }
    }
}
