using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Printers
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<Printer> Printer { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var printers = from p in _context.Printer
                    select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                printers = printers.Where(pr => pr.Name.Contains(searchString));
            }

            Printer = await printers.ToListAsync();
        }
    }
}
