using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Companies
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string Name2Sort { get; set; }
        public string ActiveSort { get; set; }
        public string LastUpdateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Company> Company { get;set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            Name2Sort = sortOrder == "Name2" ? "name2_desc" : "Name2";
            ActiveSort = sortOrder == "Active" ? "active_desc" : "Active";
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

            IQueryable<Company> companyIQ = from c in _context.Company
                                select c;

                        
            if (!String.IsNullOrEmpty(searchString))
            {
                companyIQ = companyIQ.Where(com => com.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    companyIQ = companyIQ.OrderByDescending(c => c.Name);
                    break;  

                case "Name2":
                    companyIQ = companyIQ.OrderBy(c => c.Name2);
                    break;  
                case "name2_desc":
                    companyIQ = companyIQ.OrderByDescending(c => c.Name2);
                    break;  

                case "Active":
                    companyIQ = companyIQ.OrderBy(c => c.Active);
                    break;  

                case "active_desc":
                    companyIQ = companyIQ.OrderByDescending(c => c.Active);
                    break;  

                case "LastUpdate":
                    companyIQ = companyIQ.OrderBy(c => c.LastUpdate);
                    break;  

                case "lastupdate_desc":
                    companyIQ = companyIQ.OrderByDescending(c => c.LastUpdate);
                    break;                      

                default:
                    companyIQ = companyIQ.OrderBy(c => c.Name);
                    break;
            }

            int pageSize = 10;
            Company = await PaginatedList<Company>.CreateAsync(
                companyIQ.AsNoTracking(), pageIndex ?? 1, pageSize
            );
        }
    }
}
