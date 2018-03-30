using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Documents
{
    public class DeleteModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public DeleteModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Document Document { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Document = await _context.Document.SingleOrDefaultAsync(m => m.DocumentId == id);

            if (Document == null)
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

            Document = await _context.Document.FindAsync(id);

            if (Document != null)
            {
                _context.Document.Remove(Document);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
