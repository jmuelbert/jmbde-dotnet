using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using jmbde.Data;
using jmbde.Models;

namespace jmbde.Pages.ChipCardDoors
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
        public ChipCardDoor ChipCardDoor { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           _context.ChipCardDoor.Add(ChipCardDoor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}