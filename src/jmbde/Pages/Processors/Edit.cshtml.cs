using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jmbde.Models;

namespace jmbde.Pages.Processors
{
    public class EditModel : PageModel
    {
        private readonly jmbde.Models.JMBDEContext _context;

        public EditModel(jmbde.Models.JMBDEContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Processor Processor { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Processor = await _context.Processor.FirstOrDefaultAsync(m => m.ProcessorId == id);

            if (Processor == null)
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

            _context.Attach(Processor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcessorExists(Processor.ProcessorId))
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

        private bool ProcessorExists(long id)
        {
            return _context.Processor.Any(e => e.ProcessorId == id);
        }
    }
}
