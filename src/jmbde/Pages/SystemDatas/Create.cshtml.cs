using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using jmbde.Data.Models;

namespace jmbde.Pages.SystemDatas
{
    public class CreateModel : PageModel
    {
        private readonly jmbde.Data.JMBDEContext _context;

        public CreateModel(jmbde.Data.JMBDEContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SystemData SystemData { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptySystemData = new SystemData();

            if (await TryUpdateModelAsync<SystemData>(
                emptySystemData,
                "systemdata",       // Prefix for form value
                s => s.Name,
                s => s.Local,
                s => s.LastUpdate
            ))
            {
                _context.SystemData.Add(emptySystemData);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            return null;
        }
    }
}
