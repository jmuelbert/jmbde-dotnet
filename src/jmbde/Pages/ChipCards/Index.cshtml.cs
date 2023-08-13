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

namespace JMuelbert.BDE.Pages.ChipCards
{
    /// <summary>
    /// Index model.
    /// </summary>
    public class IndexModel : PageModel
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
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.ChipCards.IndexModel"/>
        /// class.
        /// </summary>
        /// <param name="logger">Logger.async</param>
        /// <param name="context">Context.</param>
        public IndexModel(ILogger<IndexModel> logger, BDEContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets or sets the number sort.
        /// </summary>
        /// <value>The number sort.</value>
        public string NumberSort { get; set; }

        /// <summary>
        /// Gets or sets the locked sort.
        /// </summary>
        /// <value>The date sort.</value>
        public string LockedSort { get; set; }

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
        /// Gets or sets the chip card.
        /// </summary>
        /// <value>The chip card.</value>
        public PaginatedCollection<ChipCard> ChipCard { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <returns>The get async.</returns>
        /// <param name="sortOrder">Sort order.</param>
        /// <param name="currentFilter">Current filter.</param>
        /// <param name="searchString">Search string.</param>
        /// <param name="pageIndex">Page index.</param>
        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString,
                                     int? pageIndex)
        {
            _logger.LogDebug($"ChipCards/Index/OnGetAsync{currentFilter},{searchString},{pageIndex})");

            CurrentSort = sortOrder;
            NumberSort = String.IsNullOrEmpty(sortOrder) ? "number_desc" : "";
            LockedSort = sortOrder == "Locked" ? "locked_desc" : "Locked";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<ChipCard> chipCardIQ = from c in _context.ChipCard select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                chipCardIQ = chipCardIQ.Where(
                    cc => cc.Number.Contains(searchString, StringComparison.CurrentCulture));
            }

            switch (sortOrder)
            {
                case "number_desc":
                    chipCardIQ = chipCardIQ.OrderByDescending(c => c.Number);
                    break;
                case "Locked":
                    chipCardIQ = chipCardIQ.OrderBy(c => c.Locked);
                    break;
                case "locked_desc":
                    chipCardIQ = chipCardIQ.OrderByDescending(c => c.Locked);
                    break;
                case "Date":
                    chipCardIQ = chipCardIQ.OrderBy(c => c.LastUpdate);
                    break;
                case "date_desc":
                    chipCardIQ = chipCardIQ.OrderByDescending(c => c.LastUpdate);
                    break;
                default:
                    chipCardIQ = chipCardIQ.OrderBy(c => c.Number);
                    break;
            }

            int pageSize = 10;

            ChipCard = await PaginatedCollection<ChipCard>.CreateAsync(
                      chipCardIQ.AsNoTracking(), pageIndex ?? 1, pageSize
                  ).ConfigureAwait(false);
        }
    }
}