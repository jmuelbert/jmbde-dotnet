using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.DeviceNames
{
    public class DeleteModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public DeleteModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeviceName DeviceName { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeviceName = await _context.DeviceName.SingleOrDefaultAsync(m => m.DeviceNameId == id);

            if (DeviceName == null)
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

            DeviceName = await _context.DeviceName.FindAsync(id);

            if (DeviceName != null)
            {
                _context.DeviceName.Remove(DeviceName);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
