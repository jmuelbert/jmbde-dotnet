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

namespace JMuelbert.BDE.Pages.Mobiles {
  /// <summary>
  /// Create model.
  /// </summary>
  public class CreateModel : PageModel {
    /// <summary>
    /// The context.
    /// </summary>
    private readonly BDEContext _context;

    /// <summary>
    /// The logger.
    /// </summary>
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Mobiles.IndexModel"/>
    /// class.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="context">Context.</param>

    public CreateModel(ILogger<CreateModel> logger, BDEContext context) {
      _logger = logger;
      _context = context;
    }

    /// <summary>
    /// Ons the get.
    /// </summary>
    /// <returns>The get.</returns>
    public IActionResult OnGet() {
      _logger.LogDebug("Mobiles/Create/OnGet");
      return Page();
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
    public async Task<IActionResult> OnPostAsync() {
      _logger.LogDebug("Mobiles/Create/OnPostAsync");

      if (!ModelState.IsValid) {
        return Page();
      }

      var emptyMobile = new Mobile();

      if (await TryUpdateModelAsync<Mobile>(emptyMobile,
                                            "mobile",  // Prefix for form value
                                            m => m.Number, m => m.SerialNumber, m => m.Pin,
                                            m => m.CardNumber, m => m.Active, m => m.Replace,
                                            m => m.LastUpdate)
              .ConfigureAwait(false)) {
        _context.Mobile.Add(emptyMobile);
        await _context.SaveChangesAsync().ConfigureAwait(false);

        return RedirectToPage("./Index");
      }
      return null;
    }
  }
}
