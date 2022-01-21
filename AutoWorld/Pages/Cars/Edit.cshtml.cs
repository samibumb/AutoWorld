#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoWorld.Data;
using AutoWorld.Models;
using AutoWorld.Models;

namespace AutoWorld.Pages.Cars
{
    public class EditModel : CarCategoriesPageModel
    {
        private readonly AutoWorld.Data.AutoWorldContext _context;

        public EditModel(AutoWorld.Data.AutoWorldContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car
             .Include(b => b.DealerAuto)
             .Include(b => b.CarCategories).ThenInclude(b => b.Category)
             .AsNoTracking()
             .FirstOrDefaultAsync(m => m.ID == id);
            if (Car == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Car);

            ViewData["DealerID"] = new SelectList(_context.Set<DealerAuto>(), "ID", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var carToUpdate = await _context.Car
            .Include(i => i.DealerAuto)
            .Include(i => i.CarCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (carToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Car>(
            carToUpdate,
            "Car",
            i => i.brand, i => i.model,
            i => i.price, i => i.year, i => i.DealerAuto))
            {
                UpdateCarCategories(_context, selectedCategories, carToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateCarCategories(_context, selectedCategories, carToUpdate);
            PopulateAssignedCategoryData(_context, carToUpdate);
            return Page();
        }
    }
}

