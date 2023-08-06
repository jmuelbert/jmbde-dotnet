/**************************************************************************
 **
 ** SPDX-FileCopyrightText: 2016-2023 Jürgen Mülbert
 ** Copyright (c) 2016-2023 Jürgen Mülbert. All rights reserved.
 ** SPDX-License-Identifier: EUPL-1.2
 **
 **************************************************************************/

using System.Threading.Tasks;
using JMuelbert.BDE.Shared.Data;
using JMuelbert.BDE.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages.ChipCardProfiles
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
        /// cref="T:JMuelbert.BDE.Pages.ChipCardProfiles.EditModel"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Context.</param>
        public EditModel(ILogger<EditModel> logger, BDEContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets or sets the chip card profile.
        /// </summary>
        /// <value>The chip card profile.</value>
        [BindProperty]
        public ChipCardProfile ChipCardProfile { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <returns>The get async.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            _logger.LogDebug($"ChipCardProfile/Edit/OnGetAsync({id})");

            if (id == null)
            {
                return NotFound();
            }

            ChipCardProfile = await _context.ChipCardProfile.FindAsync(id).ConfigureAwait(false);

            if (ChipCardProfile == null)
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
        public async Task<IActionResult> OnPostAsync(long? id)
        {
            _logger.LogDebug($"ChipCardProfile/Edit/OnPostAsync{id})");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var chipcardprofileToUpdate =
                await _context.ChipCardProfile.FindAsync(id).ConfigureAwait(false);

            if (await TryUpdateModelAsync<ChipCardProfile>(chipcardprofileToUpdate,
                                                           "chipcardprofile",  // Prefix for form value
                                                           c => c.Number, c => c.LastUpdate)
                    .ConfigureAwait(false))
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}