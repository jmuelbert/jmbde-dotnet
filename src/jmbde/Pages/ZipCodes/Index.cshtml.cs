using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.ZipCodes
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public string CodeSort { get; set; }
        public string LastUpdateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<ZipCode> ZipCode { get;set; }

       public async Task OnGetAsync(string sortOrder, 
                string currentFilter, string searchString, int? pageIndex)
            {
            CurrentSort = sortOrder;
            CodeSort = String.IsNullOrEmpty(sortOrder) ? "code_desc" : "";
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

            IQueryable<ZipCode> zipcodeIQ = from z in _context.ZipCode
                    select z;

            if (!String.IsNullOrEmpty(searchString))
            {
                zipcodeIQ = zipcodeIQ.Where(zip => zip.Code.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "code_desc":
                    zipcodeIQ = zipcodeIQ.OrderByDescending(z => z.Code);
                    break;

                case "LastUpdate":
                    zipcodeIQ = zipcodeIQ.OrderBy(z => z.LastUpdate);
                    break;
                case "lastupdate_desc":
                    zipcodeIQ = zipcodeIQ.OrderByDescending(z => z.LastUpdate);
                    break;

                default:
                    zipcodeIQ = zipcodeIQ.OrderBy(z => z.Code);
                    break;
           }

            int pageSize = 10;
            ZipCode = await PaginatedList<ZipCode>.CreateAsync(
                zipcodeIQ.AsNoTracking(), pageIndex ?? 1, pageSize
            );
        }
    }
}
