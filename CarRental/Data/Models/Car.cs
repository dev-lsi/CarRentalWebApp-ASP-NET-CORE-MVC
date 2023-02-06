namespace CarRental.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class Car
    { 
        public int Id { get; set; }
        
        [Required]
        [MaxLength(BrandNameMaxLength)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(ModelNameMaxLength)]
        public string Model { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public int Year { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
