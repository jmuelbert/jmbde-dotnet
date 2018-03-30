using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Softwares
{
    public class DetailsModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public DetailsModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public Software Software { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Software = await _context.Software.SingleOrDefaultAsync(m => m.SoftwareId == id);

            if (Software == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
