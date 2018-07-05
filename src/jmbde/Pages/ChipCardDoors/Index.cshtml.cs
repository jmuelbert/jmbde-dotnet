using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.ChipCardDoors
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
        public IList<ChipCardDoor> ChipCardDoor { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NumberSort = String.IsNullOrEmpty(sortOrder) ? "number_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            CurrentFilter = searchString;

            IQueryable<ChipCardDoor> chipCardDoorIQ = from ccd in _context.ChipCardDoor
                                select ccd;

            if (!String.IsNullOrEmpty(searchString))
            {
                chipCardDoorIQ = chipCardDoorIQ.Where(cd => cd.Number.Contains(searchString));
            }

            switch (sortOrder) 
            {
                case "number_desc":
                    chipCardDoorIQ = chipCardDoorIQ.OrderByDescending(c => c.Number);
                    break;
                case "Date":
                    chipCardDoorIQ = chipCardDoorIQ.OrderBy(c => c.LastUpdate);
                    break;
                case "date_desc":  
                    chipCardDoorIQ = chipCardDoorIQ.OrderByDescending(c => c.LastUpdate);
                    break;
                default:
                    chipCardDoorIQ = chipCardDoorIQ.OrderBy(c => c.Number);
                    break;
            }
            ChipCardDoor = await chipCardDoorIQ.AsNoTracking().ToListAsync();
        }
    }
}
