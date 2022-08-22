using System.Collections.Generic;

namespace CarsDealer.Models
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
        public long TravelledDistance { get; set; }

        public ICollection<Sale> Sales { get; set; }
        public virtual ICollection<PartCar> CarParts { get; set; }
    }
}
