using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.Documents
{
    public class IndexModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public IndexModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IList<Document> Document { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            var documents = from d in _context.Document
                    select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                documents = documents.Where(doc => doc.Name.Contains(searchString));
            }

            Document = await documents.ToListAsync();
        }
    }
}
