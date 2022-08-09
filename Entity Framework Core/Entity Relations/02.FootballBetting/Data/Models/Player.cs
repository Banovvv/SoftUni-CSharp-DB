using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Player
    {
        public Player()
        {

        }

        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int SquadNumber { get; set; }
        public bool IsInjured { get; set; }


        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
    }
}
