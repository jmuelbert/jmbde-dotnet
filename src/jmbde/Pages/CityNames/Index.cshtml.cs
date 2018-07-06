using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.CityNames
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<CityName> CityName { get;set; }

        public async Task OnGetAsync(string sortOrder,
             string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<CityName> cityNameIQ = from c in _context.CityName
                                    select c;

            
            if (!String.IsNullOrEmpty(searchString))
            {
                cityNameIQ = cityNameIQ.Where(cn => cn.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    cityNameIQ = cityNameIQ.OrderByDescending(c => c.Name);
                    break;
                
                case "Date":
                    cityNameIQ = cityNameIQ.OrderBy(c => c.LastUpdate);
                    break;

                case "date_desc":
                    cityNameIQ = cityNameIQ.OrderByDescending(c => c.LastUpdate);
                    break;

                default:
                    cityNameIQ = cityNameIQ.OrderBy(c => c.Name);
                    break;
            }

            int pageSize = 10;
            CityName = await PaginatedList<CityName>.CreateAsync(
                cityNameIQ.AsNoTracking(), pageIndex ?? 1, pageSize
            );
        }
    }
}
