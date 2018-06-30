using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Functions
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<Function> Function { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var functions = from f in _context.Function
                    select f;

            if (!String.IsNullOrEmpty(searchString))
            {
                functions = functions.Where(fun => fun.Name.Contains(searchString));
            }

            Function = await functions.ToListAsync();
        }
    }
}
