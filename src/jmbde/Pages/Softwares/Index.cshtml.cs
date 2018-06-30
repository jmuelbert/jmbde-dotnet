using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Softwares
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<Software> Software { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var softwares = from s in _context.Software
                    select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                softwares = softwares.Where(soft => soft.Name.Contains(searchString));
            }

            Software = await softwares.ToListAsync();
        }
    }
}
