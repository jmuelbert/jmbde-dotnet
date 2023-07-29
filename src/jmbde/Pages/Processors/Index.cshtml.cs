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

namespace JMuelbert.BDE.Pages.Processors {
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
    /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Processors.IndexModel"/>
    /// class.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="context">Context.</param>

    public IndexModel(ILogger<IndexModel> logger, BDEContext context) {
      _logger = logger;
      _context = context;
    }

    /// <summary>
    /// Gets or sets the NameSort.
    /// </summary>
    /// <value>The NameSort.</value>
    public string NameSort { get; set; }

    /// <summary>
    /// Gets or sets the ClockRateSort.
    /// </summary>
    /// <value>The ClockRateSort.</value>
    public string ClockRateSort { get; set; }

    /// <summary>
    /// Gets or sets the CoresSort.
    /// </summary>
    /// <value>The CoresSort.</value>
    public string CoresSort { get; set; }

    // TODO: Remove LastUpdate Sort

    /// <summary>
    /// Gets or sets the lastupdate sort.
    /// </summary>
    /// <value>The lastupdate sort.</value>
    public string LastUpdateSort { get; set; }

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
    /// Gets or sets the Processor.
    /// </summary>
    /// <value>The Processor.</value>

    public PaginatedCollection<Processor> Processor { get; set; }

    /// <summary>
    /// Ons the get async.
    /// </summary>
    /// <param name="sortOrder"></param>
    /// <param name="currentFilter"></param>
    /// <param name="searchString"></param>
    /// <param name="pageIndex"></param>
    /// <returns></returns>
    public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString,
                                 int? pageIndex) {
      _logger.LogDebug($"Processors/Index/OnGetAsync({currentFilter},{searchString},{pageIndex})");

      CurrentSort = sortOrder;
      NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
      ClockRateSort = sortOrder == "ClockRate" ? "clockrate_desc" : "ClockRate";
      CoresSort = sortOrder == "Core" ? "core_desc" : "Core";
      LastUpdateSort = sortOrder == "LastUpdate" ? "lastupdate_desc" : "LastUpdate";
      if (searchString != null) {
        pageIndex = 1;
      } else {
        searchString = currentFilter;
      }

      CurrentFilter = searchString;

      IQueryable<Processor> processorIQ = from p in _context.Processor select p;

      if (!String.IsNullOrEmpty(searchString)) {
        processorIQ =
            processorIQ.Where(p => p.Name.Contains(searchString, StringComparison.CurrentCulture));
      }

      switch (sortOrder) {
        case "name_desc":
          processorIQ = processorIQ.OrderByDescending(p => p.Name);
          break;

        case "ClockRate":
          processorIQ = processorIQ.OrderBy(p => p.ClockRate);
          break;

        case "clockrate_desc":
          processorIQ = processorIQ.OrderByDescending(p => p.ClockRate);
          break;

        case "Core":
          processorIQ = processorIQ.OrderBy(p => p.Cores);
          break;

        case "core_desc":
          processorIQ = processorIQ.OrderByDescending(p => p.Cores);
          break;

        case "LastUpdate":
          processorIQ = processorIQ.OrderBy(p => p.LastUpdate);
          break;
        case "lastupdate_desc":
          processorIQ = processorIQ.OrderByDescending(p => p.LastUpdate);
          break;

        default:
          processorIQ = processorIQ.OrderBy(p => p.Name);
          break;
      }

      int pageSize = 10;
      Processor = await PaginatedCollection<Processor>.CreateAsync(
				processorIQ.AsNoTracking(), pageIndex ?? 1, pageSize
			).ConfigureAwait(false);
    }
  }
}
