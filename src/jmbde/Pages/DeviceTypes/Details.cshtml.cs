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

namespace JMuelbert.BDE.Pages.DeviceTypes {
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
    /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.DeviceTypes.IndexModel"/>
    /// class.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="context">Context.</param>
    public DetailsModel(ILogger<DetailsModel> logger, BDEContext context) {
      _logger = logger;
      _context = context;
    }

    /// <summary>
    /// Gets or sets the devicename.
    /// </summary>
    /// <value>The devicename.</value>
    public DeviceType DeviceType { get; set; }

    /// <summary>
    /// Ons the get async.
    /// </summary>
    /// <returns>The get async.</returns>
    /// <param name="id">Identifier.</param>
    public async Task<IActionResult> OnGetAsync(int? id) {
      _logger.LogDebug($"DeviceTypes/Details/OnGetAsync ({id})");
      if (id == null) {
        return NotFound();
      }

      DeviceType =
          await _context.DeviceType.SingleOrDefaultAsync(m => m.ID == id).ConfigureAwait(false);

      if (DeviceType == null) {
        return NotFound();
      }
      return Page();
    }
  }
}
