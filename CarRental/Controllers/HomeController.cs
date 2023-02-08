


namespace CarRental.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using CarRental.Models;
    using CarRental.Data;
    using System.Linq;
    using CarRental.Models.Cars;
    using CarRental.Models.Home;

    public class HomeController : Controller
    {
        private readonly CarRentalDbContext data;

        public HomeController(CarRentalDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            var totalCars=this.data.Cars.Count();
            //var TotalUsers=this.data.Users.Count();
            //var TotalRents=this.data.Rents.Count();

            var cars = this.data
                .Cars
                .OrderByDescending(x => x.Id)
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    ImgUrl = x.ImageUrl,
                    
                    Year = x.Year,
                })
                .Take(3)
                .ToList();

            return View(new IndexViewModel
            {
                TotalCars = totalCars,
                Cars = cars
            }) ;

             
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
