using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.SystemDatas
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<SystemData> SystemData { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var systemdatas = from s in _context.SystemData
                    select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                systemdatas = systemdatas.Where(sys => sys.Name.Contains(searchString));
            } 

            SystemData = await systemdatas.ToListAsync();
        }
    }
}
