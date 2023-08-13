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

namespace JMuelbert.BDE.Pages.Companies
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
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Companies.IndexModel"/>
        /// class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Context.</param>;
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
        /// Gets or sets the name2 sort.
        /// </summary>
        /// <value>The name2 sort.</value>
        public string Name2Sort { get; set; }

        /// <summary>
        /// Gets or sets the active sort.
        /// </summary>
        /// <value>The active sort.</value>
        public string ActiveSort { get; set; }

        // TODO: Remove this
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
        public PaginatedCollection<Company> Company { get; set; }

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
            _logger.LogDebug($"Companies/Index/OnGetAsync({currentFilter},{searchString},{pageIndex})");

            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            Name2Sort = sortOrder == "Name2" ? "name2_desc" : "Name2";
            ActiveSort = sortOrder == "Active" ? "active_desc" : "Active";
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

            IQueryable<Company> companyIQ = from c in _context.Company select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                companyIQ = companyIQ.Where(
                    com => com.Name.Contains(searchString, StringComparison.CurrentCulture));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    companyIQ = companyIQ.OrderByDescending(c => c.Name);
                    break;

                case "Name2":
                    companyIQ = companyIQ.OrderBy(c => c.Name2);
                    break;
                case "name2_desc":
                    companyIQ = companyIQ.OrderByDescending(c => c.Name2);
                    break;

                case "Active":
                    companyIQ = companyIQ.OrderBy(c => c.Active);
                    break;

                case "active_desc":
                    companyIQ = companyIQ.OrderByDescending(c => c.Active);
                    break;

                case "LastUpdate":
                    companyIQ = companyIQ.OrderBy(c => c.LastUpdate);
                    break;

                case "lastupdate_desc":
                    companyIQ = companyIQ.OrderByDescending(c => c.LastUpdate);
                    break;

                default:
                    companyIQ = companyIQ.OrderBy(c => c.Name);
                    break;
            }

            int pageSize = 10;
            Company = await PaginatedCollection<Company>.CreateAsync(
                      companyIQ.AsNoTracking(), pageIndex ?? 1, pageSize
                  ).ConfigureAwait(false);
        }
    }
}