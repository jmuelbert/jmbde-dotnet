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

        public string NumberSort { get; set; }
        public string LockedSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }   
        public IList<ChipCard> ChipCard { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NumberSort  = String.IsNullOrEmpty(sortOrder) ? "number_desc" : "";
            LockedSort  = sortOrder == "Locked" ? "locked_desc" : "Locked";
            DateSort    = sortOrder == "Date" ? "date_desc" : "Date";
            CurrentFilter = searchString;

            IQueryable<ChipCard> chipCardIQ = from c in _context.ChipCard
                                    select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                chipCardIQ = chipCardIQ.Where(cc => cc.Number.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "number_desc":
                    chipCardIQ = chipCardIQ.OrderByDescending(c => c.Number);
                    break;
                case "Locked":
                    chipCardIQ = chipCardIQ.OrderBy(c => c.Locked);
                    break;
                case "locked_desc":
                    chipCardIQ = chipCardIQ.OrderByDescending(c => c.Locked);
                    break;
                case "Date":
                    chipCardIQ = chipCardIQ.OrderBy(c => c.LastUpdate);
                    break;
                case "date_desc":
                    chipCardIQ = chipCardIQ.OrderByDescending(c => c.LastUpdate);
                    break;
                default:
                    chipCardIQ = chipCardIQ.OrderBy(c => c.Number);
                    break;
            }

            ChipCard = await chipCardIQ.AsNoTracking().ToListAsync();
        }
    }
}
