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

namespace AutoWorld.Pages.Dealers
{
    public class DeleteModel : PageModel
    {
        private readonly AutoWorld.Data.AutoWorldContext _context;

        public DeleteModel(AutoWorld.Data.AutoWorldContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DealerAuto DealerAuto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DealerAuto = await _context.DealerAuto.FirstOrDefaultAsync(m => m.ID == id);

            if (DealerAuto == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DealerAuto = await _context.DealerAuto.FindAsync(id);

            if (DealerAuto != null)
            {
                _context.DealerAuto.Remove(DealerAuto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
