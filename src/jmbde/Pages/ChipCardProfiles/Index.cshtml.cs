/**************************************************************************
 **
 ** SPDX-FileCopyrightText: 2016-2023 Jürgen Mülbert
 ** Copyright (c) 2016-2023 Jürgen Mülbert. All rights reserved.
 ** SPDX-License-Identifier: EUPL-1.2
 **
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JMuelbert.BDE.Shared.Data;
using JMuelbert.BDE.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages.ChipCardProfiles {
  /// <summary>
  /// Index model.
  /// </summary>
  public class IndexModel : PageModel {
    /// <summary>
    /// The context.
    /// </summary>
    private readonly BDEContext _context;

    /// <summary>
    /// The logger.
    /// </summary>
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="T:JMuelbert.BDE.Pages.ChipCardProfiles.IndexModel"/> class.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="context">Context.</param>
    public IndexModel(ILogger<IndexModel> logger, BDEContext context) {
      _logger = logger;
      _context = context;
    }

    /// <summary>
    /// Gets or sets the number sort.
    /// </summary>
    /// <value>The number sort.</value>
    public string NumberSort { get; set; }

    /// <summary>
    /// Gets or sets the date sort.
    /// </summary>
    /// <value>The date sort.</value>
    public string DateSort { get; set; }

    /// <summary>
    /// Gets or sets the current filter.
    /// </summary>
    /// <value>The current filter.</value>
    public string CurrentFilter { get; set; }

    /// <summary>
    /// Gets or sets the current sort.
    /// </summary>
    /// <value>The current sort.</value>
    public string CurrentSort { get; set; }

    /// <summary>
    /// Gets or sets the chip card profile.
    /// </summary>
    /// <value>The chip card profile.</value>
    public PaginatedCollection<ChipCardProfile> ChipCardProfile { get; set; }

    /// <summary>
    /// Ons the get async.
    /// </summary>
    /// <returns>The get async.</returns>
    /// <param name="sortOrder">Sort order.</param>
    /// <param name="currentFilter">Current filter.</param>
    /// <param name="searchString">Search string.</param>
    /// <param name="pageIndex">Page index.</param>
    public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString,
                                 int? pageIndex) {
      _logger.LogDebug(
          $"ChipCardProfile/Index/OnGetAsync({currentFilter},{searchString},{pageIndex})");

      CurrentSort = sortOrder;
      NumberSort = String.IsNullOrEmpty(sortOrder) ? "number_desc" : "";
      DateSort = sortOrder == "Date" ? "date_desc" : "Date";
      CurrentFilter = searchString;

      if (searchString != null) {
        pageIndex = 1;
      } else {
        searchString = currentFilter;
      }

      CurrentFilter = searchString;

      IQueryable<ChipCardProfile> chipCardProfileIQ = from c in _context.ChipCardProfile select c;

      if (!String.IsNullOrEmpty(searchString)) {
        chipCardProfileIQ = chipCardProfileIQ.Where(
            cp => cp.Number.Contains(searchString, StringComparison.CurrentCulture));
      }

      switch (sortOrder) {
        case "number_desc":
          chipCardProfileIQ = chipCardProfileIQ.OrderByDescending(cp => cp.Number);
          break;
        case "Date":
          chipCardProfileIQ = chipCardProfileIQ.OrderBy(cp => cp.LastUpdate);
          break;
        case "date_desc":
          chipCardProfileIQ = chipCardProfileIQ.OrderByDescending(cp => cp.LastUpdate);
          break;
        default:
          chipCardProfileIQ = chipCardProfileIQ.OrderBy(cp => cp.Number);
          break;
      }

      int pageSize = 10;
      ChipCardProfile = await PaginatedCollection<ChipCardProfile>.CreateAsync(
				chipCardProfileIQ.AsNoTracking(), pageIndex ?? 1, pageSize
			).ConfigureAwait(false);
    }
  }
}
