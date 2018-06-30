using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var departments = from d in _context.Department
                    select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                departments = departments.Where(dep => dep.Name.Contains(searchString));
            }
            
            Department = await departments.ToListAsync();
        }
    }
}
