using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.DeviceNames
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<DeviceName> DeviceName { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var devicenames = from d in _context.DeviceName
                    select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                devicenames = devicenames.Where(dn => dn.Name.Contains(searchString));
            }

            DeviceName = await devicenames.ToListAsync();
        }
    }
}
