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

        public IList<Phone> Phone { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var phones = from p in _context.Phone
                select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                phones = phones.Where(ph => ph.Number.Contains(searchString));
            }

            Phone = await phones.ToListAsync();
        }
    }
}
