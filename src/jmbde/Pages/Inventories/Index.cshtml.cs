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
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<Inventory> Inventory { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var inventories = from i in _context.Inventory
                    select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                inventories = inventories.Where(inv => inv.Identifier.Contains(searchString));
            }

            Inventory = await inventories.ToListAsync();
        }
    }
}
