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

namespace JMuelbert.BDE.Pages.Departments
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
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Departments.IndexModel"/>
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
        /// Gets or sets the priority sort.
        /// </summary>
        /// <value>The priority sort.</value>
        public string PrioritySort { get; set; }

        // TODO: Remove the LastUpdate sort.
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
        public PaginatedCollection<Department> Department { get; set; }

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
            _logger.LogDebug($"Department/Index/OnGetAsync({currentFilter},{searchString},{pageIndex})");
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            PrioritySort = sortOrder == "Priority" ? "priority_desc" : "Priority";
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

            IQueryable<Department> departmentIQ = from d in _context.Department select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                departmentIQ = departmentIQ.Where(
                    dep => dep.Name.Contains(searchString, StringComparison.CurrentCulture));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    departmentIQ = departmentIQ.OrderByDescending(d => d.Name);
                    break;

                case "Priority":
                    departmentIQ = departmentIQ.OrderBy(d => d.Priority);
                    break;

                case "priority_desc":
                    departmentIQ = departmentIQ.OrderByDescending(d => d.Priority);
                    break;

                case "LastUpdate":
                    departmentIQ = departmentIQ.OrderBy(d => d.LastUpdate);
                    break;

                case "lastupdate_desc":
                    departmentIQ = departmentIQ.OrderByDescending(d => d.LastUpdate);
                    break;

                default:
                    departmentIQ = departmentIQ.OrderBy(d => d.Name);
                    break;
            }

            int pageSize = 10;
            Department = await PaginatedCollection<Department>.CreateAsync(
                      departmentIQ.AsNoTracking(), pageIndex ?? 1, pageSize
                  ).ConfigureAwait(false);
        }
    }
}