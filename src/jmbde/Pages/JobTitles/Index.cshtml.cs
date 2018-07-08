using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.JobTitles
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string FromDateSort { get; set; }
        public string LastUpdateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<JobTitle> JobTitle { get;set; }

        public async Task OnGetAsync(string sortOrder, 
                string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            FromDateSort = sortOrder == "FromDate" ? "fromdate_desc" : "FromDate";
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

            IQueryable<JobTitle> jobTitleIQ = from j in _context.JobTitle
                        select j;

            if (!String.IsNullOrEmpty(searchString))
            {
                jobTitleIQ = jobTitleIQ.Where(job => job.Name.Contains(searchString));
            }

           switch (sortOrder)
           {
                case "name_desc":
                    jobTitleIQ = jobTitleIQ.OrderByDescending(j => j.Name);
                    break;

                case "FromDate":
                    jobTitleIQ = jobTitleIQ.OrderBy(j => j.FromDate);
                    break;

                case "fromdate_desc":
                    jobTitleIQ = jobTitleIQ.OrderByDescending(j => j.FromDate);
                    break; 
                case "LastUpdate":
                    jobTitleIQ = jobTitleIQ.OrderBy(d => d.LastUpdate);
                    break;
                case "lastupdate_desc":
                    jobTitleIQ = jobTitleIQ.OrderByDescending(d => d.LastUpdate);
                    break;

                default:
                    jobTitleIQ = jobTitleIQ.OrderBy(d => d.Name);
                    break;
           }

           int pageSize = 10;
           JobTitle = await PaginatedList<JobTitle>.CreateAsync(
               jobTitleIQ.AsNoTracking(), pageIndex ?? 1, pageSize
           );
        }
    }
}
