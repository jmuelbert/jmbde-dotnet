using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.JobTitles
{
    public class DeleteModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public DeleteModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JobTitle JobTitle { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobTitle = await _context.JobTitle.SingleOrDefaultAsync(m => m.JobTitleId == id);

            if (JobTitle == null)
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

            JobTitle = await _context.JobTitle.FindAsync(id);

            if (JobTitle != null)
            {
                _context.JobTitle.Remove(JobTitle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
