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

namespace JMuelbert.BDE.Pages.CityNames
{
    /// <summary>
    /// Delete model.
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
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.CityNames.IndexModel"/>
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
            _logger.LogDebug("CityNames/Create/OnGet");

            return Page();
        }

        /// <summary>
        /// Gets or sets the cityname.
        /// </summary>
        /// <value>The cityname.</value>
        [BindProperty]
        public CityName CityName { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <returns>The get async.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogDebug("CityNames/Create/OnPostAsync");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyCityName = new CityName();

            if (await TryUpdateModelAsync<CityName>(emptyCityName,
                                                    "cityname",  // Prefix for form value
                                                    c => c.Name, c => c.LastUpdate)
                    .ConfigureAwait(false))
            {
                _context.CityName.Add(emptyCityName);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                return RedirectToPage("./Index");
            }
            return null;
        }
    }
}