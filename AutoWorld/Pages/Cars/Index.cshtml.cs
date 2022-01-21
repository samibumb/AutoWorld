#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoWorld.Data;
using AutoWorld.Models;

namespace AutoWorld.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly AutoWorld.Data.AutoWorldContext _context;

        public IndexModel(AutoWorld.Data.AutoWorldContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get; set; }
        public CarData CarD { get; set; }
        public int CarID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            CarD = new CarData();

            CarD.Cars = await _context.Car
           .Include(b => b.DealerAuto)
 .Include(b => b.CarCategories)
 .ThenInclude(b => b.Category)
 .AsNoTracking()
 .OrderBy(b => b.brand)
 .ToListAsync();
            if (id != null)
            {
                CarID = id.Value;
                Car book = CarD.Cars
                .Where(i => i.ID == id.Value).Single();
                CarD.Categories = book.CarCategories.Select(s => s.Category);
            }
        }
    }
}
    
