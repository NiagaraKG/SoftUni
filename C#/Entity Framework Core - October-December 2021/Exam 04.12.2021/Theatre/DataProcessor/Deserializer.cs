namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPlayDto[]), xmlRoot);
            StringReader sr = new StringReader(xmlString);
            ImportPlayDto[] playDtos = (ImportPlayDto[])
            xmlSerializer.Deserialize(sr);
            HashSet<Play> plays = new HashSet<Play>();
            foreach (var playDto in playDtos)
            {
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (!Enum.TryParse(playDto.Genre, out Genre genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var duration = TimeSpan.ParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture);
                if (duration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Play p = new Play()
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Rating = playDto.Rating,
                    Genre = genre,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };
                plays.Add(p);
                sb.AppendLine(string.Format(SuccessfulImportPlay, p.Title, p.Genre, p.Rating));
            }
            context.AddRange(plays);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCastDto[]), xmlRoot);
            StringReader sr = new StringReader(xmlString);
            var castDtos = (ImportCastDto[])xmlSerializer.Deserialize(sr);
            HashSet<Cast> casts = new HashSet<Cast>();
            foreach (var castDto in castDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Cast c = new Cast
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };
                casts.Add(c);
                sb.AppendLine(string.Format(SuccessfulImportActor, c.FullName, c.IsMainCharacter ? "main" : "lesser"));
            }
            context.AddRange(casts);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var theatreDtos = JsonConvert.DeserializeObject<ImportTheatreDto[]>(jsonString);
            HashSet<Theatre> theatres = new HashSet<Theatre>();
            foreach (var theatreDto in theatreDtos)
            {
                if (!IsValid(theatreDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                HashSet<Ticket> tickets = new HashSet<Ticket>();
                foreach (var ticketDto in theatreDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    var ticket = new Ticket
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    };
                    tickets.Add(ticket);
                }
                var theatre = new Theatre
                {
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director = theatreDto.Director,
                    Tickets = tickets
                };
                theatres.Add(theatre);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }
            context.AddRange(theatres);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
