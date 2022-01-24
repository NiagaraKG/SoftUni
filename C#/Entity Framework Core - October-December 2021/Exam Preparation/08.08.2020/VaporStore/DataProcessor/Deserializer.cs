namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gameDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            HashSet<Game> games = new HashSet<Game>();
            HashSet<Developer> developers = new HashSet<Developer>();
            HashSet<Genre> genres = new HashSet<Genre>();
            HashSet<Tag> tags = new HashSet<Tag>();
            foreach (var gameDto in gameDtos)
            {
                if (!IsValid(gameDto)) { sb.AppendLine("Invalid Data"); continue; }
                if (!DateTime
                    .TryParse(gameDto.ReleaseDate, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime releaseDate))
                { sb.AppendLine("Invalid Data"); continue; }

                Developer developer = developers.FirstOrDefault(d => d.Name == gameDto.Developer);
                if (developer == null)
                {
                    developer = new Developer() { Name = gameDto.Developer };
                    developers.Add(developer);
                }

                Genre genre = genres.FirstOrDefault(g => g.Name == gameDto.Genre);
                if (genre == null)
                {
                    genre = new Genre() { Name = gameDto.Genre };
                    genres.Add(genre);
                }

                var g = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate,
                    Developer = developer,
                    Genre = genre
                };

                foreach (var tag in gameDto.Tags)
                {
                    Tag dbTag = tags.FirstOrDefault(t => t.Name == tag);
                    if (dbTag == null)
                    {
                        dbTag = new Tag() { Name = tag };
                        tags.Add(dbTag);
                    }

                    g.GameTags.Add(new GameTag() { Tag = dbTag });
                }
                games.Add(g);
                sb.AppendLine($"Added {gameDto.Name} ({gameDto.Genre}) with {gameDto.Tags.Length} tags");
            }
            context.Games.AddRange(games);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);
            var sb = new StringBuilder();
            HashSet<User> users = new HashSet<User>();
            foreach (var userDto in userDtos)
            {
                if (!IsValid(userDto)) { sb.AppendLine("Invalid Data"); continue; }
                var u = new User()
                {
                    Age = userDto.Age,
                    Email = userDto.Email,
                    FullName = userDto.FullName,
                    Username = userDto.Username
                };
                bool hasInvalidCard = false;
                foreach (var card in userDto.Cards)
                {
                    string[] validTypes = new string[] { "Debit", "Credit" };
                    if (!IsValid(card) || !validTypes.Any(t => t == card.Type)) { hasInvalidCard = true; break; }
                    Card c = new Card() { Cvc = card.Cvc, Number = card.Number };
                    c.Type = (CardType)Enum.Parse(typeof(CardType), card.Type);
                    u.Cards.Add(c);
                }
                if (hasInvalidCard) { sb.AppendLine("Invalid Data"); continue; }
                users.Add(u);
                sb.AppendLine($"Imported {userDto.Username} with {userDto.Cards.Length} cards");
            }
            context.Users.AddRange(users);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Purchases");
            XmlSerializer xmlserializer = new XmlSerializer(typeof(ImportPurchaseDto[]), root);
            StringReader sr = new StringReader(xmlString);
            ImportPurchaseDto[] purchaseDtos = (ImportPurchaseDto[])xmlserializer.Deserialize(sr);
            HashSet<Purchase> purchases = new HashSet<Purchase>();
            foreach (var purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto)) { sb.AppendLine("Invalid Data"); continue; }

                bool parsedDate = DateTime.TryParseExact(
                    purchaseDto.Date, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out var date);
                if (!parsedDate) { sb.AppendLine("Invalid Data"); continue; }

                if (!Enum.TryParse(typeof(PurchaseType), purchaseDto.Type, out object type))
                { sb.AppendLine("Invalid Data"); continue; }

                var p = new Purchase()
                {
                    ProductKey = purchaseDto.Key,
                    Date = date,
                    Type = (PurchaseType)type,
                    Card = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.Card),
                    Game = context.Games.FirstOrDefault(x => x.Name == purchaseDto.Title),
                };
                purchases.Add(p);
                var username = context.Users.Where(x => x.Id == p.Card.UserId)
                    .Select(x => x.Username).FirstOrDefault();
                sb.AppendLine($"Imported {purchaseDto.Title} for {username}");
            }
            context.Purchases.AddRange(purchases);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}