using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Models;

namespace jmbde.Pages.Processors
{
    public class DetailsModel : PageModel
    {
        private readonly jmbde.Models.JMBDEContext _context;

        public DetailsModel(jmbde.Models.JMBDEContext context)
        {
            _context = context;
        }

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
    }
}
