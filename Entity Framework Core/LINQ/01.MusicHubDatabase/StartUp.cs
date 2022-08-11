using MusicHub.Data;
using MusicHub.Initializer;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MusicHub
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (MusicHubDbContext context = new MusicHubDbContext())
            {
                DbInitializer.ResetDatabase(context);

                Console.WriteLine(ExportAlbumsInfo(context, 9));

                Console.WriteLine(ExportSongsAboveDuration(context, 4));
            }
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .ToList()
                .Where(x => x.ProducerId == producerId)
                .Select(x => new
                {
                    Name = x.Name,
                    ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = x.Producer.Name,
                    AlmumSongs = x.Songs
                        .Select(s => new
                        {
                            Name = s.Name,
                            Price = s.Price,
                            WriterName = s.Writer.Name
                        })
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.WriterName)
                        .ToList(),
                    TotalPrice = x.Price

                })
                .OrderByDescending(x => x.TotalPrice)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");

                int songCounter = 1;

                foreach (var song in album.AlmumSongs)
                {
                    sb.AppendLine($"---#{songCounter}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:F2}");
                    sb.AppendLine($"---Price: {song.WriterName}");
                    songCounter++;
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalPrice:F2}");
            }

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            TimeSpan tsDuration = TimeSpan.FromMinutes(duration);

            var songs = context.Songs
                .Where(s => s.Duration > tsDuration)
                .Select(s => new
                {
                    Name = s.Name,
                    Performer = s.SongPerformers.FirstOrDefault().Performer.FirstName + " " + s.SongPerformers.FirstOrDefault().Performer.LastName,
                    Writer = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.AlbumProducer)
                .ToList();

            StringBuilder sb = new StringBuilder();

            int i = 1;

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{i}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.Writer}");
                sb.AppendLine($"---Performer: {song.Performer}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration}");

                i++;
            }

            return sb.ToString().Trim();
        }
    }
}