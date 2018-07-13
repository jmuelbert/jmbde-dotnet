using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.SystemDatas
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

        public PaginatedList<SystemData> SystemData { get;set; }

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

            IQueryable<SystemData> systemdataIQ = from s in _context.SystemData
                    select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                systemdataIQ = systemdataIQ.Where(sys => sys.Name.Contains(searchString));
            } 
          switch (sortOrder)
           {
                case "name_desc":
                    systemdataIQ = systemdataIQ.OrderByDescending(p => p.Name);
                    break;

                case "LastUpdate":
                    systemdataIQ = systemdataIQ.OrderBy(p => p.LastUpdate);
                    break;
                case "lastupdate_desc":
                    systemdataIQ = systemdataIQ.OrderByDescending(p => p.LastUpdate);
                    break;

                default:
                    systemdataIQ = systemdataIQ.OrderBy(p => p.Name);
                    break;
           }

            int pageSize = 10;
            SystemData = await PaginatedList<SystemData>.CreateAsync(
                systemdataIQ.AsNoTracking(), pageIndex ?? 1, pageSize
            );
        }
    }
}
