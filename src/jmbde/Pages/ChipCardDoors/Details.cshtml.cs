using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.ChipCardDoors
{
    public class DetailsModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public DetailsModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public ChipCardDoor ChipCardDoor { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ChipCardDoor = await _context.ChipCardDoor
                        .Include(c => c.Employee)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.ChipCardDoorId == id);

            if (ChipCardDoor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
