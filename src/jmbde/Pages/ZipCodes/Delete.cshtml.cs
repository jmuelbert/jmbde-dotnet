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

namespace JMuelbert.BDE.Pages.ZipCodes
{
    /// <summary>
    /// Delete model.
    /// </summary>
    public class DeleteModel : PageModel
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
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.ZipCodes.IndexModel"/>
        /// class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Context.</param>

        public DeleteModel(ILogger<DeleteModel> logger, BDEContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets or sets the ZipCode.
        /// </summary>
        /// <value>The ZipCode.</value>
        [BindProperty]
        public ZipCode ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the ErrorMessage.
        /// </summary>
        /// <value>The ErrorMessage.</value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <returns>The get async.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="saveChangesError">Save changes error.</param>
        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            _logger.LogDebug($"ZipCodes/Delete/OnGetAsync({id}, {saveChangesError})");

            if (id == null)
            {
                return NotFound();
            }

            ZipCode = await _context.ZipCode.AsNoTracking()
                          .FirstOrDefaultAsync(z => z.ID == id)
                          .ConfigureAwait(false);

            if (ZipCode == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }
            return Page();
        }

        /// <summary>
        /// Ons the post async.
        /// </summary>
        /// <returns>The post async.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            _logger.LogDebug($"ZipCodes/Delete/OnPostAsync ({id})");

            if (id == null)
            {
                return NotFound();
            }

            var zipcode = await _context.ZipCode.AsNoTracking()
                              .FirstOrDefaultAsync(z => z.ID == id)
                              .ConfigureAwait(false);

            if (zipcode == null)
            {
                return NotFound();
            }

            try
            {
                _context.ZipCode.Remove(zipcode);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("ZipCodes/Delete {0}", ex.ToString());

                return RedirectToAction("./Delete", new { id, saveChangesError = true });
            }
        }
    }
}