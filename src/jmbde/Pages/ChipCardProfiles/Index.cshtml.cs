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

        public string NumberSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }   
        public PaginatedList<ChipCardProfile> ChipCardProfile { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NumberSort  = String.IsNullOrEmpty(sortOrder) ? "number_desc" : "";
            DateSort    = sortOrder == "Date" ? "date_desc" : "Date";
            CurrentFilter = searchString;

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<ChipCardProfile> chipCardProfileIQ = from c in _context.ChipCardProfile
                            select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                chipCardProfileIQ = chipCardProfileIQ.Where(cp => cp.Number.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "number_desc":
                    chipCardProfileIQ = chipCardProfileIQ.OrderByDescending(cp => cp.Number);
                    break;
                case "Date":
                    chipCardProfileIQ = chipCardProfileIQ.OrderBy(cp => cp.LastUpdate);
                    break;
                case "date_desc":
                    chipCardProfileIQ = chipCardProfileIQ.OrderByDescending(cp => cp.LastUpdate);
                    break;
                default:
                    chipCardProfileIQ = chipCardProfileIQ.OrderBy(cp => cp.Number);
                    break;
            }

            int pageSize = 3;
            ChipCardProfile = await PaginatedList<ChipCardProfile>.CreateAsync(
                chipCardProfileIQ.AsNoTracking(), pageIndex ?? 1, pageSize
            );
        }
    }
}
