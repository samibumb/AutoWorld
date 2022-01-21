#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoWorld.Data;
using AutoWorld.Models;

namespace AutoWorld.Pages.Cars
{
    public class CreateModel : CarCategoriesPageModel
    {
        private readonly AutoWorld.Data.AutoWorldContext _context;

        public CreateModel(AutoWorld.Data.AutoWorldContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DealerID"] = new SelectList(_context.Set<DealerAuto>(), "ID", "Name");
            
            var car = new Car();
            car.CarCategories = new List<CarCategory>();
            PopulateAssignedCategoryData(_context, car);

            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newCar = new Car();
            if (selectedCategories != null)
            {
                newCar.CarCategories = new List<CarCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CarCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newCar.CarCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Car>(
            newCar,
            "Car",
            i => i.brand, i => i.model,
            i => i.price, i=>i.fuel, i => i.year, i => i.DealerID))
            {
                _context.Car.Add(newCar);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newCar);
            return Page();
        }
    }
}
