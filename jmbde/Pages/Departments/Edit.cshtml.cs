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

namespace jmbde.Pages.Departments
{
    public class EditModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public EditModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = await _context.Department.SingleOrDefaultAsync(m => m.DepartmentId == id);

            if (Department == null)
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

            _context.Attach(Department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(Department.DepartmentId))
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

        private bool DepartmentExists(long id)
        {
            return _context.Department.Any(e => e.DepartmentId == id);
        }
    }
}
