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
    public class IndexModel : PageModel
    {
        private readonly AutoWorld.Data.AutoWorldContext _context;

        public IndexModel(AutoWorld.Data.AutoWorldContext context)
        {
            _context = context;
        }

        public IList<DealerAuto> DealerAuto { get;set; }

        public async Task OnGetAsync()
        {
            DealerAuto = await _context.DealerAuto.ToListAsync();
        }
    }
}
