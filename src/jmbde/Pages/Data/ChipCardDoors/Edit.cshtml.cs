using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.ChipCardDoors
{
    public class EditModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public EditModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ChipCardDoor ChipCardDoor { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChipCardDoor = await _context.ChipCardDoor.SingleOrDefaultAsync(m => m.ChipCardDoorId == id);

            if (ChipCardDoor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ChipCardDoor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChipCardDoorExists(ChipCardDoor.ChipCardDoorId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ChipCardDoorExists(long id)
        {
            return _context.ChipCardDoor.Any(e => e.ChipCardDoorId == id);
        }
    }
}
