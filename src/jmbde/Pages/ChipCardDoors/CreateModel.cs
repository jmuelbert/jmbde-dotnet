/**************************************************************************
 **
 ** SPDX-FileCopyrightText:  © 2016-2023 Jürgen Mülbert
 **
 ** SPDX-License-Identifier: EUPL-1.2
 **
 *************************************************************************/

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
        /// Localization
        /// </summary>
        private readonly IStringLocalizer<CreateModel> _localizer;

        /// <summary>
        /// Localization
        /// </summary>
        private readonly IStringLocalizer<CreateModel> _sharedLocalizer;

        /// <summary>
        /// Initializes a new instance of the <see
        /// cref="T:JMuelbert.BDE.Pages.ChipCardDoors.CreateModel"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="localizer">localizer.</param>
        /// <param name="sharedLocalizer">localizer.</param>
        /// <param name="context">Context.</param>
        public CreateModel(ILogger<CreateModel> logger, IStringLocalizer<CreateModel> localizer,
                           IStringLocalizer<CreateModel> sharedLocalizer, BDEContext context)
        {
            _logger = logger;
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;
            _context = context;
        }

        /// <summary>
        /// Ons the get.
        /// </summary>
        /// <returns>The get.</returns>
        public IActionResult OnGet()
        {
            if (_logger != null)
            {
                _logger.LogDebug("ChipCardDoors/Create/OnGet");
            }
            return Page();
        }

        /// <summary>
        /// Gets or sets the chip card door.
        /// </summary>
        /// <value>The chip card door.</value>
        [BindProperty]
        public ChipCardDoor ChipCardDoor { get; set; }

        /// <summary>
        /// Ons the post async.
        /// </summary>
        /// <returns>The post async.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (_logger != null)
            {
                _logger.LogDebug("ChipCardDoors/Create/OnPostAsync");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyChipCardDoor = new ChipCardDoor();

            if (await TryUpdateModelAsync<ChipCardDoor>(emptyChipCardDoor,
                                                        "chipcarddoor",  // Prefix for form value
                                                        c => c.Number, c => c.LastUpdate)
                    .ConfigureAwait(false))
            {
                _context.ChipCardDoor.Add(emptyChipCardDoor);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToPage("./Index");
            }
            return null;
        }
    }
}