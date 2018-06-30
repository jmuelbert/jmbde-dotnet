using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.SystemAccounts
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<SystemAccount> SystemAccount { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var systemaccounts = from s in _context.SystemAccount
                    select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                systemaccounts = systemaccounts.Where(sys => sys.UserName.Contains(searchString));
            }

            SystemAccount = await systemaccounts.ToListAsync();
        }
    }
}
