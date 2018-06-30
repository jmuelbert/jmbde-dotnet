using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Faxes
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<Fax> Fax { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var faxes = from f in _context.Fax
                    select f;

            if (!String.IsNullOrEmpty(searchString))
            {
                faxes = faxes.Where(fax => fax.Number.Contains(searchString));
            }

            Fax = await faxes.ToListAsync();
        }
    }
}
