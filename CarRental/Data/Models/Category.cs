using System.Collections.Generic;

namespace CarRental.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
