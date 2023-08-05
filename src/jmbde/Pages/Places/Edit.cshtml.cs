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

namespace JMuelbert.BDE.Pages.Places
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
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Places.EditModel"/>
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
        /// Gets or sets the Place.
        /// </summary>
        /// <value>The Place.</value>
        [BindProperty]
        public Place Place { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <returns>The get async.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            _logger.LogDebug($"Places/Edit/OnGetAsync({id})");

            if (id == null)
            {
                return NotFound();
            }

            Place = await _context.Place.FindAsync(id).ConfigureAwait(false);

            if (Place == null)
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
            _logger.LogDebug($"Places/Edit/OnPostAsync({id})");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var placeToUpdate = await _context.Place.FindAsync(id).ConfigureAwait(false);

            if (await TryUpdateModelAsync<Place>(placeToUpdate,
                                                 "place",  // Preset for form value
                                                 p => p.Name, p => p.Room, p => p.Desk, p => p.LastUpdate)
                    .ConfigureAwait(false))
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}