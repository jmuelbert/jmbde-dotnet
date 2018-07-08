using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Functions
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string PrioritySort { get; set; }
        public string LastUpdateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Function> Function { get;set; }

        public async Task OnGetAsync(string sortOrder, 
                string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            PrioritySort = sortOrder == "Priority" ? "priority_desc" : "Priority";
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

            IQueryable<Function> functionIQ = from f in _context.Function
                        select f;

            if (!String.IsNullOrEmpty(searchString))
            {
                functionIQ = functionIQ.Where(fun => fun.Name.Contains(searchString));
            }
           switch (sortOrder)
           {
                case "name_desc":
                    functionIQ = functionIQ.OrderByDescending(f => f.Name);
                    break;

                case "Priority":
                    functionIQ = functionIQ.OrderBy(f => f.Priority);
                    break;

                case "priority_desc":
                    functionIQ = functionIQ.OrderByDescending(f => f.Priority);
                    break;

                case "LastUpdate":
                    functionIQ = functionIQ.OrderBy(f => f.LastUpdate);
                    break;

                case "lastupdate_desc":
                    functionIQ = functionIQ.OrderByDescending(f => f.LastUpdate);
                    break;

                default:
                    functionIQ = functionIQ.OrderBy(f => f.Name);
                    break;
           }

           int pageSize = 10;
           Function = await PaginatedList<Function>.CreateAsync(
               functionIQ.AsNoTracking(), pageIndex ?? 1, pageSize
           );
        }
    }
}
