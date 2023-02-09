
namespace CarRental.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Dealer;

    public class Dealer
    {
        
        public int Id { get; set; }

        [Required]
        [MaxLength(DealerNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        public string UserId { get; set; }

        public ICollection<Car> Cars { get; set; }=new List<Car>();
    }
}
