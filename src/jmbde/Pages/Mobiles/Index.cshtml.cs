using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Mobiles
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<Mobile> Mobile { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var mobiles = from m in _context.Mobile
                    select m;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                mobiles = mobiles.Where(mob => mob.Number.Contains(searchString));
            }

            Mobile = await mobiles.ToListAsync();
        }
    }
}
