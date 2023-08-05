/**************************************************************************
 **
 ** SPDX-FileCopyrightText: © 2016-2023 Jürgen Mülbert
 **
 ** SPDX-License-Identifier: EUPL-1.2
 **
 *************************************************************************/

using System;
using System.Threading.Tasks;
using JMuelbert.BDE.Shared.Data;
using JMuelbert.BDE.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages.Departments
{
    /// <summary>
    /// Create model.
    /// </summary>
    public class CreateModel : PageModel
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly BDEContext _context;
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Departments.IndexModel"/>
        /// class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Context.</param>

        public CreateModel(ILogger<CreateModel> logger, BDEContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Ons the get.
        /// </summary>
        /// <returns>The get.</returns>
        public IActionResult OnGet()
        {
            _logger.LogDebug("Departments/Create/OnGet");
            return Page();
        }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>The department.</value>
        [BindProperty]
        public Department Department { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <returns>The get async.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogDebug("Department/Create/OnPostAsync");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyDepartment = new Department();

            if (await TryUpdateModelAsync<Department>(emptyDepartment,
                                                      "department",  // Prefix fpr form value
                                                      d => d.Name, d => d.Priority, d => d.LastUpdate)
                    .ConfigureAwait(false))
            {
                _context.Department.Add(emptyDepartment);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                return RedirectToPage("./Index");
            }
            return null;
        }
    }
}