using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Inventories
{
    public class DetailsModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public DetailsModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public Inventory Inventory { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Inventory = await _context.Inventory.SingleOrDefaultAsync(m => m.InventoryId == id);

            if (Inventory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
