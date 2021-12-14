namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
            RemoveBooks(db);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);
            var books = context.Books.Where(books => books.AgeRestriction == ageRestriction)
                .Select(b => b.Title).OrderBy(title => title).ToArray();
            var result = String.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books.Where(books => books.EditionType == EditionType.Gold && books.Copies < 5000).Select(b => new { b.BookId, b.Title }).OrderBy(x => x.BookId).ToArray();
            var result = String.Join(Environment.NewLine, books.Select(x => x.Title));
            return result;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books.Where(books => books.Price > 40)
                .Select(books => new { books.Title, books.Price })
                .OrderByDescending(books => books.Price).ToArray();
            var result = string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - ${x.Price:f2}"));
            return result;
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books.Where(book => book.ReleaseDate.Value.Year != year)
                .Select(b => new { b.Title, b.BookId }).OrderBy(x => x.BookId).ToArray();
            var result = string.Join(Environment.NewLine, books.Select(x => x.Title));
            return result;
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(c => c.ToLower()).ToList();
            var books = context.Books.Where(book => book.BookCategories
            .Any(category => categories.Contains(category.Category.Name.ToLower())))
                .Select(x => new { Title = x.Title }).OrderBy(x => x.Title).ToList();
            var sb = new StringBuilder();
            foreach (var b in books) { sb.AppendLine(b.Title); }
            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books.Where(books => books.ReleaseDate.Value < targetDate)
                .Select(b => new
                { b.Title, b.EditionType, b.Price, b.ReleaseDate.Value })
                .OrderByDescending(x => x.Value).ToArray();
            var result = string.Join(Environment.NewLine, books.Select(x =>
            $"{x.Title} - {x.EditionType} - ${x.Price:f2}"));
            return result;
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var autors = context.Authors.Where(a => a.FirstName.EndsWith(input))
                .Select(a => new { a.FirstName, a.LastName })
                .OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToArray();
            var result = string.Join(Environment.NewLine, autors.Select(x =>
            $"{x.FirstName} {x.LastName}"));
            return result;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var titles = context.Books.Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(x => new { x.Title }).OrderBy(x => x.Title).ToList();
            var sb = new StringBuilder();
            foreach (var book in titles) { sb.AppendLine(book.Title); }
            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books.OrderBy(a => a.BookId)
                .Where(a => a.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(a => new
                { Title = a.Title, Author = a.Author.FirstName + ' ' + a.Author.LastName }).ToList();
            var sb = new StringBuilder();
            foreach (var b in books) { sb.AppendLine($"{b.Title} ({b.Author})"); }
            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books.Where(b => b.Title.Length > lengthCheck).ToList();
            return books.Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors.Select(a => new
            { a.FirstName, a.LastName, BooksCount = a.Books.Sum(b => b.Copies) })
                .OrderByDescending(b => b.BooksCount).ToArray();
            var result = string.Join(Environment.NewLine, authors.Select(a =>
            $"{a.FirstName} {a.LastName} - {a.BooksCount}"));
            return result;
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories.Select(c => new
            { c.Name, Profit = c.CategoryBooks.Sum(x => x.Book.Price * x.Book.Copies) })
                .OrderByDescending(x => x.Profit).ThenBy(x => x.Name).ToList();
            var sb = new StringBuilder();
            foreach (var c in categories) { sb.AppendLine($"{c.Name} ${c.Profit:f2}"); }
            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var books = context.Categories.OrderBy(x => x.Name).Select(x => new
            {
                x.Name,
                BooksName = x.CategoryBooks.OrderByDescending(b => b.Book.ReleaseDate)
                .Select(b => new { ReleaseDate = b.Book.ReleaseDate, Title = b.Book.Title })
                .Take(3).ToList()
            }).ToList();
            var sb = new StringBuilder();
            foreach (var c in books)
            {
                sb.AppendLine($"--{c.Name}");
                foreach (var b in c.BooksName)
                { sb.AppendLine($"{b.Title} ({b.ReleaseDate.Value.Year})"); }
            }
            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(b => b.ReleaseDate.Value.Year < 2010).ToList();
            foreach (var book in books) { book.Price += 5; }
            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Copies < 4200).ToList();
            var booksCategories = context.BooksCategories
                .Where(b => b.Book.Copies < 4200).ToList();
            context.BooksCategories.RemoveRange(booksCategories);
            context.Books.RemoveRange(books);
            context.SaveChanges();
            return books.Count();
        }
    }
}
