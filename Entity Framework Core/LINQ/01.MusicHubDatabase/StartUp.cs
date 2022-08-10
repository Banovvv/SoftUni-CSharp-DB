using MusicHub.Data;
using MusicHub.Initializer;
using System;

namespace MusicHub
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (MusicHubDbContext context = new MusicHubDbContext())
            {
                DbInitializer.ResetDatabase(context);

                //Test your solutions here
            }
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            throw new NotImplementedException();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}