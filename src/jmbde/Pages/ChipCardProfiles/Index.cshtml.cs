using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.ChipCardProfiles
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<ChipCardProfile> ChipCardProfile { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var profiles = from p in _context.ChipCardProfile
                        select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                profiles = profiles.Where(cp => cp.Number.Contains(searchString));
            }
            ChipCardProfile = await profiles.ToListAsync();
        }
    }
}
