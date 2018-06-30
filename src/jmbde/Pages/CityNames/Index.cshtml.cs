using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.CityNames
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<CityName> CityName { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var cities = from c in _context.CityName
                    select c;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                cities = cities.Where(cn => cn.Name.Contains(searchString));
            }

            CityName = await cities.ToListAsync();
        }
    }
}
