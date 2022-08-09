using MusicHub.Data.Models.Enums;
using System;
using System.Collections.Generic;

namespace MusicHub.Data.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime CreateOn { get; set; }
        public Genre Genre { get; set; }
        public decimal Price { get; set; }

        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        public virtual ICollection<SongPerformer> SongPerformers { get; set; }
    }
}
