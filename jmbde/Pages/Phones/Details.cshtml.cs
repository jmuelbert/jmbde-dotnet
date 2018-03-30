using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Phones
{
    public class DetailsModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public DetailsModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public Phone Phone { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Phone = await _context.Phone.SingleOrDefaultAsync(m => m.PhoneId == id);

            if (Phone == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
