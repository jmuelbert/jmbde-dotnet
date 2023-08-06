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

namespace JMuelbert.BDE.Pages.Manufacturers
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
        /// Initializes a new instance of the <see
        /// cref="T:JMuelbert.BDE.Pages.Manufacturers.EditModel"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Context.</param>

        public EditModel(ILogger<EditModel> logger, BDEContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets or sets the Manufacturer.
        /// </summary>
        /// <value>The Manufacturer.</value>
        [BindProperty]
        public Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <returns>The get async.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            _logger.LogDebug($"Manufacturers/Edit/OnGetAsync({id})");
            if (id == null)
            {
                return NotFound();
            }

            Manufacturer = await _context.Manufacturer.FindAsync(id).ConfigureAwait(false);

            if (Manufacturer == null)
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
            _logger.LogDebug($"Manufacturers/Edit/OnPostAsync({id})");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var manufacturerToUpdate = await _context.Manufacturer.FindAsync(id).ConfigureAwait(false);

            if (await TryUpdateModelAsync<Manufacturer>(
                    manufacturerToUpdate,
                    "manufacturer",  // Prefix for form value
                    m => m.Name, m => m.Name2, m => m.Supporter, m => m.Street, m => m.Street22,
                    m => m.MailAddress, m => m.PhoneNumber, m => m.FaxNumber, m => m.HotlineNumber,
                    m => m.LastUpdate)
                    .ConfigureAwait(false))
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}