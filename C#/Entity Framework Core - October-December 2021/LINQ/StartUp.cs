namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            var result = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsInfo = context.Producers.FirstOrDefault(x => x.Id == producerId).Albums
                .Select(album => new
                {
                    AlbumName = album.Name,
                    ReleaseDate = album.ReleaseDate,
                    ProducerName = album.Producer.Name,
                    Songs = album.Songs.Select(song => new
                    {
                        SongName = song.Name,
                        Price = song.Price,
                        Writer = song.Writer.Name
                    }).OrderByDescending(x => x.SongName).ThenBy(x => x.Writer).ToList(),
                    AlbumPrice = album.Price
                }).OrderByDescending(x => x.AlbumPrice).ToList();
            var sb = new StringBuilder();
            foreach (var a in albumsInfo)
            {
                sb.AppendLine($"-AlbumName: {a.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {a.ReleaseDate:MM/dd/yyyy}");
                sb.AppendLine($"-ProducerName: {a.ProducerName}");
                sb.AppendLine($"-Songs:");
                int i = 1;
                foreach (var s in a.Songs)
                {
                    sb.AppendLine($"---#{i}");
                    i++;
                    sb.AppendLine($"---SongName: {s.SongName}");
                    sb.AppendLine($"---Price: {s.Price:f2}");
                    sb.AppendLine($"---Writer: {s.Writer}");
                }
                sb.AppendLine($"-AlbumPrice: {a.AlbumPrice:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var allSongs = context.Songs.ToList().Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new
                {
                    SongName = x.Name,
                    Writer = x.Writer.Name,
                    PerformerFullName = x.SongPerformers.Select(x => x.Performer.FirstName + " " + x.Performer.LastName).FirstOrDefault(),
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration
                }).OrderBy(x=>x.SongName).ThenBy(x=>x.Writer).ThenBy(x=>x.PerformerFullName).ToList();
            var sb = new StringBuilder();
            int i = 1;
            foreach (var s in allSongs)
            {
                sb.AppendLine($"-Song #{i}");
                i++;
                sb.AppendLine($"---SongName: {s.SongName}")
                    .AppendLine($"---Writer: {s.Writer}")
                    .AppendLine($"---Performer: {s.PerformerFullName}")
                    .AppendLine($"---AlbumProducer: {s.AlbumProducer}")
                    .AppendLine($"---Duration: {s.Duration:c}");                    
            }
            return sb.ToString().TrimEnd();
        }
    }
}
