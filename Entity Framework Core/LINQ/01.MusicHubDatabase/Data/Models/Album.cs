using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price => Songs.Sum(x => x.Price);

        public virtual ICollection<Song> Songs { get; set; }
    }
}
