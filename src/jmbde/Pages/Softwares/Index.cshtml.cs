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

namespace JMuelbert.BDE.Pages.Softwares
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
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Softwares.IndexModel"/>
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
        /// Gets or sets the NameSort.
        /// </summary>
        /// <value>The NameSort.</value>
        public string NameSort { get; set; }

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
        /// Gets or sets the Software.
        /// </summary>
        /// <value>The Software.</value>
        public PaginatedCollection<Software> Software { get; set; }

        /// <summary>
        /// Ons the get async.
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="currentFilter"></param>
        /// <param name="searchString"></param>
        /// <param name="pageIndex"></param>
        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString,
                                     int? pageIndex)
        {
            _logger.LogDebug($"Software/Index/OnGetAsync({currentFilter},{searchString},{pageIndex})");

            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            LastUpdateSort = sortOrder == "LastUpdate" ? "lastupdate_desc" : "LastUpdate";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Software> softwareIQ = from s in _context.Software select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                softwareIQ = softwareIQ.Where(
                    soft => soft.Name.Contains(searchString, StringComparison.CurrentCulture));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    softwareIQ = softwareIQ.OrderByDescending(p => p.Name);
                    break;

                case "LastUpdate":
                    softwareIQ = softwareIQ.OrderBy(p => p.LastUpdate);
                    break;
                case "lastupdate_desc":
                    softwareIQ = softwareIQ.OrderByDescending(p => p.LastUpdate);
                    break;

                default:
                    softwareIQ = softwareIQ.OrderBy(p => p.Name);
                    break;
            }

            int pageSize = 10;
            Software = await PaginatedCollection<Software>.CreateAsync(
                      softwareIQ.AsNoTracking(), pageIndex ?? 1, pageSize
                  ).ConfigureAwait(false);
        }
    }
}