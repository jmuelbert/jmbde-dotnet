using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Printers
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
        public string PaperSizeSort { get; set; }
        public string ColorSort { get; set; }
        public string LastUpdateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Printer> Printer { get;set; }

             public async Task OnGetAsync(string sortOrder, 
                string currentFilter, string searchString, int? pageIndex)
            {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ActiveSort = sortOrder == "Active" ? "active_desc" : "Active";
            ReplaceSort = sortOrder == "Replace" ? "replace_desc" : "Replace";
            PaperSizeSort = sortOrder == "PaperSize" ? "papersize_desc" : "PaperSize";
            ColorSort = sortOrder == "Color" ? "color_desc" : "Color";
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

            IQueryable<Printer> printerIQ = from p in _context.Printer
                        select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                printerIQ = printerIQ.Where(pr => pr.Name.Contains(searchString));
            }

          switch (sortOrder)
           {
                case "name_desc":
                    printerIQ = printerIQ.OrderByDescending(p => p.Name);
                    break;

                case "Active":
                    printerIQ = printerIQ.OrderBy(p => p.Active);
                    break;

                case "active_desc":
                    printerIQ = printerIQ.OrderByDescending(p => p.Active);
                    break;

                case "Replace":
                    printerIQ = printerIQ.OrderBy(p => p.Replace);
                    break;

                case "replace_desc":
                    printerIQ = printerIQ.OrderByDescending(p => p.Replace);
                    break;

                case "PaperSize":
                    printerIQ = printerIQ.OrderBy(p => p.PaperSize);
                    break;

                case "papersize_desc":
                    printerIQ = printerIQ.OrderByDescending(p => p.PaperSize);
                    break;

                case "Color":
                    printerIQ = printerIQ.OrderBy(p => p.Color);
                    break;

                case "color_desc":
                    printerIQ = printerIQ.OrderByDescending(p => p.Color);
                    break;

                case "LastUpdate":
                    printerIQ = printerIQ.OrderBy(p => p.LastUpdate);
                    break;
                case "lastupdate_desc":
                    printerIQ = printerIQ.OrderByDescending(p => p.LastUpdate);
                    break;

                default:
                    printerIQ = printerIQ.OrderBy(p => p.Name);
                    break;
           }

            int pageSize = 10;
            Printer = await PaginatedList<Printer>.CreateAsync(
               printerIQ.AsNoTracking(), pageIndex ?? 1, pageSize
           );
        }
    }
}
