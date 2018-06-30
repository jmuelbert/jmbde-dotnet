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
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<Computer> Computer { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var computers = from c in _context.Computer
                    select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                computers = computers.Where(comp => comp.Name.Contains(searchString));
            }

            Computer = await computers.ToListAsync();
        }
    }
}
