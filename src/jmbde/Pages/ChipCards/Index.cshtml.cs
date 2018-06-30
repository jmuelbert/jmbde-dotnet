using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.ChipCards
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<ChipCard> ChipCard { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var chipcards = from c in _context.ChipCard
                    select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                chipcards = chipcards.Where(cc => cc.Number.Contains(searchString));
            }

            ChipCard = await chipcards.ToListAsync();
        }
    }
}
