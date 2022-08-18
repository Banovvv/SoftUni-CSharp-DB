using System.Collections.Generic;

namespace CarDealer.Models
{
    public class Car
    {
        public Car()
        {
            CarParts = new HashSet<PartCar>();
        }

        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int TravelledDistance { get; set; }

        public virtual ICollection<PartCar> CarParts { get; set; }
    }
}