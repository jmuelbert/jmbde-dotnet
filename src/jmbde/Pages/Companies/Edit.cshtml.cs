/**************************************************************************
 **
 ** SPDX-FileCopyrightText: 2016-2023 Jürgen Mülbert
 ** Copyright (c) 2016-2023 Jürgen Mülbert. All rights reserved.
 ** SPDX-License-Identifier: EUPL-1.2
 **
 **************************************************************************/

using System;
using System.Threading.Tasks;

using JMuelbert.BDE.Shared.Data;
using JMuelbert.BDE.Shared.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages.Companies
{
    /// <summary>
    /// Edit model.
    /// </summary>
    public class EditModel : PageModel
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
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Companies.EditModel"/>
        /// class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Context.</param>
        public EditModel(ILogger<EditModel> logger, BDEContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>The company.</value>
        [BindProperty]
        public Company Company { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <returns>The get async.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            _logger.LogDebug($"Companies/Edit/OnGetAsync({id})");

            if (id == null)
            {
                return NotFound();
            }

            Company = await _context.Company.FindAsync(id).ConfigureAwait(false);

            if (Company == null)
            {
                return NotFound();
            }
            return Page();
        }

        /// <summary>
        /// OnPostAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            _logger.LogDebug($"Companies/Edit/OnPostAsync{id})");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var companyToUpdate = await _context.Company.FindAsync(id).ConfigureAwait(false);

            if (await TryUpdateModelAsync<Company>(
                    companyToUpdate,
                    "company",  // Prefix for form value
                    c => c.Name, c => c.Name2, c => c.Street, c => c.PhoneNumber, c => c.FaxNumber,
                    c => c.MobileNumber, c => c.MailAddress, c => c.Active, c => c.LastUpdate)
                    .ConfigureAwait(false))
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}