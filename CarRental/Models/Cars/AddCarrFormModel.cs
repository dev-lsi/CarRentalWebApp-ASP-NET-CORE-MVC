

namespace CarRental.Models.Cars
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static CarRental.Data.DataConstants.Car;
    public class AddCarrFormModel
    {
        [Required]
        [StringLength(BrandNameMaxLength,MinimumLength = BrandNameMinLength, ErrorMessage = "must be between {2} and {1}")]
        public string Brand { get; set; }

        [Required]
        [StringLength(ModelNameMaxLength,MinimumLength = ModelNameMinLength, ErrorMessage = "must be between {2} and {1}")]
        public string Model { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength,MinimumLength =DescriptionMinLength,ErrorMessage ="must be between {2} and {1}")]
        public string Description { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [Range(CarYearMinValue,CarYearMaxValue)]
        public int Year { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<CarCategoryViewModel> Categories { get; set; }

        
    }
}
