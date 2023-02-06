using CarRental.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models.Cars
{
    public class AddCarrFormModel
    {
        public string Model { get; set; }

        public string Brand { get; set; }

        public string Description { get; set; }
       
        public string ImageUrl { get; set; }
       
        public int Year { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<CarCategoryViewModel> Categories { get; set; }

        
    }
}
