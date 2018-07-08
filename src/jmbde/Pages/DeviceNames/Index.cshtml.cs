using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.DeviceNames
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

        public PaginatedList<DeviceName> DeviceName { get;set; }

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

            IQueryable<DeviceName> deviceNameIQ = from d in _context.DeviceName
                        select d;
        
            if (!String.IsNullOrEmpty(searchString))
            {
                deviceNameIQ = deviceNameIQ.Where(dn => dn.Name.Contains(searchString));
            }

           switch (sortOrder)
           {
                case "name_desc":
                    deviceNameIQ = deviceNameIQ.OrderByDescending(d => d.Name);
                    break;

                case "LastUpdate":
                    deviceNameIQ = deviceNameIQ.OrderBy(d => d.LastUpdate);
                    break;
                case "lastupdate_desc":
                    deviceNameIQ = deviceNameIQ.OrderByDescending(d => d.LastUpdate);
                    break;

                default:
                    deviceNameIQ = deviceNameIQ.OrderBy(d => d.Name);
                    break;
           }

           int pageSize = 10;
           DeviceName = await PaginatedList<DeviceName>.CreateAsync(
               deviceNameIQ.AsNoTracking(), pageIndex ?? 1, pageSize
           );
        }
    }
}
