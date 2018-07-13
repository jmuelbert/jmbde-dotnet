using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.SystemAccounts
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public string UserNameSort { get; set; }
        public string LastUpdateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<SystemAccount> SystemAccount { get;set; }

          public async Task OnGetAsync(string sortOrder, 
                string currentFilter, string searchString, int? pageIndex)
            {
            CurrentSort = sortOrder;
            UserNameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
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

            IQueryable<SystemAccount> systemaccountIQ = from s in _context.SystemAccount
                    select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                systemaccountIQ = systemaccountIQ.Where(sys => sys.UserName.Contains(searchString));
            }

          switch (sortOrder)
           {
                case "name_desc":
                    systemaccountIQ = systemaccountIQ.OrderByDescending(s => s.UserName);
                    break;

                case "LastUpdate":
                    systemaccountIQ = systemaccountIQ.OrderBy(s => s.LastUpdate);
                    break;
                case "lastupdate_desc":
                    systemaccountIQ = systemaccountIQ.OrderByDescending(s => s.LastUpdate);
                    break;

                default:
                    systemaccountIQ = systemaccountIQ.OrderBy(s => s.UserName);
                    break;
           }

            int pageSize = 10;
            SystemAccount = await PaginatedList<SystemAccount>.CreateAsync(
                systemaccountIQ.AsNoTracking(), pageIndex ?? 1, pageSize
            );
        }
    }
}
