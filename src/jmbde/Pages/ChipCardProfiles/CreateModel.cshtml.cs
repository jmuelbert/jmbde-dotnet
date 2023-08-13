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

namespace JMuelbert.BDE.Pages.ChipCardProfiles
{
    /// <summary>
    /// CreateModel
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
        /// Gets or sets the chip card profile.
        /// </summary>
        /// <value>The chip card profile.</value>
        [BindProperty]
        public ChipCardProfile ChipCardProfile { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see
        /// cref="T:JMuelbert.BDE.Pages.ChipCardProfiles.CreateModel"/> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
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
            _logger.LogDebug("ChipCardProfiles/Create/OnGet");

            return Page();
        }

        /// <summary>
        /// Ons the post async.
        /// </summary>
        /// <returns>The post async.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogDebug("ChipCardProfiles/Create/OnPostAsync");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyChipCardProfile = new ChipCardProfile();

            if (await TryUpdateModelAsync<ChipCardProfile>(emptyChipCardProfile,
                                                           "chipcardprofile",  // Prefix for form value
                                                           c => c.Number, c => c.LastUpdate)
                    .ConfigureAwait(false))
            {
                _context.ChipCardProfile.Add(emptyChipCardProfile);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToPage("./Index");
            }

            return null;
        }
    }
}