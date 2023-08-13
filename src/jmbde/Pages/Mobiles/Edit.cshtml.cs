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

namespace JMuelbert.BDE.Pages.Mobiles
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
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Mobile.EditModel"/>
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
        /// Gets or sets the Mobile.
        /// </summary>
        /// <value>The Mobile.</value>
        [BindProperty]
        public Mobile Mobile { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <returns>The get async.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            _logger.LogDebug($"Mobiles/Edit/OnGetAsync ({id})");
            if (id == null)
            {
                return NotFound();
            }

            Mobile = await _context.Mobile.FindAsync(id).ConfigureAwait(false);

            if (Mobile == null)
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
            _logger.LogDebug($"Mobiles/Edit/OnGetAsync({id})");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var mobileToUpdate = await _context.Mobile.FindAsync(id).ConfigureAwait(false);

            if (await TryUpdateModelAsync<Mobile>(mobileToUpdate,
                                                  "mobile",  // Prefix for form value
                                                  m => m.Number, m => m.SerialNumber, m => m.Pin,
                                                  m => m.CardNumber, m => m.Active, m => m.Replace,
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