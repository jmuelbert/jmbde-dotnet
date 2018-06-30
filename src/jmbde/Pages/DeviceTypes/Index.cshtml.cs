using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.DeviceTypes
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<DeviceType> DeviceType { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var devicetypes = from d in _context.DeviceType
                    select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                devicetypes = devicetypes.Where(dt => dt.Name.Contains(searchString));
            }

            DeviceType = await devicetypes.ToListAsync();
        }
    }
}
