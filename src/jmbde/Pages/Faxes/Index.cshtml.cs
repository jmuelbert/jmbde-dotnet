using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Faxes
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
        public PaginatedList<Fax> Fax { get;set; }

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

            IQueryable<Fax> faxIQ = from f in _context.Fax
                    select f;

            if (!String.IsNullOrEmpty(searchString))
            {
                faxIQ = faxIQ.Where(fax => fax.Number.Contains(searchString));
            }

           switch (sortOrder)
           {
                case "number_desc":
                    faxIQ = faxIQ.OrderByDescending(f => f.Number);
                    break;

                case "Active":
                    faxIQ = faxIQ.OrderBy(f => f.Active);
                    break;

                case "active_desc":
                    faxIQ = faxIQ.OrderByDescending(f => f.Active);
                    break;

                case "Replace":
                    faxIQ = faxIQ.OrderBy(f => f.Replace);
                    break;

                case "replace_desc":
                    faxIQ = faxIQ.OrderByDescending(f => f.Replace);
                    break;
                    
                case "LastUpdate":
                    faxIQ = faxIQ.OrderBy(f => f.LastUpdate);
                    break;
                case "lastupdate_desc":
                    faxIQ = faxIQ.OrderByDescending(f => f.LastUpdate);
                    break;

                default:
                    faxIQ = faxIQ.OrderBy(d => d.Number);
                    break;
           }

           int pageSize = 10;
           Fax = await PaginatedList<Fax>.CreateAsync(
               faxIQ.AsNoTracking(), pageIndex ?? 1, pageSize
           );
        }
    }
}
