/**************************************************************************
 **
 ** SPDX-FileCopyrightText: 2016-2023 Jürgen Mülbert
 ** Copyright (c) 2016-2023 Jürgen Mülbert. All rights reserved.
 ** SPDX-License-Identifier: EUPL-1.2
 **
 **************************************************************************/

using System;
using System.Linq;
using System.Threading.Tasks;
using JMuelbert.BDE.Shared.Data;
using JMuelbert.BDE.Shared.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace JMuelbert.BDE.Pages.ChipCardDoors {
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
    /// Localization
    /// </summary>
    private readonly IStringLocalizer<EditModel> _localizer;

    /// <summary>
    /// Localization
    /// </summary>
    private readonly IStringLocalizer<EditModel> _sharedLocalizer;

    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="T:JMuelbert.BDE.Pages.ChipCardDoors.IndexModel"/> class.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="localizer">localizer.</param>
    /// <param name="sharedLocalizer">localizer.</param>
    /// <param name="context">Context.</param>
    public IndexModel(ILogger<IndexModel> logger, IStringLocalizer<EditModel> localizer,
                      IStringLocalizer<EditModel> sharedLocalizer, BDEContext context) {
      _logger = logger;
      _localizer = localizer;
      _sharedLocalizer = sharedLocalizer;
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
    /// Gets or sets the chip card door.
    /// </summary>
    /// <value>The chip card door.</value>
    public PaginatedCollection<ChipCardDoor> ChipCardDoor { get; set; }

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
          $"ChipCardDoors/Index/OnGetAsync({currentFilter},{searchString},{pageIndex})");

      CurrentFilter = sortOrder;
      NumberSort = String.IsNullOrEmpty(sortOrder) ? "number_desc" : "";
      DateSort = sortOrder == "Date" ? "date_desc" : "Date";
      if (searchString != null) {
        pageIndex = 1;
      } else {
        searchString = currentFilter;
      }

      CurrentFilter = searchString;

      IQueryable<ChipCardDoor> chipCardDoorIQ = from ccd in _context.ChipCardDoor select ccd;

      if (!String.IsNullOrEmpty(searchString)) {
        chipCardDoorIQ = chipCardDoorIQ.Where(
            cd => cd.Number.Contains(searchString, StringComparison.CurrentCulture));
      }

      switch (sortOrder) {
        case "number_desc":
          chipCardDoorIQ = chipCardDoorIQ.OrderByDescending(c => c.Number);
          break;
        case "Date":
          chipCardDoorIQ = chipCardDoorIQ.OrderBy(c => c.LastUpdate);
          break;
        case "date_desc":
          chipCardDoorIQ = chipCardDoorIQ.OrderByDescending(c => c.LastUpdate);
          break;
        default:
          chipCardDoorIQ = chipCardDoorIQ.OrderBy(c => c.Number);
          break;
      }

      int pageSize = 10;

      ChipCardDoor = await PaginatedCollection<ChipCardDoor>.CreateAsync(
				chipCardDoorIQ.AsNoTracking(), pageIndex ?? 1, pageSize).ConfigureAwait(false);
    }
  }
}
