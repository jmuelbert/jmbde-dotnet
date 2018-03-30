using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Computers
{
    public class DetailsModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public DetailsModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public Computer Computer { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Computer = await _context.Computer.SingleOrDefaultAsync(m => m.ComputerId == id);

            if (Computer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
