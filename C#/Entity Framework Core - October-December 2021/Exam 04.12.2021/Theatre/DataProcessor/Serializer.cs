namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres.ToArray()
                 .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                 .Select(t => new
                 {
                     Name = t.Name,
                     Halls = t.NumberOfHalls,
                     TotalIncome = t.Tickets.Where(tic => tic.RowNumber <= 5).Sum(tic => tic.Price),
                     Tickets = t.Tickets.Where(tic => tic.RowNumber <= 5).Select(tic => new
                     { Price = decimal.Round(tic.Price, 2), RowNumber = tic.RowNumber })
                     .OrderByDescending(tic => tic.Price).ToArray()
                 }).OrderByDescending(t => t.Halls).ThenBy(t => t.Name).ToArray();
            string result = JsonConvert.SerializeObject(theatres, Formatting.Indented);
            return result;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Plays");
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPlayDto[]), root);
            StringWriter sw = new StringWriter(sb);
            var plays = context.Plays.ToArray().Where(p => p.Rating <= rating)
                .Select(p => new ExportPlayDto
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts.Where(a => a.IsMainCharacter).Select(a => new ExportActorDto
                    {
                        FullName = a.FullName,
                        MainCharacter = $"Plays main character in '{a.Play.Title}'."
                    }).OrderByDescending(a => a.FullName).ToArray()
                }).OrderBy(p => p.Title).ThenByDescending(p => p.Genre).ToArray();
            xmlSerializer.Serialize(sw, plays, namespaces);
            return sb.ToString().TrimEnd();
        }
    }
}
