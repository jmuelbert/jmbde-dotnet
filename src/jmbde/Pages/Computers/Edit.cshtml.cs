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

namespace JMuelbert.BDE.Pages.Computers
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
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Computers.EditModel"/>
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
        /// Gets or sets the computer.
        /// </summary>
        /// <value>The computer.</value>
        [BindProperty]
        public Computer Computer { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <returns>The get async.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            _logger.LogDebug($"Computers/Edit/OnGetAsync({id})");

            if (id == null)
            {
                return NotFound();
            }

            Computer = await _context.Computer.FindAsync(id).ConfigureAwait(false);

            if (Computer == null)
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
            _logger.LogDebug($"Computers/Edit/OnPostAsync{id})");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var computerToUpdate = await _context.Computer.FindAsync(id).ConfigureAwait(false);

            if (await TryUpdateModelAsync<Computer>(
                    computerToUpdate,
                    "computer",  // Prefix for form value
                    c => c.ComputerID, c => c.SerialNumber, c => c.ServiceTag, c => c.ServiceNumber,
                    c => c.Memory, c => c.Network, c => c.NetworkIpAddress, c => c.IsActive,
                    c => c.ShouldReplace, c => c.LastUpdate)
                    .ConfigureAwait(false))
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}