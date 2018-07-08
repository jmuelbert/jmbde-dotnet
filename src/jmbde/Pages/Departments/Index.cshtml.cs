using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Departments
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
        public PaginatedList<Department> Department { get;set; }

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

            IQueryable<Department> departmentIQ = from d in _context.Department
                        select d;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                departmentIQ = departmentIQ.Where(dep => dep.Name.Contains(searchString));
            }
            
            switch (sortOrder)
            {
                case "name_desc":
                    departmentIQ = departmentIQ.OrderByDescending(d => d.Name);
                    break;

                case "Priority":
                    departmentIQ = departmentIQ.OrderBy(d => d.Priority);
                    break;

                case "priority_desc":
                    departmentIQ = departmentIQ.OrderByDescending(d => d.Priority);
                    break;

                case "LastUpdate":
                    departmentIQ = departmentIQ.OrderBy(d => d.LastUpdate);
                    break;

                case "lastupdate_desc":
                    departmentIQ = departmentIQ.OrderByDescending(d => d.LastUpdate);
                    break;

                default:
                    departmentIQ = departmentIQ.OrderBy(d => d.Name);
                    break;

            }

            int pageSize = 10;
            Department = await PaginatedList<Department>.CreateAsync(
                departmentIQ.AsNoTracking(), pageIndex ?? 1, pageSize
            );
        }
    }
}
