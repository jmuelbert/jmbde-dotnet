using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.DeviceTypes
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string LastUpdateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<DeviceType> DeviceType { get;set; }

        public async Task OnGetAsync(string sortOrder, 
                string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
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

            IQueryable<DeviceType> deviceTypeIQ = from d in _context.DeviceType
                    select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                deviceTypeIQ = deviceTypeIQ.Where(dt => dt.Name.Contains(searchString));
            }
       switch (sortOrder)
           {
                case "name_desc":
                    deviceTypeIQ = deviceTypeIQ.OrderByDescending(d => d.Name);
                    break;

                case "LastUpdate":
                    deviceTypeIQ = deviceTypeIQ.OrderBy(d => d.LastUpdate);
                    break;
                case "lastupdate_desc":
                    deviceTypeIQ = deviceTypeIQ.OrderByDescending(d => d.LastUpdate);
                    break;

                default:
                    deviceTypeIQ = deviceTypeIQ.OrderBy(d => d.Name);
                    break;
           }

           int pageSize = 10;
           DeviceType = await PaginatedList<DeviceType>.CreateAsync(
               deviceTypeIQ.AsNoTracking(), pageIndex ?? 1, pageSize
           );
        
        }
    }
}
