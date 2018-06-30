using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.JobTitles
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<JobTitle> JobTitle { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var jobtitles = from j in _context.JobTitle
                    select j;

            if (!String.IsNullOrEmpty(searchString))
            {
                jobtitles = jobtitles.Where(job => job.Name.Contains(searchString));
            }

            JobTitle = await jobtitles.ToListAsync();
        }
    }
}
