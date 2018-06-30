using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.ZipCodes
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<ZipCode> ZipCode { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var zipcodes = from z in _context.ZipCode
                    select z;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                zipcodes = zipcodes.Where(zip => zip.Code.Contains(searchString));
            }

            ZipCode = await zipcodes.ToListAsync();
        }
    }
}
