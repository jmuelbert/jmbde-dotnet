using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using jmbde.Models;

namespace jmbde.Pages.Processors
{
    public class CreateModel : PageModel
    {
        private readonly jmbde.Models.JMBDEContext _context;

        public CreateModel(jmbde.Models.JMBDEContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Processor Processor { get; set; }
        
        public CreateModel(Processor processor) 
        {
            this.Processor = processor;
               
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Processor.Add(Processor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}