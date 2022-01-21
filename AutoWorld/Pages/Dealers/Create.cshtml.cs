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

namespace AutoWorld.Pages.Dealers
{
    public class CreateModel : PageModel
    {
        private readonly AutoWorld.Data.AutoWorldContext _context;

        public CreateModel(AutoWorld.Data.AutoWorldContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DealerAuto DealerAuto { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DealerAuto.Add(DealerAuto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
