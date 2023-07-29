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

namespace JMuelbert.BDE.Pages.Computers {
  /// <summary>
  /// Details model.
  /// </summary>
  public class DetailsModel : PageModel {
    /// <summary>
    /// The context.
    /// </summary>
    private readonly BDEContext _context;

    /// <summary>
    /// The logger.
    /// </summary>
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Computers.DetailsModel"/>
    /// class.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="context"></param>
    public DetailsModel(ILogger<DetailsModel> logger, BDEContext context) {
      _logger = logger;
      _context = context;
    }

    /// <summary>
    /// Gets or sets the cityname.
    /// </summary>
    /// <value>The cityname.</value>
    public Computer Computer { get; set; }

    /// <summary>
    /// Ons the get async.
    /// </summary>
    /// <returns>The get async.</returns>
    /// <param name="id">Identifier.</param>
    public async Task<IActionResult> OnGetAsync(string? id) {
      _logger.LogDebug($"Computers/Details/OnGetAsync ({id})");

      if (id == null) {
        return NotFound();
      }

      Computer = await _context.Computer.Include(c => c.Software)
                     .AsNoTracking()
                     .SingleOrDefaultAsync(m => m.ComputerID == id)
                     .ConfigureAwait(false);

      if (Computer == null) {
        return NotFound();
      }
      return Page();
    }
  }
}
