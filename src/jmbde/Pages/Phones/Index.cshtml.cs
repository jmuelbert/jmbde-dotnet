using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Phones
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
        public PaginatedList<Phone> Phone { get;set; }

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

            IQueryable<Phone> phoneIQ = from p in _context.Phone
                            select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                phoneIQ = phoneIQ.Where(ph => ph.Number.Contains(searchString));
            }

         switch (sortOrder)
           {
                case "number_desc":
                    phoneIQ = phoneIQ.OrderByDescending(f => f.Number);
                    break;

                case "Active":
                    phoneIQ = phoneIQ.OrderBy(f => f.Active);
                    break;

                case "active_desc":
                    phoneIQ = phoneIQ.OrderByDescending(f => f.Active);
                    break;

                case "Replace":
                    phoneIQ = phoneIQ.OrderBy(f => f.Replace);
                    break;

                case "replace_desc":
                    phoneIQ = phoneIQ.OrderByDescending(f => f.Replace);
                    break;
                    
                case "LastUpdate":
                    phoneIQ = phoneIQ.OrderBy(f => f.LastUpdate);
                    break;
                case "lastupdate_desc":
                    phoneIQ = phoneIQ.OrderByDescending(f => f.LastUpdate);
                    break;

                default:
                    phoneIQ = phoneIQ.OrderBy(d => d.Number);
                    break;
           }

           int pageSize = 10;
           Phone = await PaginatedList<Phone>.CreateAsync(
               phoneIQ.AsNoTracking(), pageIndex ?? 1, pageSize
           );
        }
    }
}
