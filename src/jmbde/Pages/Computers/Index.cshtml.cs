using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Computers
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string ActiveSort { get; set; }
        public string ReplaceSort { get; set; }
        public string LastUpdateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Computer> Computer { get;set; }

        public async Task OnGetAsync(string sortOrder, 
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ActiveSort = sortOrder == "Active" ? "active_desc" : "Active";
            ReplaceSort = sortOrder == "Replace" ? "replace_desc" : "Replace";
            LastUpdateSort = sortOrder == "LastUpdate" ? "lastupdate_sort" : "LastUpdate";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Computer> computerIQ = from c in _context.Computer
                            select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                computerIQ = computerIQ.Where(comp => comp.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    computerIQ = computerIQ.OrderByDescending(c => c.Name);
                    break;

               case "Active":
                    computerIQ = computerIQ.OrderBy(c => c.Active);
                    break;

               case "active_desc":
                    computerIQ = computerIQ.OrderByDescending(c => c.Active);
                    break;

               case "Replace":
                    computerIQ = computerIQ.OrderBy(c => c.Replace);
                    break;

               case "replace_desc":
                    computerIQ = computerIQ.OrderByDescending(c => c.Replace);
                    break;

               case "LastUpdate":
                    computerIQ = computerIQ.OrderBy(c => c.LastUpdate);
                    break;

               case "lastupdate_desc":
                    computerIQ = computerIQ.OrderByDescending(c => c.LastUpdate);
                    break;

                default:
                    computerIQ = computerIQ.OrderBy(c => c.Name);
                    break;
            }

            int pageSize = 10;
            Computer = await PaginatedList<Computer>.CreateAsync(
                computerIQ.AsNoTracking(), pageIndex ?? 1, pageSize
            );
        }
    }
}
