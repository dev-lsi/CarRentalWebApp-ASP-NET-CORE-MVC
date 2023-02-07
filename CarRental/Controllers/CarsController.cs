using CarRental.Data;
using CarRental.Data.Models;
using CarRental.Models.Cars;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Controllers
{
    public class CarsController:Controller
    {
        public readonly CarRentalDbContext data;

        public CarsController(CarRentalDbContext data)
            =>this.data = data;

        public IActionResult Add() => View(new AddCarrFormModel
        {
            Categories = this.GetCarCategories()
        });

        [HttpPost]
        public IActionResult Add(AddCarrFormModel car, IFormFile image)
        {
            if (this.data.Categories.Any(c=>c.Id==car.CategoryId))
            {
                this.ModelState.AddModelError(nameof(car.CategoryId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                car.Categories = this.GetCarCategories();
                return View(car);
            }

            var carData = new Car
            {
                Brand = car.Brand,
                Model = car.Model,
                Description = car.Description,
                ImageUrl = car.ImageUrl,
                Year = car.Year,
                CategoryId = car.CategoryId
            };

            this.data.Cars.Add(carData);
            this.data.SaveChanges();
          
            return RedirectToAction("Index","Home");
        }

        private IEnumerable<CarCategoryViewModel> GetCarCategories()
            => this.data
            .Categories
            .Select(c => new CarCategoryViewModel
            {

                Id = c.Id,
                Name = c.Name,
            })
            .ToList();


    }
}
