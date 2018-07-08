using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Documents
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }


        public string NameSort { get; set; }
        public string DocumentDataSort { get; set; }
        public string LastUpdateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Document> Document { get;set; }

        public async Task OnGetAsync(string sortOrder, 
                string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DocumentDataSort = sortOrder == "DocumentData" ? "documentdata_desc" : "DocumentData";
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

            IQueryable<Document> documentIQ = from d in _context.Document
                        select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                documentIQ = documentIQ.Where(doc => doc.Name.Contains(searchString));
            }
        switch (sortOrder)
           {
                case "name_desc":
                    documentIQ = documentIQ.OrderByDescending(d => d.Name);
                    break;

              case "DocumentData":
                    documentIQ = documentIQ.OrderBy(d => d.DocumentData);
                    break;
                case "documentdata_desc":
                    documentIQ = documentIQ.OrderByDescending(d => d.DocumentData);
                    break;

                case "LastUpdate":
                    documentIQ = documentIQ.OrderBy(d => d.LastUpdate);
                    break;
                case "lastupdate_desc":
                    documentIQ = documentIQ.OrderByDescending(d => d.LastUpdate);
                    break;

                default:
                    documentIQ = documentIQ.OrderBy(d => d.Name);
                    break;
           }

           int pageSize = 10;
           Document = await PaginatedList<Document>.CreateAsync(
               documentIQ.AsNoTracking(), pageIndex ?? 1, pageSize
           );
        }
    }
}
