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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages.ChipCardDoors
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
        /// Localization
        /// </summary>
        private readonly IStringLocalizer<EditModel> _localizer;

        /// <summary>
        /// Localization
        /// </summary>
        private readonly IStringLocalizer<EditModel> _sharedLocalizer;

        /// <summary>
        /// Initializes a new instance of the <see
        /// cref="T:JMuelbert.BDE.Pages.ChipCardDoors.EditModel"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="localizer">localizer.</param>
        /// <param name="sharedLocalizer">localizer.</param>
        /// <param name="context">Context.</param>
        public EditModel(ILogger<EditModel> logger, IStringLocalizer<EditModel> localizer,
                         IStringLocalizer<EditModel> sharedLocalizer, BDEContext context)
        {
            _logger = logger;
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;
            _context = context;
        }

        /// <summary>
        /// Gets or sets the chip card door.
        /// </summary>
        /// <value>The chip card door.</value>
        [BindProperty]
        public ChipCardDoor ChipCardDoor { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <returns>The get async.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            _logger.LogDebug($"ChipCardDoors/Edit/OnGetAsync({id})");

            if (id == null)
            {
                return NotFound();
            }

            ChipCardDoor = await _context.ChipCardDoor.FindAsync(id).ConfigureAwait(false);

            if (ChipCardDoor == null)
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
            _logger.LogDebug($"ChipCardDoors/Edit/OnPostAsync({id})");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var chipcarddoorToUpdate = await _context.ChipCardDoor.FindAsync(id).ConfigureAwait(false);

            if (await TryUpdateModelAsync<ChipCardDoor>(chipcarddoorToUpdate, "chipcarddoor",
                                                        c => c.Number, c => c.Place, c => c.LastUpdate)
                    .ConfigureAwait(false))
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}