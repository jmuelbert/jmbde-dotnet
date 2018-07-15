using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.ChipCards
{
    public class DetailsModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public DetailsModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public ChipCard ChipCard { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChipCard = await _context.ChipCard
                        .Include(c => c.Employee)
                        .AsNoTracking()           
                        .FirstOrDefaultAsync(m => m.ChipCardId == id);

            if (ChipCard == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
