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
        public string NumberSort { get; set; }
        public string ActiveSort { get; set; }
        public string ReplaceSort { get; set; }
        public string LastUpdateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Mobile> Mobile { get;set; }

            public async Task OnGetAsync(string sortOrder, 
                string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NumberSort = String.IsNullOrEmpty(sortOrder) ? "number_desc" : "";
            ActiveSort = sortOrder == "Active" ? "active_desc" : "Active";
            ReplaceSort = sortOrder == "Replace" ? "replace_desc" : "Replace";
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

            IQueryable<Mobile> mobileIQ = from m in _context.Mobile
                    select m;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                mobileIQ = mobileIQ.Where(mob => mob.Number.Contains(searchString));
            }

          switch (sortOrder)
           {
                case "number_desc":
                    mobileIQ = mobileIQ.OrderByDescending(f => f.Number);
                    break;

                case "Active":
                    mobileIQ = mobileIQ.OrderBy(f => f.Active);
                    break;

                case "active_desc":
                    mobileIQ = mobileIQ.OrderByDescending(f => f.Active);
                    break;

                case "Replace":
                    mobileIQ = mobileIQ.OrderBy(f => f.Replace);
                    break;

                case "replace_desc":
                    mobileIQ = mobileIQ.OrderByDescending(f => f.Replace);
                    break;
                    
                case "LastUpdate":
                    mobileIQ = mobileIQ.OrderBy(f => f.LastUpdate);
                    break;
                case "lastupdate_desc":
                    mobileIQ = mobileIQ.OrderByDescending(f => f.LastUpdate);
                    break;

                default:
                    mobileIQ = mobileIQ.OrderBy(d => d.Number);
                    break;
           }

           int pageSize = 10;
           Mobile = await PaginatedList<Mobile>.CreateAsync(
               mobileIQ.AsNoTracking(), pageIndex ?? 1, pageSize
           );
        }
    }
}
