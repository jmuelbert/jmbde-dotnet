using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Places
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string RoomSort { get; set; }
        public string DeskSort { get; set; }
        public string LastUpdateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Place> Place { get;set; }

          public async Task OnGetAsync(string sortOrder, 
                string currentFilter, string searchString, int? pageIndex)
            {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            RoomSort = sortOrder == "Room" ? "room_desc" : "Room";
            DeskSort = sortOrder == "Desk" ? "desk_desc" : "Desk";
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

            IQueryable<Place> placeIQ = from p in _context.Place
                    select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                placeIQ = placeIQ.Where(pl => pl.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    placeIQ = placeIQ.OrderByDescending(p => p.Name);
                    break;
                
                case "Room":
                    placeIQ = placeIQ.OrderBy(p => p.Room);
                    break;

                case "room_desc":
                    placeIQ = placeIQ.OrderByDescending(p => p.Room);
                    break;

                case "Desk":
                    placeIQ = placeIQ.OrderBy(p => p.Desk);
                    break;

                case "desk_desc":
                    break;

                case "LastUpdate":
                    placeIQ = placeIQ.OrderBy(p => p.LastUpdate);
                    break;

                case "lastupdate_desc":
                    placeIQ = placeIQ.OrderByDescending(p => p.LastUpdate);
                    break;

                default:
                    placeIQ = placeIQ.OrderBy(p => p.Name);
                    break;
            }

            int pageSize = 10;
            Place = await PaginatedList<Place>.CreateAsync(
                placeIQ.AsNoTracking(), pageIndex ?? 1, pageSize
            );
        }
    }
}
