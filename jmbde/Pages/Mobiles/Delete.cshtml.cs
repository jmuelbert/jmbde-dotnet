using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Mobiles
{
    public class DeleteModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public DeleteModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mobile Mobile { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mobile = await _context.Mobile.SingleOrDefaultAsync(m => m.MobileId == id);

            if (Mobile == null)
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

            Mobile = await _context.Mobile.FindAsync(id);

            if (Mobile != null)
            {
                _context.Mobile.Remove(Mobile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
