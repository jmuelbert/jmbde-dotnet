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

        public IList<Place> Place { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var places = from p in _context.Place
                    select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                places = places.Where(pl => pl.Name.Contains(searchString));
            }

            Place = await places.ToListAsync();
        }
    }
}
