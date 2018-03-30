using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.ChipCardProfiles
{
    public class DeleteModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public DeleteModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ChipCardProfile ChipCardProfile { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChipCardProfile = await _context.ChipCardProfile.SingleOrDefaultAsync(m => m.ChipCardProfileId == id);

            if (ChipCardProfile == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChipCardProfile = await _context.ChipCardProfile.FindAsync(id);

            if (ChipCardProfile != null)
            {
                _context.ChipCardProfile.Remove(ChipCardProfile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
