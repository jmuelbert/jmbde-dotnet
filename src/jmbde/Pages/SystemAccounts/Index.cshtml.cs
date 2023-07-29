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

namespace JMuelbert.BDE.Pages.SystemAccounts {
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
    /// cref="T:JMuelbert.BDE.Pages.SystemAccounts.IndexModel"/> class.
    /// </summary>
    /// <param name="logger">Logger.</param>
    /// <param name="context">Context.</param>

    public IndexModel(ILogger<IndexModel> logger, BDEContext context) {
      _logger = logger;
      _context = context;
    }

    /// <summary>
    /// Gets or sets the UserNameSort.
    /// </summary>
    /// <value>The UserNameSort.</value>
    public string UserNameSort { get; set; }

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
    /// Gets or sets the SystemAccount.
    /// </summary>
    /// <value>The SystemAccount.</value>

    public PaginatedCollection<SystemAccount> SystemAccount { get; set; }

    public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString,
                                 int? pageIndex) {
      _logger.LogDebug(
          $"SystemAccount/Index/OnGetAsync({currentFilter},{searchString},{pageIndex})");

      CurrentSort = sortOrder;
      UserNameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
      LastUpdateSort = sortOrder == "LastUpdate" ? "lastupdate_desc" : "LastUpdate";
      if (searchString != null) {
        pageIndex = 1;
      } else {
        searchString = currentFilter;
      }

      CurrentFilter = searchString;

      IQueryable<SystemAccount> systemaccountIQ = from s in _context.SystemAccount select s;

      if (!String.IsNullOrEmpty(searchString)) {
        systemaccountIQ = systemaccountIQ.Where(
            sys => sys.UserName.Contains(searchString, StringComparison.CurrentCulture));
      }

      switch (sortOrder) {
        case "name_desc":
          systemaccountIQ = systemaccountIQ.OrderByDescending(s => s.UserName);
          break;

        case "LastUpdate":
          systemaccountIQ = systemaccountIQ.OrderBy(s => s.LastUpdate);
          break;
        case "lastupdate_desc":
          systemaccountIQ = systemaccountIQ.OrderByDescending(s => s.LastUpdate);
          break;

        default:
          systemaccountIQ = systemaccountIQ.OrderBy(s => s.UserName);
          break;
      }

      int pageSize = 10;
      SystemAccount = await PaginatedCollection<SystemAccount>.CreateAsync(
				systemaccountIQ.AsNoTracking(), pageIndex ?? 1, pageSize
			).ConfigureAwait(false);
    }
  }
}
