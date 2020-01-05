/**************************************************************************
 **
 ** Copyright (c) 2016-2020 Jürgen Mülbert. All rights reserved.
 **
 ** This file is part of jmbde
 **
 ** Licensed under the EUPL, Version 1.2 or – as soon they
 ** will be approved by the European Commission - subsequent
 ** versions of the EUPL (the "Licence");
 ** You may not use this work except in compliance with the
 ** Licence.
 ** You may obtain a copy of the Licence at:
 **
 ** https://joinup.ec.europa.eu/page/eupl-text-11-12
 **
 ** Unless required by applicable law or agreed to in
 ** writing, software distributed under the Licence is
 ** distributed on an "AS IS" basis,
 ** WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 ** express or implied.
 ** See the Licence for the specific language governing
 ** permissions and limitations under the Licence.
 **
 ** Lizenziert unter der EUPL, Version 1.2 oder - sobald
 **  diese von der Europäischen Kommission genehmigt wurden -
 ** Folgeversionen der EUPL ("Lizenz");
 ** Sie dürfen dieses Werk ausschließlich gemäß
 ** dieser Lizenz nutzen.
 ** Eine Kopie der Lizenz finden Sie hier:
 **
 ** https://joinup.ec.europa.eu/page/eupl-text-11-12
 **
 ** Sofern nicht durch anwendbare Rechtsvorschriften
 ** gefordert oder in schriftlicher Form vereinbart, wird
 ** die unter der Lizenz verbreitete Software "so wie sie
 ** ist", OHNE JEGLICHE GEWÄHRLEISTUNG ODER BEDINGUNGEN -
 ** ausdrücklich oder stillschweigend - verbreitet.
 ** Die sprachspezifischen Genehmigungen und Beschränkungen
 ** unter der Lizenz sind dem Lizenztext zu entnehmen.
 **
 **************************************************************************/

using JMuelbert.BDE.Shared.Data;
using JMuelbert.BDE.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMuelbert.BDE.Pages.WorkFunctions {
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
        /// Initializes a new instance of the <see cref="T:JMuelbert.BDE.Pages.WorkFunctions.IndexModel"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="context">Context.</param>

        public IndexModel (ILogger<IndexModel> logger, BDEContext context) {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets or sets the NameSort.
        /// </summary>
        /// <value>The NameSort.</value>
        public string NameSort { get; set; }

        /// <summary>
        /// Gets or sets the PrioritySort.
        /// </summary>
        /// <value>The PrioritySort.</value>
        public string PrioritySort { get; set; }

        // TODO: Remove LastUpdate Sort

        /// <summary>
        /// Gets or sets the LastUpdateSort.
        /// </summary>
        /// <value>The lLastUpdateSort.</value>
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
        /// Gets or sets the Function.
        /// </summary>
        /// <value>The Function.</value>
        public PaginatedCollection<WorkFunction> WorkFunction { get; set; }

        public async Task OnGetAsync (string sortOrder,
            string currentFilter, string searchString, int? pageIndex) {
            _logger.LogDebug ($"Functions/Index/OnGetAsync({sortOrder}, {currentFilter}, {searchString}, {pageIndex})");

            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty (sortOrder) ? "name_desc" : "";
            PrioritySort = sortOrder == "Priority" ? "priority_desc" : "Priority";
            LastUpdateSort = sortOrder == "LastUpdate" ? "lastupdate_desc" : "LastUpdate";
            if (searchString != null) {
                pageIndex = 1;
            } else {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<WorkFunction> functionIQ = from f in _context.WorkFunction
            select f;

            if (!String.IsNullOrEmpty (searchString)) {
                functionIQ = functionIQ.Where (fun => fun.Name.Contains (searchString, StringComparison.CurrentCulture));
            }
            switch (sortOrder) {
                case "name_desc":
                    functionIQ = functionIQ.OrderByDescending (f => f.Name);
                    break;

                case "Priority":
                    functionIQ = functionIQ.OrderBy (f => f.Priority);
                    break;

                case "priority_desc":
                    functionIQ = functionIQ.OrderByDescending (f => f.Priority);
                    break;

                case "LastUpdate":
                    functionIQ = functionIQ.OrderBy (f => f.LastUpdate);
                    break;

                case "lastupdate_desc":
                    functionIQ = functionIQ.OrderByDescending (f => f.LastUpdate);
                    break;

                default:
                    functionIQ = functionIQ.OrderBy (f => f.Name);
                    break;
            }

            int pageSize = 10;
            WorkFunction = await PaginatedCollection<WorkFunction>.CreateAsync (
                functionIQ.AsNoTracking (), pageIndex ?? 1, pageSize
            ).ConfigureAwait (false);
        }
    }
}
