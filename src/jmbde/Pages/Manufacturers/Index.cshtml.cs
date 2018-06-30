using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Manufacturers
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<Manufacturer> Manufacturer { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var manufacturers = from m in _context.Manufacturer
                    select m;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                manufacturers = manufacturers.Where(man => man.Name.Contains(searchString));
            }

            Manufacturer = await manufacturers.ToListAsync();
        }
    }
}
