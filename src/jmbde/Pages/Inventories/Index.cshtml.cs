using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Inventories
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public string IdentifierSort { get; set; }
        public string DescriptionSort { get; set; }

        public string ActiveSort { get; set; }        
        public string LastUpdateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Inventory> Inventory { get;set; }

        public async Task OnGetAsync(string sortOrder, 
                string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            IdentifierSort = String.IsNullOrEmpty(sortOrder) ? "identifier_desc" : "";
            DescriptionSort = sortOrder == "Description" ? "description_desc" : "Description";
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

            IQueryable<Inventory> inventoryIQ = from i in _context.Inventory
                        select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                inventoryIQ = inventoryIQ.Where(inv => inv.Identifier.Contains(searchString));
            }

         switch (sortOrder)
           {
                case "identifier_desc":
                    inventoryIQ = inventoryIQ.OrderByDescending(i => i.Identifier);
                    break;

                case "Description":
                    inventoryIQ = inventoryIQ.OrderBy(i => i.Description);
                    break;

                case "description_desc":
                    inventoryIQ = inventoryIQ.OrderByDescending(i => i.Description);
                    break;

                case "Active":
                    inventoryIQ = inventoryIQ.OrderBy(i => i.Active);
                    break;

                case "active_desc":
                    inventoryIQ = inventoryIQ.OrderByDescending(i => i.Active);
                    break;
                    
                case "LastUpdate":
                    inventoryIQ = inventoryIQ.OrderBy(i => i.LastUpdate);
                    break;
                case "lastupdate_desc":
                    inventoryIQ = inventoryIQ.OrderByDescending(i => i.LastUpdate);
                    break;

                default:
                    inventoryIQ = inventoryIQ.OrderBy(i => i.Identifier);
                    break;
           }
 
           int pageSize = 10;
           Inventory = await PaginatedList<Inventory>.CreateAsync(
                inventoryIQ.AsNoTracking(), pageIndex ?? 1, pageSize
           );
        }
    }
}
