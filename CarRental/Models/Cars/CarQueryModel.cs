using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CarRental.Models.Cars
{
    public class CarQueryModel
    {
        public const int CarsPerPage= 2;

        public int CurrentPage { get; set; } =1;
        
        public CarSorting Sorting { get; set; }

        public string Brand { get; set; }

        public IEnumerable<string> Brands { get; set; }
        
        [DisplayName("Search")]
        public string SearchTerm { get; set; }
        
        public IEnumerable<CarListingViewModel> Cars { get; set; }
    }

}
