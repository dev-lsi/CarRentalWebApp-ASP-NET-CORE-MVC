using CarRental.Data;
using CarRental.Data.Models;
using CarRental.Models.Cars;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using FileSystem=System.IO.File;

namespace CarRental.Controllers
{
    public class CarsController:Controller
    {
        public readonly CarRentalDbContext data;

        public CarsController(CarRentalDbContext data)
            =>this.data = data;

        public IActionResult All([FromQuery]CarQueryModel query)
        {
            var carsQuery = this.data.Cars.AsQueryable();
            
            if (!string.IsNullOrEmpty(query.Brand))
            {
                carsQuery = carsQuery
                    .Where(x => x.Brand == query.Brand);
                    
            }


            if (!string.IsNullOrEmpty(query.SearchTerm))
            {
                carsQuery = carsQuery.Where(x =>
                x.Brand.ToLower().Contains(query.SearchTerm.ToLower())||
                x.Model.ToLower().Contains(query.SearchTerm.ToLower())||
                x.Description.ToLower().Contains(query.SearchTerm.ToLower())
                );
            }

            carsQuery = query.Sorting switch
            {
                CarSorting.DateCreated => carsQuery.OrderByDescending(x => x.Id),
                CarSorting.BrandModel => carsQuery.OrderByDescending(x => x.Brand),
                CarSorting.Year or _ => carsQuery.OrderByDescending(x => x.Year),

            };

            var cars = carsQuery
                .Skip((query.CurrentPage - 1) * CarQueryModel.CarsPerPage)
                .Take(CarQueryModel.CarsPerPage)
                //.OrderByDescending(x => x.Id)
                .Select(x=> new CarListingViewModel
                {
                Id= x.Id,
                Brand=x.Brand,
                Model=x.Model,
                ImgUrl=x.ImageUrl,
                Category=x.Category.Name,
                Year=x.Year,
                })
                .ToList();

            

            var carBrands=this.data
                .Cars
                .Select(c=>c.Brand)
                .Distinct()
                .OrderBy(c=>c)
                .ToList();
            
            

            query.Brands= carBrands;
            query.Cars = cars;

            

            return View(query);
        }

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

            //if (!ModelState.IsValid)
            //{
            //    car.Categories = this.GetCarCategories();
            //    return View(car);
            //}

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

            return RedirectToAction(nameof(All));
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
