using System.Collections.Generic;

namespace P03_FootballBetting.Data.Models
{
    public class Player
    {
        public Player()
        {
            PlayerStatistics = new HashSet<Game>();
        }

        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int SquadNumber { get; set; }
        public int TeamId { get; set; }
        public int PositionId { get; set; }
        public bool IsInjured { get; set; }

        public Team Team { get; set; }
        public Position Position { get; set; }

        public ICollection<Game> PlayerStatistics { get; set; }
    }
}
