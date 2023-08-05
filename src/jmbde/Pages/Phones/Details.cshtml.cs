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

namespace JMuelbert.BDE.Pages.Phones
{
    /// <summary>
    /// Details model.
    /// </summary>
    public class DetailsModel : PageModel
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
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Phones.DetailsModel"/>
        /// class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>

        public DetailsModel(ILogger<DetailsModel> logger, BDEContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets or sets the Phone.
        /// </summary>
        /// <value>The Phone.</value>
        public Phone Phone { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        ///  <returns>The get async.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            _logger.LogDebug($"Phones/Details/OnGetAsync ({id})");

            if (id == null)
            {
                return NotFound();
            }

            Phone = await _context.Phone.SingleOrDefaultAsync(m => m.ID == id).ConfigureAwait(false);

            if (Phone == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}