using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Manufacturers
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string SupportSort { get; set; }
        public string LastUpdateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Manufacturer> Manufacturer { get;set; }

        public async Task OnGetAsync(string sortOrder, 
                string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            SupportSort = sortOrder == "Supporter" ? "supporter_desc" : "Supporter";
            LastUpdateSort = sortOrder == "LastUpdate" ? "lastupdate_desc" : "LastUpdate";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Manufacturer> manufacturerIQ = from m in _context.Manufacturer
                    select m;
                    
            if (!String.IsNullOrEmpty(searchString))
            {
                manufacturerIQ = manufacturerIQ.Where(man => man.Name.Contains(searchString));
            }

           switch (sortOrder)
           {
                case "name_desc":
                    manufacturerIQ = manufacturerIQ.OrderByDescending(d => d.Name);
                    break;

                case "Supporter":
                    manufacturerIQ = manufacturerIQ.OrderBy(m => m.Supporter);
                    break;

                case "supporter_desc":
                    manufacturerIQ = manufacturerIQ.OrderByDescending(m => m.Supporter);
                    break;                
                    
                case "LastUpdate":
                    manufacturerIQ = manufacturerIQ.OrderBy(d => d.LastUpdate);
                    break;
                    
                case "lastupdate_desc":
                    manufacturerIQ = manufacturerIQ.OrderByDescending(d => d.LastUpdate);
                    break;

                default:
                    manufacturerIQ = manufacturerIQ.OrderBy(d => d.Name);
                    break;
           }

           int pageSize = 10;
           Manufacturer = await PaginatedList<Manufacturer>.CreateAsync(
               manufacturerIQ.AsNoTracking(), pageIndex ?? 1, pageSize
           );
           
        }
    }
}
