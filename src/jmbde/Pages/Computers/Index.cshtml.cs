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

namespace JMuelbert.BDE.Pages.Computers
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
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Computers.IndexModel"/>
        /// class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Context.</param>

        public IndexModel(ILogger<IndexModel> logger, BDEContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets or sets the name sort.
        /// </summary>
        /// <value>The name sort.</value>
        public string NameSort { get; set; }

        /// <summary>
        /// Gets or sets the active sort.
        /// </summary>
        /// <value>The active sort.</value>
        public string ActiveSort { get; set; }

        /// <summary>
        /// Gets or sets the replace sort.
        /// </summary>
        /// <value>The replace sort.</value>
        public string ReplaceSort { get; set; }

        // TODO: Remove the LastUpdateSort
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
        /// Gets or sets the cityname profile.
        /// </summary>
        /// <value>The cityname profile.</value>
        public PaginatedCollection<Computer> Computer { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="currentFilter"></param>
        /// <param name="searchString"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString,
                                     int? pageIndex)
        {
            _logger.LogDebug($"Computers/Index/OnGetAsync({currentFilter},{searchString},{pageIndex})");

            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ActiveSort = sortOrder == "Active" ? "active_desc" : "Active";
            ReplaceSort = sortOrder == "Replace" ? "replace_desc" : "Replace";
            LastUpdateSort = sortOrder == "LastUpdate" ? "lastupdate_sort" : "LastUpdate";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Computer> computerIQ = from c in _context.Computer select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                computerIQ = computerIQ.Where(
                    comp => comp.ComputerID.Contains(searchString, StringComparison.CurrentCulture));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    computerIQ = computerIQ.OrderByDescending(c => c.ComputerID);
                    break;

                case "Active":
                    computerIQ = computerIQ.OrderBy(c => c.IsActive);
                    break;

                case "active_desc":
                    computerIQ = computerIQ.OrderByDescending(c => c.IsActive);
                    break;

                case "Replace":
                    computerIQ = computerIQ.OrderBy(c => c.ShouldReplace);
                    break;

                case "replace_desc":
                    computerIQ = computerIQ.OrderByDescending(c => c.ShouldReplace);
                    break;

                case "LastUpdate":
                    computerIQ = computerIQ.OrderBy(c => c.LastUpdate);
                    break;

                case "lastupdate_desc":
                    computerIQ = computerIQ.OrderByDescending(c => c.LastUpdate);
                    break;

                default:
                    computerIQ = computerIQ.OrderBy(c => c.ComputerID);
                    break;
            }

            int pageSize = 10;
            Computer = await PaginatedCollection<Computer>.CreateAsync(
                      computerIQ.AsNoTracking(), pageIndex ?? 1, pageSize
                  ).ConfigureAwait(false);
        }
    }
}