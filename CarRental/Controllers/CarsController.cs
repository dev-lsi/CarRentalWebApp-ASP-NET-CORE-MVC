using CarRental.Data;
using CarRental.Models.Cars;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Add(AddCarrFormModel car)
        {
            if (!ModelState.IsValid)
            {
                car.Categories = this.GetCarCategories();
                return View(car);
            }
          
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
