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

namespace JMuelbert.BDE.Pages.Inventories
{
    /// <summary>
    /// Index model.
    /// </summary>
    public class IndexModel : PageModel
    {  /// <summary>
       /// The context.
       /// </summary>
        private readonly BDEContext _context;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.Inventories.IndexModel"/>
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
        /// Gets or sets the IdentifierSort.
        /// </summary>
        /// <value>The IdentifierSort.</value>
        public string IdentifierSort { get; set; }

        /// <summary>
        /// Gets or sets the DescriptionSort.
        /// </summary>
        /// <value>The DescriptionSort.</value>
        public string DescriptionSort { get; set; }

        /// <summary>
        /// Gets or sets the ActiveSort.
        /// </summary>
        /// <value>The ActiveSort.</value>
        public string ActiveSort { get; set; }
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
        /// Gets or sets the Inventory.
        /// </summary>
        /// <value>The Inventory.</value>
        public PaginatedCollection<Inventory> Inventory { get; set; }

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
            _logger.LogDebug($"Inventories/Index/OnGetAsync({currentFilter},{searchString},{pageIndex})");

            CurrentSort = sortOrder;
            IdentifierSort = String.IsNullOrEmpty(sortOrder) ? "identifier_desc" : "";
            DescriptionSort = sortOrder == "Description" ? "description_desc" : "Description";
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

            IQueryable<Inventory> inventoryIQ = from i in _context.Inventory select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                inventoryIQ = inventoryIQ.Where(
                    inv => inv.Identifier.Contains(searchString, StringComparison.CurrentCulture));
            }

            switch (sortOrder)
            {
                case "identifier_desc":
                    inventoryIQ = inventoryIQ.OrderByDescending(i => i.Identifier);
                    break;

                case "Description":
                    inventoryIQ = inventoryIQ.OrderBy(i => i.Description);
                    break;

                case "description_desc":
                    inventoryIQ = inventoryIQ.OrderByDescending(i => i.Description);
                    break;

                case "Active":
                    inventoryIQ = inventoryIQ.OrderBy(i => i.Active);
                    break;

                case "active_desc":
                    inventoryIQ = inventoryIQ.OrderByDescending(i => i.Active);
                    break;

                case "LastUpdate":
                    inventoryIQ = inventoryIQ.OrderBy(i => i.LastUpdate);
                    break;
                case "lastupdate_desc":
                    inventoryIQ = inventoryIQ.OrderByDescending(i => i.LastUpdate);
                    break;

                default:
                    inventoryIQ = inventoryIQ.OrderBy(i => i.Identifier);
                    break;
            }

            int pageSize = 10;
            Inventory = await PaginatedCollection<Inventory>.CreateAsync(
                      inventoryIQ.AsNoTracking(), pageIndex ?? 1, pageSize
                  ).ConfigureAwait(false);
        }
    }
}